using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PROYECTOMVC.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IClientes" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        List<Clientes_DTO> list_clientes(int id);

    }
}
