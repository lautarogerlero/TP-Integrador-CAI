using Negocio;
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
    public partial class FormA2RegistrarProveedor : Form
    {
        public FormA2RegistrarProveedor()
        {
            InitializeComponent();
        }

        private void btnConfirmarUsuarioNuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmarProveedorNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = ConsolaUtils.ValidarNombre(txtBoxNombreProovedorNuevo.Text);
                string apellido = ConsolaUtils.ValidarNombre(txtBoxApellidoProovedorNuevo.Text);
                string email = ConsolaUtils.ValidarEmail(txtBoxEmailProovedorNuevo.Text);
                long cuit = ConsolaUtils.ValidateCUIT(txtBoxCUITProovedorNuevo.Text);
                
                

                string cuitTexto = cuit.ToString();
                

                // Registro del proveedor
                Proveedor.RegistrarProveedor(nombre, apellido, email, cuitTexto);

                // Si todas las operaciones son exitosas, muestra un mensaje al usuario
                MessageBox.Show("Proveedor registrado exitosamente");
            }
            catch (FormatException ex)
            {
                // Si alguna operación falla, muestra un mensaje al usuario
                MessageBox.Show("No se pudo registrar al proveedor: " + ex.Message);
            }

        }
    }
}