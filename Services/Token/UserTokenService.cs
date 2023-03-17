using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Services.Token
{
    public class UserTokenService : IUserTokenService
    {
        private readonly DataContext _context;

        public UserTokenService(DataContext context)
        {
            _context = context;
        }

        public int GenerateToken()
        {
            var token = 1;
            return token;
        }

        public async Task<UserToken> UpdateToken(UserToken updatedToken)
        {
            var token = new UserToken();
            token = await _context.UserToken.FirstOrDefaultAsync(t => t.UserTokenId == updatedToken.UserTokenId);
            token.Token = updatedToken.Token;
            await _context.SaveChangesAsync();

            return token;
        }

        public async Task<UserToken> GetTokenById(int id)
        {
            var token = await _context.UserToken.FirstOrDefaultAsync(t => t.UserTokenId == id);
            return token;
        }
    }
}