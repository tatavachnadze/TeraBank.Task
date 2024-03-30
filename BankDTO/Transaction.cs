namespace Infrastructure.DTO;
public class Transaction : Entity
{
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
    public Account FromAccount { get; set; } = null!;
    public Account ToAccount { get; set; } = null!;
    public bool IsDeleted { get; set; }

    public enum TransactionType : byte
    {
        Income = 0,
        Outcome = 1,
    }
}
