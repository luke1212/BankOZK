namespace BankOZK.Models;
public class MoneyTransferParam
{
    public int BankUserId { get; set; }
    public int SourceAccountId { get; set; }
    public int DestAccountId { get; set; }
    public int TransferAmount { get; set; }
}