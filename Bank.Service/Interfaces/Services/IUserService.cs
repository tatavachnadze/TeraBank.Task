using Infrastructure.DTO;

namespace Bank.Service.Interfaces.Services
{
    public interface IUserService
    {
        Task<Customer> GetUser(int id);
        Task<IQueryable<Customer>> GetUsers();
        void CreateUser(Customer user);
        void UpdateUser(Customer user);
        void ResetPassword(int userId, string newPassword);
        void DeleteUser(int userId);
    }
}
