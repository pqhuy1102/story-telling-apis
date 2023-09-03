using Business_Logic_Layer.Models;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public interface IAuthBLL
    {
        public Task RegisterUser(UserModel userModel);
        public Task<string> Login(UserModel userModel);
    }
}
