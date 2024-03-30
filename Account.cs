﻿using System;

public class Account
{
    public AccountStatus Status { get; set; }
    public string IBAN { get; set; } = null!;
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }
    public Customer Customer { get; set; } = null!;
    public Card Card { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}

public enum AccountStatus : byte
{
    Suspended = 0,
    Ongoing = 1
}
