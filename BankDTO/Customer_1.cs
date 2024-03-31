namespace Infrastructure.DTO;

public class Customer : Entity
{    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime RegistrationDate { get; set; }
    public bool IsDeleted { get; set; }
    public Customer Customer { get; set; } = null!;
}
