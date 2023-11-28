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
    public partial class FormA3DarDeBajaProveedor : Form
    {
        public FormA3DarDeBajaProveedor()
        {
            InitializeComponent();
        }

        private void btnConfirmarBajaDeProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = ConsolaUtils.ValidarNombre(txtBoxNombreProovedorADarDeBaja.Text);
                string apellido = ConsolaUtils.ValidarNombre(txtBoxApellidoProovedorADarDeBaja.Text);

                // Intenta dar de baja al proveedor
                Proveedor.DarDeBajaProveedor(nombre, apellido);

                // Si la operación es exitosa, muestra un mensaje al usuario
                MessageBox.Show("El proveedor ha sido dado de baja con éxito.");
            }
            catch (Exception)
            {
                // Si la operación falla, muestra un mensaje al usuario
                MessageBox.Show("No se encontró al proveedor con el nombre y apellido ingresados.");
            }

        }
    }
}
