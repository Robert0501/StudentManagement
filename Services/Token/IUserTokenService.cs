using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Token
{
    public interface IUserTokenService
    {
        int GenerateToken();
        Task<UserToken> UpdateToken(UserToken updatedToken);
        Task<UserToken> GetTokenById(int id);
    }
}