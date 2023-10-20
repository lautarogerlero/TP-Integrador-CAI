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
        private List<ProveedorModel> proveedores;

        public Proveedor()
        {
            // Inicializar la lista de proveedores
            proveedores = new List<ProveedorModel>();
        }

        // Método para registrar un nuevo proveedor
        public void RegistrarProveedor(string nombre, string apellido, List<int> categoriasProductos)
        {
            // Crear un nuevo proveedor con un ID único, el nombre, el apellido, el estado "Activo" y las categorías de productos
            ProveedorModel nuevoProveedor = new ProveedorModel(Guid.NewGuid(), nombre, apellido, "Activo", categoriasProductos);

            // Agregar el nuevo proveedor a la lista de proveedores
            proveedores.Add(nuevoProveedor);
        }

        // Método para dar de baja un proveedor existente
        public void DarDeBajaProveedor(Guid id)
        {
            // Buscar el proveedor con el ID dado en la lista de proveedores
            ProveedorModel proveedor = proveedores.Find(p => p.Id == id);

            // Si el proveedor existe y está activo, cambiar su estado a "Inactivo"
            if (proveedor != null && proveedor.Estado == "Activo")
            {
                proveedor.Estado = "Inactivo";
            }
        }
    }
}

