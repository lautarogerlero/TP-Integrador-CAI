using Modelo;
using Negocio;
using Utils;

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
            string nombreUsuario = textBox1.Text;
            string contrase�a = textBox2.Text;

            Login login = new Login();
            Dictionary<string, int> intentosPorUsuario = new Dictionary<string, int>();
            string idUsuario = "";
            
            login.NombreUsuario = nombreUsuario;
            login.Contrase�a = contrase�a;

            try
            {
                idUsuario = Usuario.LogIn(login, nombreUsuario, contrase�a);
                MessageBox.Show("Login exitoso");
                // Si el inicio de sesi�n es exitoso, restablece el contador de intentos fallidos.
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
                MessageBox.Show("Usuario o contrase�a incorrectos");
                // Incrementa el contador de intentos fallidos para este NombreUsuario.
                if (intentosPorUsuario.ContainsKey(login.NombreUsuario))
                {
                    intentosPorUsuario[login.NombreUsuario]++;
                }
                else
                {
                    intentosPorUsuario[login.NombreUsuario] = 1;
                }
                Console.WriteLine($"Le queda/n {3 - intentosPorUsuario[login.NombreUsuario]} intento/s");
                // Verifica si el usuario ha superado el n�mero m�ximo de intentos permitidos. Si lo super�, borra al usuario
                if (intentosPorUsuario[login.NombreUsuario] >= 3)
                {
                    MessageBox.Show("Alcanz� el l�mite de intentos. Su usuario ha sido bloqueado");
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