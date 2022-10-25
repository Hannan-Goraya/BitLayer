using BitLayer.Domain.Models;

namespace Bitlayer.Bll.Services
{
    public interface IUserServices
    {
        int Register(User user);


        User Login(string email);  


        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

     

    }
}