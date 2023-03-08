using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankOZK.Models;

public partial class Bankaccount
{
    public int Id { get; set; }

    public int? BankUserId { get; set; }

    [Required]
    public int? AccountType { get; set; }
    [Required]
    public int? Amount { get; set; }

    public int? Enabled { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Bankuser? BankUser { get; set; }
}
