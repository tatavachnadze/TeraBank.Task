using Domain.Entities;

namespace Bank.Service.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void ResetPassword(int userId, string newPassword);
        void DeleteUser(int userId);
    }
}
