using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class Proveedor
    {
        public static ProveedorModel RegistrarProveedor(string id, string nombre, string apellido, string estado, int CategoriasProductos)
        {
            // Método para crear un proveedor
            //Crea una instancia de ProveedorModel
            ProveedorModel nuevoProveedor = new ProveedorModel(id, nombre, apellido, estado, //cat productos);
            // Agrega al proveedor a la base de datos
            var jsonRequest = JsonConvert.SerializeObject(nuevoProveedor);
            HttpResponseMessage response = WebHelper.Post("Proveedor/AgregarProveedor", jsonRequest);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            else
            {
                Console.WriteLine("Proveedor creado con exito!");
            }
            // Retorna el Proveedor creado
            return nuevoProveedor;
        }

        private static void DarDeBaja(ProveedorModel proveedor)
        {
            proveedor.Estado = "INACTIVO";
        }
    }
}
