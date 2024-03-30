using Infrastructure.DTO;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories;

public class BankDbContext : DbContext
{
    public DbSet<Account> Account { get; set; }
    public DbSet<Card> Card { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Transaction> Transaction { get; set; }
    public DbSet<User> Users { get; set; }
    public BankDbContext(DbContextOptions<BankDbContext> dbContext) : base(dbContext)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<User>().ToTable("Users", "identity");
        //modelBuilder.Entity<Role>().ToTable("Roles", "identity");
        //modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", "identity");
        //modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", "identity");
        //modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", "identity");
        //modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", "identity");
        //modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", "identity");
        modelBuilder.Entity<Account>().Property(a => a.IBAN).HasColumnType("nvarchar(25)").IsRequired(true);
        modelBuilder.Entity<Account>().HasIndex(a => a.IBAN).IsUnique(true);
        modelBuilder.Entity<Account>().Property(a => a.Balance).HasColumnType("money").IsRequired();
        modelBuilder.Entity<Account>().Property(a => a.IsActive).IsRequired().HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<Account>().Property(a => a.CreateDate).IsRequired().HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<Account>().HasOne(a => a.Customer).WithMany(cu => cu.Accounts).IsRequired(true);
        modelBuilder.Entity<Account>().HasOne(a => a.Card).WithMany(c => c.Accounts).IsRequired(false);
       
        modelBuilder.Entity<Card>().Property(c => c.Type).HasColumnType("nvarchar(20)").IsRequired();
        modelBuilder.Entity<Card>().HasIndex(c => new { c.Number, c.Cvc }).IsUnique(true);
        modelBuilder.Entity<Card>().Property(c => c.Number).HasColumnType("nvarchar(20)").IsRequired();
        modelBuilder.Entity<Card>().Property(c => c.Cvc).HasColumnType("nvarchar(4)").IsRequired();
        modelBuilder.Entity<Card>().Property(c => c.ExpirationDate).HasDefaultValueSql("GetDate()").HasColumnType("date").IsRequired();
        modelBuilder.Entity<Card>().Property(c => c.CreateDate).HasDefaultValueSql("GetDate()").HasColumnType("date").IsRequired();
        modelBuilder.Entity<Card>().Property(c => c.IsActive).HasColumnType("bit").HasDefaultValueSql("(0)").IsRequired();
        modelBuilder.Entity<Card>().HasMany(c => c.Accounts).WithOne(a => a.Card).IsRequired(true);   

        modelBuilder.Entity<Customer>().Property(cu => cu.FirstName).HasColumnType("nvarchar(25)").IsRequired();
        modelBuilder.Entity<Customer>().Property(cu => cu.LastName).HasColumnType("nvarchar(25)").IsRequired();
        modelBuilder.Entity<Customer>().Property(cu => cu.Email).HasColumnType("nvarchar(25)").IsRequired();
        modelBuilder.Entity<Customer>().Property(cu => cu.PersonalNumber).HasColumnType("nvarchar(11)").IsRequired();
        modelBuilder.Entity<Customer>().Property(cu => cu.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()").IsRequired();
        modelBuilder.Entity<Customer>().Property(cu => cu.IsActive).HasColumnType("bit").HasDefaultValueSql("(0)").IsRequired();
        modelBuilder.Entity<Customer>().HasOne(cu => cu.User).WithOne(u => u.Customer).HasForeignKey<Customer>(u => u.Id).IsRequired(true);
        modelBuilder.Entity<Customer>().HasMany(cu => cu.Accounts).WithOne(a => a.Customer).IsRequired(true);

        modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasColumnType("money").IsRequired();
        modelBuilder.Entity<Transaction>().Property(t => t.Type).HasColumnType("nvarchar(10)").IsRequired();
        modelBuilder.Entity<Transaction>().Property(t => t.Date).HasColumnType("datetime2(7)").IsRequired();
        modelBuilder.Entity<Transaction>().Property(t => t.IsDeleted).HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<Transaction>().Property(t => t.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<Transaction>().HasOne(t => t.FromAccount).WithMany(a => a.Transactions).IsRequired(true);
        modelBuilder.Entity<Transaction>().HasOne(t => t.ToAccount).WithMany(a => a.Transactions).IsRequired(true);

        modelBuilder.Entity<User>().Property(u => u.UserName).HasColumnType("nvarchar(15)").IsRequired();
        modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique(true);
        modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("nvarchar(128)").IsRequired();
        modelBuilder.Entity<User>().Property(u => u.RegistrationDate).HasColumnType("datetime2(7)").IsRequired();
        modelBuilder.Entity<User>().Property(u => u.IsDeleted).HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<User>().Property(u => u.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<User>().HasOne(u => u.Customer).WithOne(c => c.User).HasForeignKey<Customer>(u => u.Id).IsRequired(true);

    }
}
