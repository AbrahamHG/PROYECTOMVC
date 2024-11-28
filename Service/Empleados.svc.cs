using DTO;
using PROYECTOMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PROYECTOMVC.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Empleados" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Empleados.svc o Empleados.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Empleados : IEmpleados
    {
        //CREAR UNA INSTANCIA DE MI CONTEXTO Y LCANZABLE PARA TODOS LOS METODOS
        private readonly HotelEntities _context;

        public Empleados()
        {
            _context = new HotelEntities();
        }

        public List<Empleados_DTO> list_empleado(int id)
        {
            List<Empleados_DTO> lista_resultado = new List<Empleados_DTO>();
            try
            {
                lista_resultado = (from c in _context.Empleados
                                   where (id == 0 || c.ID_Empleado == id)
                                   select new Empleados_DTO()
                                   {
                                       ID_Empleado = c.ID_Empleado,
                                       Nombre = c.Nombre,
                                       Apellido_Paterno = c.Apellido_Paterno,
                                       Apellido_Materno = c.Apellido_Materno,
                                       Cargo = c.Cargo,
                                       Telefono = c.Telefono,
                                       Email = c.Email
                                   }
                                   ).ToList();


            }
            catch (Exception)
            {

                throw;
            }
            return lista_resultado;

        }
    }
}
