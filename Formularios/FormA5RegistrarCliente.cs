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

namespace Formularios
{
    public partial class FormA5RegistrarCliente : Form
    {
        public FormA5RegistrarCliente()
        {
            InitializeComponent();
        }

        private void btnConfirmarClienteNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                string id = "D347CE99-DB8D-4542-AA97-FC9F3CCE6969";
                string nombre = ValidarTextBox("Nombre", txtBoxNombreClienteNuevo);
                string apellido = ValidarTextBox("Apellido", txtBoxApellidoUsuarioNuevo);
                string direccion = PedirString("Dirección", txtBoxDireccionClienteNuevo);
                string telefono = ValidarTelefono(txtBoxTelefonoClienteNuevo.Text);
                string email = ValidarEmail(txtBoxEmailUsuarioNuevo.Text);
                DateTime fechaNacimiento = ValidarFechaNacimiento(txtBoxFechaNacimientoClienteNuevo.Text);
                string host = PedirString("Host", txtBoxHostClienteNuevo);
                int dni = ValidarDni(txtBoxDNIUsuarioNuevo.Text);

                Cliente.CrearCliente(id, nombre, apellido, direccion, telefono, email, fechaNacimiento, host, dni);

                MessageBox.Show("Cliente agregado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo procesar la creación del cliente. " + ex.Message);
            }
        }

        public string ValidarTextBox(string nombreCampo, TextBox textBox)
        {
            string valor = PedirString($"Ingrese {nombreCampo}", textBox);
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException($"{nombreCampo} no puede estar vacío");
            }

            return valor;
        }

        private string PedirString(string mensaje, TextBox textBox)
        {
            string valor = textBox.Text.Trim();
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException($"Error: {mensaje} no puede estar vacío.");
            }

            return valor;
        }

        private string ValidarTelefono(string telefono)
        {
            if (telefono.Length != 8)
            {
                throw new FormatException("El número de teléfono debe tener exactamente 8 dígitos.");
            }

            return telefono;
        }

        private string ValidarEmail(string email)
        {
            if (!email.Contains("@") || !email.EndsWith(".com"))
            {
                throw new FormatException("El correo electrónico debe contener un arroba (@) y terminar en .com.");
            }

            return email;
        }

        private DateTime ValidarFechaNacimiento(string fechaNacimientoText)
        {
            if (!DateTime.TryParseExact(fechaNacimientoText, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaNacimiento))
            {
                throw new FormatException("La fecha proporcionada no tiene el formato correcto (dd/MM/yyyy)");
            }

            return fechaNacimiento;
        }

        private int ValidarDni(string dniText)
        {
            if (!int.TryParse(dniText, out int dni) || dni < 0 || dni > 100000000)
            {
                throw new FormatException("El valor ingresado para DNI debe estar entre 0 y 100 millones.");
            }

            return dni;
        }
    }
}
