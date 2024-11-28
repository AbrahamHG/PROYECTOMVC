using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Habitaciones_DTO
    {
        [Key]
        public int ID_Habitacion { get; set; }
        [Required]
        [Display(Name = "Numero Habitacion")]
        public int Numero_Habitacion { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string tipo { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public int Precio { get; set; }
        [Required]
        [Display(Name = "Estado de Disponibilidad")]
        public Nullable<bool> Estatus { get; set; }
        [Required]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

    }
}
