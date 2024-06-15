namespace Domain.Entities;

public class User : Entity
{
    public string UserName { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public bool IsDeleted { get; set; }
    public Customer Customer { get; set; } = null!;
}
