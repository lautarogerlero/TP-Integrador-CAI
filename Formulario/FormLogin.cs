using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string idUsuario = Login.IniciarSesion(txtUsuario.Text, txtContraseña.Text);

            if (!string.IsNullOrEmpty(idUsuario))
            {
                // Iniciar sesión exitoso
                MessageBox.Show("Inicio de sesión exitoso");
                // Puedes abrir el formulario principal o realizar otras acciones necesarias.
            }
            else
            {
                // Iniciar sesión fallido
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }
        }

        private void textUsuario_Enter(object sender, EventArgs e)
        {

        }

        private void textUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
