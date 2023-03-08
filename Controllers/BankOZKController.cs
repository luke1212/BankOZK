using BankOZK.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductV1Controller : ControllerBase
{
    private Bankuser[] bankUsers = {
            new Bankuser { Id = 1,
                    Firstname = "John",
                    Lastname = "Doe",
                    AddressAddress1 = "123 Main St",
                    AddressAddress2 = "Apt 1",
                    AddressCity = "Anytown",
                    AddressState = "CA",
                    AddressCountry = "USA",
                    AddressZipCode = "12345",
                    CreatedAt = DateTime.Now},
            new Bankuser { Id = 2,
                    Firstname = "Jane",
                    Lastname = "Doe",
                    AddressAddress1 = "123 Main St",
                    AddressAddress2 = "Apt 1",
                    AddressCity = "Anytown",
                    AddressState = "CA",
                    AddressCountry = "USA",
                    AddressZipCode = "12345",
                    CreatedAt = DateTime.Now}
            };

    private Bankaccount[] bankAccounts = {
            new Bankaccount { Id = 1,
                    AccountType = (int?)AccountType.Checkings,
                    Amount = 100,
                    BankUserId = 1,
                    Enabled = 1,
                    CreatedAt = DateTime.Now},
            new Bankaccount { Id = 2,
                    AccountType = (int?)AccountType.Savings,
                    Amount = 2000,
                    BankUserId = 1,
                    Enabled = 1,
                    CreatedAt = DateTime.Now},
            new Bankaccount { Id = 3,
                    AccountType = (int?)AccountType.MoneyMarket,
                    Amount = 3000,
                    BankUserId = 3,
                    Enabled = 1,
                    CreatedAt = DateTime.Now}
            };

    [HttpGet]
    public ActionResult GetAllUsers()
    {
        foreach (Bankuser user in bankUsers)
        {
            user.Bankaccounts = bankAccounts.Where(ba => ba.BankUserId == user.Id).ToList();
        }
        return Ok(bankUsers.ToArray());
    }

    [HttpPost]
    public ActionResult MoneyTransfer([FromBody] MoneyTransferParam moneyTransferParam)
    {
        Bankaccount sourceAccount = bankAccounts.Where(ba => ba.Id == moneyTransferParam.SourceAccountId).FirstOrDefault();
        Bankaccount destinationAccount = bankAccounts.Where(ba => ba.Id == moneyTransferParam.DestAccountId).FirstOrDefault();


        if (sourceAccount.Amount < moneyTransferParam.TransferAmount
            || sourceAccount.Enabled == 0
            || destinationAccount.Enabled == 0)
        {
            sourceAccount.Enabled = 0;
            return BadRequest("Insufficient funds");
        }

        sourceAccount.Amount -= moneyTransferParam.TransferAmount;
        destinationAccount.Amount += moneyTransferParam.TransferAmount;

        Bankuser user = bankUsers.Where(bu => bu.Id == moneyTransferParam.BankUserId).FirstOrDefault();
        user.Bankaccounts = bankAccounts.Where(ba => ba.BankUserId == user.Id).ToList();

        return Ok(user);
    }


}