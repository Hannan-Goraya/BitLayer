using Bitlayer.Bll.Services;
using BitLayer.Domain.Models;
using BitLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using System.Security.Cryptography;

namespace BitLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _user;

        public UserController(IUserServices user)
        {
            _user = user;
        }


        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Register() => View();


        [HttpPost]
        public IActionResult Register(UserRegisterDto dto)
        {

            _user.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var password = passwordSalt + "::" + passwordHash;




            if (dto.Password == dto.confirmPassword)
            {
                var user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = password,
                    Image = dto.Image,

                };





               _user.Register(user);

                return RedirectToAction("Login");
            }

            else
            {
                return BadRequest("password dosn't match!");


            }

        }


        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(UserLogindto dto)
        {

            var user = new User();

            


            var res = _user.Login(dto.Email);

                

            _user.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var password = passwordSalt + "::" + passwordHash;


            if (password != res.Password)
            {
                return BadRequest("password dos't match");


            }



            return RedirectToRoute("Default");
            

           

            
             
            }

        }



    }
    
