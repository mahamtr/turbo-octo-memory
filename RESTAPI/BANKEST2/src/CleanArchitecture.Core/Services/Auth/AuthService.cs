using BANKEST2.Core.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BANKEST2.Core.Entities;

namespace BANKEST2.Core.Services.Auth
{
    public class AuthService : IAuthService
    {
        private byte[] salt = new byte[] { 62, 4, 14, 42, 12,44, 62, 0 };
        private IRepository<Users> _usersRepository;
        public AuthService(IRepository<Users> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool AuthenticateUser(string UserName, string Password)
        {
            var users = _usersRepository.GetFiltered(i => i.UserName == UserName);
            if (!users.Any())
            {
                return false;
            }
            var user = users.FirstOrDefault();
            string hashed = GenerateHash(Password);
            return string.Equals(hashed, user.Password);
        }

        private string GenerateHash(string Password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                   password: Password,
                   salt: salt,
                   prf: KeyDerivationPrf.HMACSHA1,
                   iterationCount: 10000,
                   numBytesRequested: 256 / 8));
        }
    }
}
