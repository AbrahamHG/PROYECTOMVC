using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Clientes_DTO
    {
        [Key]
        public int ID_Cliente { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public string Apellido_Paterno { get; set; }
        [Required]
        [Display(Name = "Apellido Materno")]
        public string Apellido_Materno { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

    }
}
