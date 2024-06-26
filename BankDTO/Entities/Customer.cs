﻿namespace Domain.Entities;
public class Customer : Entity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Gender Gender { get; set; }
    public string PersonalNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Card> Cards { get; set; } = null!;
    public ICollection<Account> Accounts { get; set; } = null!;
}

public enum Gender : byte
{
    Male = 0,
    Female = 1
}

