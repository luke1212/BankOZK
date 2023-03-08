using BankOZK.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductV1Controller : ControllerBase
{


    [HttpGet]
    public ActionResult GetAllUsers()
    {
        Bankuser[] bankUsers = {
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

        Bankaccount[] bankAccounts = {
            new Bankaccount { Id = 1,
                    AccountType = (int?)AccountType.Checkings,
                    Amount = 100,
                    BankUserId = 2,
                    CreatedAt = DateTime.Now},
            new Bankaccount { Id = 2,
                    AccountType = (int?)AccountType.Savings,
                    Amount = 2000,
                    BankUserId = 1,
                    CreatedAt = DateTime.Now},
            new Bankaccount { Id = 3,
                    AccountType = (int?)AccountType.MoneyMarket,
                    Amount = 3000,
                    BankUserId = 3,
                    CreatedAt = DateTime.Now}
            };

        foreach (Bankuser user in bankUsers)
        {
            user.Bankaccounts = bankAccounts.Where(ba => ba.BankUserId == user.Id).ToList();
        }
        return Ok(bankUsers.ToArray());
    }
}