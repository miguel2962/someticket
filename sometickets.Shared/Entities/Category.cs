using System.ComponentModel.DataAnnotations;

namespace sometickets.Shared.Entities
{
    public class Category
    {
        [Key]
        public int Id_category { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = " El campo {0} no puede tener mas de {1} caracteres")]
        public string Description { get; set; } = null!;
    }
}
