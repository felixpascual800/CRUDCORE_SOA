using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class ActivoModel
    {
        public int IdActivo { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public string? Estado { get; set; }
    }
}




