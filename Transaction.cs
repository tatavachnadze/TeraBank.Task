using System;

public class Transaction : Entity
{
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
    public Account Account { get; set; } = null!;
    public Card? Card { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }

    public enum TransactionType : byte
    {
        Income = 0,
        Outcome = 1,
    }
}
