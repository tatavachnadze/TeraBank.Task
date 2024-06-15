using Bank.Service.Dto;
using Domain.Entities;

namespace Bank.Service.Abstraction.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);        
    }
}
