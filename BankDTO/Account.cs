namespace Infrastructure.DTO;

public class Account : Entity
{
    public AccountStatus Status { get; set; }
    public string IBAN { get; set; } = null!;
    public decimal Balance { get; set; }
    public bool IsActive { get; set; }
    public Customer Customer { get; set; } = null!;
    public Card Card { get; set; } = null!;
    public ICollection<Transaction>? FromAccount{ get; set; }
    public ICollection<Transaction>? ToAccount { get; set; }
}

public enum AccountStatus : byte
{
    Suspended = 0,
    Ongoing = 1
}

