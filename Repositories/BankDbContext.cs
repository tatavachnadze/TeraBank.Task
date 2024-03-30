using Infrastructure.DTO;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories;

public class BankDbContext : IdentityDbContext<User, Role, Guid>
{
    public DbSet<Account> Authors { get; set; }
    public DbSet<Card> Books { get; set; }
    public DbSet<Customer> Categories { get; set; }
    public DbSet<Transaction> Students { get; set; }
    public BankDbContext(DbContextOptions<BankDbContext> dbContext) : base(dbContext)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("Users", "identity");
        modelBuilder.Entity<Role>().ToTable("Roles", "identity");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", "identity");
        //modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", "identity");
        //modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", "identity");
        //modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", "identity");
        //modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", "identity");
        modelBuilder.Entity<Account>().Property(a => a.IBAN).HasColumnType("nvarchar(25)").IsRequired(true);
        modelBuilder.Entity<Account>().HasIndex(a => a.IBAN).IsUnique(true);
        modelBuilder.Entity<Account>().Property(a => a.Balance).HasColumnType("money").IsRequired();
        modelBuilder.Entity<Account>().Property(a => a.IsActive).IsRequired().HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<Account>().Property(a => a.CreateDate).IsRequired().HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<Account>().HasOne(a => a.Customer).WithMany(a => a.Accounts).IsRequired(true);
        modelBuilder.Entity<Account>().HasOne(a => a.Card).WithMany(c => c.Accounts).IsRequired(false);

       
        modelBuilder.Entity<Card>().Property(a => a.Type).HasColumnType("nvarchar(20)").IsRequired();
        modelBuilder.Entity<Card>().HasIndex(a => new { a.Number, a.Cvc }).IsUnique(true);
        modelBuilder.Entity<Card>().Property(a => a.Number).HasColumnType("nvarchar(20)").IsRequired();
        modelBuilder.Entity<Card>().Property(a => a.Cvc).HasColumnType("nvarchar(4)").IsRequired();
        modelBuilder.Entity<Card>().Property(a => a.ExpirationDate).HasDefaultValueSql("GetDate()").HasColumnType("date").IsRequired();
        modelBuilder.Entity<Card>().Property(a => a.CreateDate).HasDefaultValueSql("GetDate()").HasColumnType("date").IsRequired();
        modelBuilder.Entity<Card>().Property(a => a.IsActive).HasColumnType("bit").HasDefaultValueSql("(0)").IsRequired();
        modelBuilder.Entity<Card>().HasMany(a => a.Accounts).WithOne(a => a.Card).IsRequired(true);
   

        modelBuilder.Entity<Customer>().Property(a => a.FirstName).HasColumnType("nvarchar(25)").IsRequired();
        modelBuilder.Entity<Customer>().Property(a => a.LastName).HasColumnType("nvarchar(25)").IsRequired();
        modelBuilder.Entity<Customer>().Property(a => a.Email).HasColumnType("nvarchar(25)").IsRequired();
        modelBuilder.Entity<Customer>().Property(a => a.PersonalNumber).HasColumnType("nvarchar(11)").IsRequired();
        modelBuilder.Entity<Customer>().Property(a => a.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()").IsRequired();
        modelBuilder.Entity<Customer>().Property(a => a.IsActive).HasColumnType("bit").HasDefaultValueSql("(0)").IsRequired();
        //modelBuilder.Entity<Customer>().HasOne(u => u.User).WithOne(c => c.Customer).HasForeignKey<Customer>(u => u.UserId).IsRequired(true);
        modelBuilder.Entity<Customer>().HasMany(a => a.Accounts).WithOne(c => c.Customer).IsRequired(false);

        modelBuilder.Entity<Transaction>().Property(a => a.Amount).HasColumnType("money").IsRequired();
        modelBuilder.Entity<Transaction>().Property(a => a.Type).HasColumnType("nvarchar(10)").IsRequired();
        modelBuilder.Entity<Transaction>().Property(a => a.Date).HasColumnType("datetime2(7)").IsRequired();
        modelBuilder.Entity<Transaction>().Property(a => a.IsDeleted).HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<Transaction>().Property(a => a.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<Transaction>().HasOne(a => a.FromAccount).WithMany(a => a.Transactions).IsRequired(true);
        modelBuilder.Entity<Transaction>().HasOne(a => a.ToAccount).WithMany(a => a.Transactions).IsRequired(true);
    }
}
