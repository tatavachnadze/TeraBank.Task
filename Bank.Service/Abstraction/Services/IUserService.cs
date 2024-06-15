using Bank.Service.Dto;
using Domain.Entities;

namespace Bank.Service.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> RegisterUser(RegisterDto registerDto);
        void UpdateUser(User user);
        //void ResetPassword(int userId, string newPassword);
        void DeleteUser(int userId);
        Task<User> Login(string email, string password);
    }
}
