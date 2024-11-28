using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Servicios_Habitacion_DTO
    {
        [Key]
        public int ID_ServHab { get; set; }
        [Key]
        public int Habitacion_ID { get; set; }
        [Required]
        [Display(Name = "Servicio")]
        public int Servicio_ID { get; set; }
        [Required]
        [Display(Name = "Empleado")]
        public int Empleado_ID { get; set; }
        [Required]
        [Display(Name = "Fecha de Sertvicio")]
        public System.DateTime Fecha_Servicio { get; set; }

    }
}
