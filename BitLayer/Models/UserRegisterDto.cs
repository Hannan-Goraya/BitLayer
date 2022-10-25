
using System.ComponentModel.DataAnnotations;

namespace BitLayer.Models
{
    public class UserRegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required , EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string confirmPassword { get; set; }

        public string Image { get; set; }




        public IFormFile UploadImage { get; set; }
    }
}
