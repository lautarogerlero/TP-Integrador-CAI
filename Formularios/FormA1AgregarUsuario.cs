using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    // Pedir los atributos que necesita el usuario para ser creado
                    string id = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
                    string nombre = txtBoxNombreUsuarioNuevo.Text;
                    string apellido = txtBoxApellidoUsuarioNuevo.Text;
                    string direccion = txtBoxDireccionUsuarioNuevo.Text;
                    string telefono = txtBoxTelefonoUsuarioNuevo.Text;
                    string email = txtBoxEmailUsuarioNuevo.Text;
                
                    // Usando DateTime.TryParseExact
                    DateTime fechaNacimiento;
                    if (DateTime.TryParseExact(txtBoxFechaNacUsuarioAAgregar.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
                    {
                        txtBoxFechaNacUsuarioAAgregar.Text = fechaNacimiento.ToString();
                    }
                    else
                    {
                        // La conversión falló
                        MessageBox.Show("La fecha proporcionada no tiene el formato correcto (dd/MM/yyyy)");
                        return;
                    }
                
                    // Intenta convertir el valor de host a int
                    int host;
                    if (!int.TryParse(txtBoxHostUsuarioNuevo.Text, out host))
                    {
                        MessageBox.Show("El valor ingresado para host no es un número válido.");
                        return;
                    }
                
                    // Verifica si el host es 2 o 3
                    if (host != 2 && host != 3)
                    {
                        MessageBox.Show("El valor ingresado para host debe ser 2 o 3.");
                        return;
                    }
                
                    // Si la conversión es exitosa y el host es 2 o 3, asigna el valor
                    txtBoxHostUsuarioNuevo.Text = host.ToString();
                
                    // Obtén el texto del TextBox
                
                
                    // Intenta convertir el valor de host a int
                    int dni;
                    if (!int.TryParse(txtBoxDNIUsuarioNuevo.Text, out dni))
                    {
                        MessageBox.Show("El valor ingresado para DNI no es un número válido.");
                        return;
                    }
                    if (dni < 0 || dni > 100000000)
                    {
                        MessageBox.Show("El valor ingresado para DNI debe estar entre 0 y 100 millones.");
                        return;
                    }
                    string usuario = txtBoxNombreUsuarioNuevo.Text;
                    if (usuario.Length < 8 || usuario.Length > 15)
                    {
                        MessageBox.Show("El nombre de usuario debe tener entre 8 y 15 caracteres.");
                        return;
                    }
                
                    // Verifica si el usuario contiene el nombre o el apellido
                    if (usuario.Contains(nombre) || usuario.Contains(apellido))
                    {
                        MessageBox.Show("El nombre de usuario no puede contener el nombre ni el apellido.");
                        return;
                    }
                  
                    Usuario.CrearUsuario(id, nombre, apellido, direccion, telefono, email, fechaNacimiento, usuario, host, dni);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Alguno de los datos ingresados no es correcto");
                }
                        }
                
                        private void FormA1AgregarUsuario_Load(object sender, EventArgs e)
                        {
                
                        }
                    }
}
