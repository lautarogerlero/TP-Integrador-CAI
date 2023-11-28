using Negocio;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Form1
{
    public partial class FormA4S1AgregarProducto : Form
    {
        public FormA4S1AgregarProducto()
        {
            InitializeComponent();
        }
        private void btnConfirmarAgregarProductoNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar y obtener la categoría
                int categoria;
                try
                {
                    ConsolaUtils.ValidateCategoria(txtBoxCategoriaNuevoProducto.Text);
                    categoria = int.Parse(txtBoxCategoriaNuevoProducto.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error en la categoría: " + ex.Message);
                    return;
                }

                // Obtener el nombre del producto
                string nombreProducto = txtBoxNombreNuevoProducto.Text;

                // Validar el precio
                int precio;
                if (!int.TryParse(txtBoxPrecioNuevoProducto.Text, out precio) || precio < 1 || precio > 10000000)
                {
                    MessageBox.Show("Error: El precio debe ser un número entre 1 y 10000000.");
                    return;
                }

                // Validar el stock
                int stock;
                if (!int.TryParse(txtBoxStockNuevoProducto.Text, out stock) || stock < 1 || stock > 10000000)
                {
                    MessageBox.Show("Error: El stock debe ser un número entre 1 y 10000000.");
                    return;
                }

                // Obtener el nombre y apellido del proveedor
                string nombreProveedor = ConsolaUtils.ValidarNombre(txtBoxNombreProovedorNuevoProducto.Text);
                string apellidoProveedor = ConsolaUtils.ValidarNombre(txtBoxApellidoProovedorNuevoProducto.Text);

                // Buscar al proveedor en la base de datos
                JToken proveedor = Proveedor.ObtenerProveedorPorNombre(nombreProveedor, apellidoProveedor);
                if (proveedor == null)
                {
                    MessageBox.Show("El proveedor ingresado no fue encontrado en la base de datos");
                    return;
                }

                // Obtener el ID del proveedor
                string idProveedor = proveedor["id"].ToString();

                // Registrar el producto
                Producto.RegistrarProducto(categoria, idProveedor, nombreProducto, precio, stock);

                // Mostrar mensaje de éxito
                MessageBox.Show("Producto agregado correctamente");
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error general
                MessageBox.Show("Error: No se pudo procesar el agregar un producto nuevo. " + ex.Message);
            }
        }


    }
}
