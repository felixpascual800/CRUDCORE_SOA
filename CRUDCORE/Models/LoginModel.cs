using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class LoginModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }

}

