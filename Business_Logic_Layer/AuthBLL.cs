using Business_Logic_Layer.Models;
using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Business_Logic_Layer
{
    public class AuthBLL : IAuthBLL
    {
        public static UserEntity user = new();
        private IAuthDAL _authDAL;

        public AuthBLL(IConfiguration configuration, IAuthDAL authDAL)
        {
            _authDAL = authDAL;
        }

        /// <summary>
        /// login user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> Login(UserModel userModel)
        {
            UserEntity userEntity = new()
            {
                UserName = userModel.Username,
                Password = userModel.Password,
                UserRole = userModel.UserRole
            };
            try
            {
                var token = await _authDAL.Login(userEntity);
                return token.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// register user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task RegisterUser(UserModel userModel)
        {
            CreatePasswordHash(userModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
            UserEntity userEntity = new()
            {
                UserName = userModel.Username,
                Password = userModel.Password,
                UserRole = userModel.UserRole,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            await _authDAL.RegisterUser(userEntity);
        }

        /// <summary>
        /// create password hash
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}