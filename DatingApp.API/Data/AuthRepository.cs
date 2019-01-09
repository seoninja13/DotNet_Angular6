
using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
           var user = await _context.User.FirstOrDefaultAsync(x=> x.Username == username);

           if(user == null)
           return null;

           if (!VerifyPasswordHash(password, user.Passwordhash, user.PasswordSalt))
           return null;

           return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordSalt)
        {
            // with 'using' all of the code will be dispossed of once done with it
           using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
           {
               var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
               for( int i=0; i < computedHash.Length; i++  )
               {
                  if (computedHash[i] != passwordhash[i])
                  {
                      return false;
                  } 
               }
           }
           return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.Passwordhash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // with 'using' all of the code will be dispossed of
           using (var hmac = new System.Security.Cryptography.HMACSHA512())
           {
               passwordSalt = hmac.Key;
               passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.User.AnyAsync(x=> x.Username == username))
            return true;

            return false;
        }
    }
}