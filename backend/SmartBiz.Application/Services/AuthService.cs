using System;
using System.Collections.Generic;
using System.Text;
using BCrypt.Net;
using SmartBiz.Core.Interfaces;

namespace SmartBiz.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _users;
        private readonly JwtService _jwt;

        public AuthService(IUserRepository users, JwtService jwt)
        {
            _users = users;
            _jwt = jwt;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _users.GetByEmailAsync(email);
            if (user == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) return null;

            return _jwt.GenerateToken(user);
        }
    }
}
