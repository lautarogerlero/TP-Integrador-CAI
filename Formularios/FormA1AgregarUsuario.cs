using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Form1
{
    public partial class FormA1AgregarUsuario : Form
    {
        public FormA1AgregarUsuario()
        {
            InitializeComponent();
        }

        private void btnConfirmarUsuarioNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
                string nombre = txtBoxNombreUsuarioNuevo.Text;
                string apellido = txtBoxApellidoUsuarioNuevo.Text;
                string direccion = txtBoxDireccionUsuarioNuevo.Text;
                string telefono = txtBoxTelefonoUsuarioNuevo.Text;
                string email = txtBoxEmailUsuarioNuevo.Text;

                ConsolaUtils.ValidateTelefono(telefono);
                ConsolaUtils.ValidateEmail(email);
                DateTime fechaNacimiento = ConsolaUtils.ValidateFechaNacimiento(txtBoxFechaNacUsuarioAAgregar.Text);
                int host = ConsolaUtils.ValidateHost(txtBoxHostUsuarioNuevo.Text);
                int dni = ConsolaUtils.ValidateDNI(txtBoxDNIUsuarioNuevo.Text);
                ConsolaUtils.ValidateUsuario(nombre, apellido, txtBoxNombreUsuarioNuevo.Text);

                Usuario.CrearUsuario(id, nombre, apellido, direccion, telefono, email, fechaNacimiento, txtBoxNombreUsuarioNuevo.Text, host, dni);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alguno de los datos ingresados no es correcto: " + ex.Message);
            }
        }
    }


  
    
}
