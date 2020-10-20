
using System;
using secretsVaul.Models;

namespace secretsVaul.Services
{
    public interface ITokenService
    {
        string CreateToken(Guid user);
        string UpdateToken(string token);
        Token ValidateToken(string token);
    }
}