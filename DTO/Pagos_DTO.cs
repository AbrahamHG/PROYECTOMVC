using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Pagos_DTO
    {
        [Key]
        public int ID_Pago { get; set; }
        [Required]
        [Display(Name = "Reserva")]
        public int Reserva_ID { get; set; }
        public double Monto { get; set; }
        [Required]
        [Display(Name = "Fecha Pago")]
        public System.DateTime Fecha_Pago { get; set; }
        [Required]
        [Display(Name = "Metodo Pago")]
        public string Metodo_Pago { get; set; }

    }
}
