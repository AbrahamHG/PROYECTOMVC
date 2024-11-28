using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Reservas_DTO
    {
        [Key]
        public int ID_reserva { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public int Cliente_ID { get; set; }
        [Key]
        public int Habitacion_ID { get; set; }
        [Required]
        [Display(Name = "Fecha de Entrada")]
        public System.DateTime CheckIN { get; set; }
        [Required]
        [Display(Name = "Fecha de Salida")]
      public System.DateTime CheckOUT { get; set; }
        [Required]
        [Display(Name = "Estatus")]
        public Nullable<bool> Estatus { get; set; }

    }
}
