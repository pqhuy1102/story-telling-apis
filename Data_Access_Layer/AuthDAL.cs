using Data_Access_Layer.Repository.Context;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class AuthDAL : IAuthDAL
    {
        private StoryTellingContext _storyTellingContext;
        private readonly IConfiguration _configuration;

        public AuthDAL(StoryTellingContext storyTellingContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _storyTellingContext = storyTellingContext;
        }

        public async Task<string> Login(UserEntity userEntity)
        {
            var loginUser = await _storyTellingContext.Users.FirstOrDefaultAsync(x => x.UserName == userEntity.UserName);
            if (loginUser == null)
            {
                throw new Exception("User not found!");
            }
            else
            {
                if (!VerifyPasswordHash(userEntity.Password, loginUser.PasswordHash, loginUser.PasswordSalt))
                {
                    throw new Exception("Wrong user password!");
                }

                string token = CreateUserToken(loginUser);
                return token;
            }
        }

        /// <summary>
        /// verify password hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes((string)password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        /// <summary>
        /// create jwt
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateUserToken(UserEntity user)
        {
            string role = "";
            switch (user.UserRole)
            {
                case UserRole.Admin:
                    role = "Admin";
                    break;
                case UserRole.Reader:
                    role = "Reader";
                    break;
                case UserRole.Author:
                    role = "Author";
                    break;
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JwtSettings:Token").Value ?? ""));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task RegisterUser(UserEntity userEntity)
        {
            var availableUser = _storyTellingContext.Users.Any(x => x.UserName == userEntity.UserName);
            if (!availableUser)
            {
                await _storyTellingContext.Users.AddAsync(userEntity);
                await _storyTellingContext.SaveChangesAsync();
            }
        }
    }
}
