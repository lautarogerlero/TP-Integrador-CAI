using Modelo;
using Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net.Http;

namespace Negocio
{
    public class Proveedor
    {
        // Lista de proveedores registrados
        static List<ProveedorModel> proveedores = new List<ProveedorModel>();

        // Método para registrar un nuevo proveedor
        public static void RegistrarProveedor(string nombre, string apellido, List<int> categoriasProductos)
        {
            // Crear un nuevo proveedor con un ID único, el nombre, el apellido, el estado "Activo" y las categorías de productos
            ProveedorModel nuevoProveedor = new ProveedorModel(Guid.NewGuid(), nombre, apellido, "Activo", categoriasProductos);

            // Agregar el nuevo proveedor a la lista de proveedores
            proveedores.Add(nuevoProveedor);
            Console.WriteLine($"El proveedor {nombre} {apellido} fue registrado con éxito");
        }

        // Método para dar de baja un proveedor existente
        public static void DarDeBajaProveedor(string nombre, string apellido)
        {
            // Buscar el proveedor
            ProveedorModel proveedor = proveedores.Find(p => p.Nombre == nombre && p.Apellido == apellido);

            // Si el proveedor existe y está activo, cambiar su estado a "Inactivo"
            if (proveedor != null && proveedor.Estado == "Activo")
            {
                proveedor.Estado = "Inactivo";
                Console.WriteLine($"El proveedor {nombre} {apellido} fue dado de baja");
            }
            else
            {
                Console.WriteLine("El proveedor no existe o ya se encuentra Inactivo");
            }
        }
    }
}
