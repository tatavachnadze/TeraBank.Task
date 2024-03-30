using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<IQueryable<User>> GetUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void ResetPassword(int userId, string newPassword);
        void DeleteUser(int userId);
    }
}
