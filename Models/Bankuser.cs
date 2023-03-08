using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankOZK.Models;

public partial class Bankuser
{
    public int Id { get; set; }

    [Required]
    public string? Firstname { get; set; }

    [Required]
    public string? Lastname { get; set; }

    public string? AddressAddress1 { get; set; }

    public string? AddressAddress2 { get; set; }

    public string? AddressCity { get; set; }

    public string? AddressState { get; set; }

    public string? AddressCountry { get; set; }

    public string? AddressZipCode { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Bankaccount> Bankaccounts { get; } = new List<Bankaccount>();
}
