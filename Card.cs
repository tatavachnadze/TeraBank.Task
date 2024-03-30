﻿using System;

public class Card
{
    public CardType Type { get; set; }
    public string Number { get; set; } = null!;
    public string Cvc { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }    
    public bool IsActive { get; set; }
    public ICollection<Account> Account { get; set; } = null!;    

    public enum CardType : byte
    {
        MasterCard = 0,
        Visa = 1,
    }
}
