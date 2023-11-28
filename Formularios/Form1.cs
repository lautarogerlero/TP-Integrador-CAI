using Form1;
using Negocio;

namespace Formularios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, EventArgs e)
        {
            // Realizar validaciones de datos del usuario y contraseña
            String usuario = textUsuario.Text;
            String password = textPassword.Text;

            if (!(usuario.Length > 0 && password.Length > 0))
            {
                MessageBox.Show("Debe de ingresar un usuario y contraseña correcto");
            }

            // Hacer el login
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            String idUsuario = usuarioNegocio.LogIn(usuario, password).Replace("\"", "");

            // Obtener el perfil
            int perfil = usuarioNegocio.ObtenerPerfil(idUsuario);

            // Ir al formulario que corresponde
            this.Hide();
            if (perfil == 1)
            {
                FormAdministrador formAdministrador = new FormAdministrador();
                formAdministrador.ShowDialog();
            }
            else if (perfil == 2) { 
                FormVendedor formVendedor = new FormVendedor();
                formVendedor.ShowDialog();
            }
            else
            {
                FormSupervisor formSupervisor = new FormSupervisor();
                formSupervisor.ShowDialog();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}