using Bank.Service.Interfaces.Services;
using Domain.Abstractions;
using Domain.Entities;
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

        public Task<IQueryable<User>> GetUsers()
        {
            var users = _unitOfWork.UserRepository.Set();
            if (users != null)
            {
                return Task.FromResult(users);
            }
            else
            {
                throw new InvalidDataException("Users could not be found within the data");
            }
        }

        public void CreateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.Password = StringExtensions.GetHashString(user.Password);
            _unitOfWork.UserRepository.Insert(user);
            SaveChanges();
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

        public void ResetPassword(int userId, string newPassword)
        {
            var user = _unitOfWork.UserRepository.Get(userId);
            if (user != null)
            {
                user.Password = newPassword;
                _unitOfWork.UserRepository.Update(user);
                SaveChanges();
            }
            else
            {
                throw new InvalidDataException("User not found");
            }
        }

        public void DeleteUser(int id)
        {
            User user = _unitOfWork.UserRepository.Get(id) ?? throw new ArgumentNullException($"The user with Id: {id} does not exist.");
            user.IsDeleted = true;
            _unitOfWork.UserRepository.Update(user);
            SaveChanges();
        }

        public bool Login(string username, string password)
        {
            if (username == null) throw new ArgumentNullException(nameof(username));
            if (password == null) throw new ArgumentNullException(nameof(password));

            return _unitOfWork
                .UserRepository
                .Set(u => u.UserName == username && u.Password == password && !u.IsDeleted)
                .SingleOrDefault() != default;
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }


    }
}
