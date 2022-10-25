using BitLayer.Dal;
using BitLayer.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bitlayer.Bll.Services
{
    public class UserServices : IUserServices
    {
        private readonly IDapperRepository _dapper;

        public UserServices(IDapperRepository dapper)
        {
            _dapper = dapper;
        }


        public int Register(User user)
        {
       


            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@Id", -1, dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameter.Add("@Name", user.Name);
            parameter.Add("@Email", user.Email);
            parameter.Add("@Password", user.Password);
            parameter.Add("Image", user.Image);



            var result =  _dapper.ReturnInt("AddUser", parameter);
            if (result > 0)
            {

            }

            return result;


        }



        public User Login(string email)
        {



            DynamicParameters parameter = new DynamicParameters();


            parameter.Add("@Email", email);




            return _dapper.ReturnList< User>("GetUserByEmail", parameter).FirstOrDefault();


        }






            public string CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        
    }


}

