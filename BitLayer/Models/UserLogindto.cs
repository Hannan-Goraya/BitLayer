using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BitLayer.Models
{
    public class UserLogindto
    {
        [EmailAddress, Required]
        public string Email { get; set; }

        [PasswordPropertyText, Required]
        public string Password { get; set; }

    }
}
