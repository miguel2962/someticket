using System.ComponentModel.DataAnnotations;

namespace sometickets.Shared.Entities
{
    public class UserRol
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "user roles")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = " El campo {0} no puede tener mas de {1} caracteres")]
        public string Description { get; set; } = null!;
    }
}
