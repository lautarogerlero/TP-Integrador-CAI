using Modelo;
using Negocio;
using Utils;

namespace Formularios
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

        }

        private void LogIn(object sender, EventArgs e)
        {
            string nombreUsuario = txtBoxUsuarioLogin.Text;
            string contraseña = txtBoxContraseñaLogin.Text;

            Login login = new Login();
            Dictionary<string, int> intentosPorUsuario = new Dictionary<string, int>();
            string idUsuario = "";
            
            login.NombreUsuario = nombreUsuario;
            login.Contraseña = contraseña;

            try
            {
                idUsuario = Usuario.LogIn(login, nombreUsuario, contraseña);
                MessageBox.Show("Login exitoso");
                // Si el inicio de sesión es exitoso, restablece el contador de intentos fallidos.
                intentosPorUsuario.Remove(login.NombreUsuario);

                // Crea una instancia de Form2 pasando el valor de idUsuario al constructor
                FrmVendedor frmVendedor = new FrmVendedor();

                // Oculta el formulario actual
                this.Hide();

                // Muestra el nuevo formulario
                frmVendedor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                // Incrementa el contador de intentos fallidos para este NombreUsuario.
                if (intentosPorUsuario.ContainsKey(login.NombreUsuario))
                {
                    intentosPorUsuario[login.NombreUsuario]++;
                }
                else
                {
                    intentosPorUsuario[login.NombreUsuario] = 1;
                }
                MessageBox.Show($"Le queda/n {3 - intentosPorUsuario[login.NombreUsuario]} intento/s");
                // Verifica si el usuario ha superado el número máximo de intentos permitidos. Si lo superó, borra al usuario
                if (intentosPorUsuario[login.NombreUsuario] >= 3)
                {
                    MessageBox.Show("Alcanzó el límite de intentos. Su usuario ha sido bloqueado");
                    //string idABorrar = ObtenerIdUsuario(login.NombreUsuario);
                    //BorrarUsuario(idABorrar);
                    //nombreUsuario = "";
                    //break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}