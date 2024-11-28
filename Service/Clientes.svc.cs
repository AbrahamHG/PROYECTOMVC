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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Clientes" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Clientes.svc o Clientes.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Clientes : IClientes
    {
        //CREAR UNA INSTANCIA DE MI CONTEXTO Y LCANZABLE PARA TODOS LOS METODOS
        private readonly HotelEntities _context;

        public Clientes()
        {
            _context = new HotelEntities();
        }
        public List<Clientes_DTO> list_clientes(int id)
        {
            //creo y lleno una lista de Camones 
            List<Clientes_DTO> lista_resultado = new List<Clientes_DTO>();
            try
            {
                lista_resultado = (from c in _context.Clientes
                                   where (id == 0 || c.ID_Cliente == id)
                                   select new Clientes_DTO()
                                   {
                                       ID_Cliente = c.ID_Cliente,
                                       Nombre = c.Nombre,
                                       Apellido_Paterno = c.Apellido_Paterno,
                                       Apellido_Materno = c.Apellido_Materno,
                                       Telefono = c.Telefono,
                                       Email = c.Email,
                                       Direccion = c.Direccion
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
