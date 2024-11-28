using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Servicios_DTO
    {
        [Key]
        public int ID_Servicio { get; set; }
        [Required]
        [Display(Name = "Servicio")]
        public string Servicio { get; set; }
        [Required]
        [Display(Name = "Costo")]
        public int Costo { get; set; }

    }
}
