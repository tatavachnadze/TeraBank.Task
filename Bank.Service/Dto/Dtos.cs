using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.Dto
{
    public record AccessTokenDto(string? Issuer, string? Audience, double Expires, string Token);
    public class UserDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }

    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
