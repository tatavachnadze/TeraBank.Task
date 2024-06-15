using Bank.Service.Dto;
using Bank.Service.Interfaces.Services;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TeraExtensions;

namespace Bank.Service
{
    public sealed class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //TODO: Implement password Hashing.

        public Task<User> GetUser(int userId)
        {
            User user = _unitOfWork.UserRepository.Get(userId);
            if (user != null)
            {
                return Task.FromResult(user);
            }
            else
            {
                throw new InvalidDataException("The UserId could not be found");
            }
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            var users = _unitOfWork.UserRepository.Set() as IEnumerable<User>;
            if (users != null)
            {
                return Task.FromResult(users);
            }
            else
            {
                throw new InvalidDataException("Users could not be found within the data");
            }
        }

        public Task<User> RegisterUser(RegisterDto registerDto)
        {
            if (registerDto.Email == null) throw new ArgumentNullException(nameof(registerDto.Email));
            var user = _unitOfWork.UserRepository.Set().Single(u => u.Email == registerDto.Email);
            if (user.Email == registerDto.Email) 
            {
                throw new InvalidDataException("Email is already registered");                
            }
           using var hmac = new HMACSHA512();
           user.Email = registerDto.Email.ToLower();
           user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password));
           user.PasswordSalt = hmac.Key;

            _unitOfWork.UserRepository.Insert(user);
            SaveChanges();

            return Task.FromResult(user);        
        }
        

        public void UpdateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var currentUser = _unitOfWork.UserRepository.Set().SingleOrDefault(u => u.Id == user.Id);

            if (currentUser != null)
            {
                currentUser.UserName = user.UserName;              
                //currentUser.RegistrationDate = user.RegistrationDate;
                //currentUser.Customer = user.Customer;
                _unitOfWork.UserRepository.Update(currentUser);
                SaveChanges();
            }
            else
            {
                throw new InvalidDataException("User not found");
            }
        }

        //public void ResetPassword(int userId, string newPassword)
        //{
        //    var user = _unitOfWork.UserRepository.Get(userId);
        //    if (user != null)
        //    {
        //        user.Password = newPassword;
        //        _unitOfWork.UserRepository.Update(user);
        //        SaveChanges();
        //    }
        //    else
        //    {
        //        throw new InvalidDataException("User not found");
        //    }
        //}

        public void DeleteUser(int id)
        {
            User user = _unitOfWork.UserRepository.Get(id) ?? throw new ArgumentNullException($"The user with Id: {id} does not exist.");
            user.IsDeleted = true;
            _unitOfWork.UserRepository.Update(user);
            SaveChanges();
        }

        public Task<User> Login(string email, string password)
        {         

            var user = _unitOfWork.UserRepository.Get(email); 
            if(user.Email != email)
            {
                throw new UnauthorizedAccessException();
            }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i])
                {
                    throw new UnauthorizedAccessException();
                }               
            }
            return Task.FromResult(user);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}
