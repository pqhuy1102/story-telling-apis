using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public interface IAuthDAL
    {
        public Task RegisterUser(UserEntity userEntity);
        public Task<string> Login(UserEntity userEntity);
    }
}
