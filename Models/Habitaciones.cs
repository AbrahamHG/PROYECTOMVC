//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROYECTOMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Habitaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitaciones()
        {
            this.Reservas = new HashSet<Reservas>();
            this.Servicios_Habitacion = new HashSet<Servicios_Habitacion>();
        }
    
        public int ID_Habitacion { get; set; }
        public int Numero_Habitacion { get; set; }
        public string tipo { get; set; }
        public int Precio { get; set; }
        public Nullable<bool> Estatus { get; set; }
        public string Descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservas> Reservas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servicios_Habitacion> Servicios_Habitacion { get; set; }
    }
}
