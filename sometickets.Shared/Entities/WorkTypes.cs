using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sometickets.Shared.Entities
{
    public class WorkTypes
    {
        [Key]
        public int Id_worktype { get; set; }

        [Display(Name = "Work Types")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = " El campo {0} no puede tener mas de {1} caracteres")]
        public string Description { get; set; } = null!;
    }
}
