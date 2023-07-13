using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }

}
