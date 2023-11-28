namespace Formularios
{
    partial class FormA8V2S4VentasPorClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblVentasRealizadasPorCliente = new Label();
            lblClienteConMasVentas = new Label();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // lblVentasRealizadasPorCliente
            // 
            lblVentasRealizadasPorCliente.AutoSize = true;
            lblVentasRealizadasPorCliente.Location = new Point(375, 47);
            lblVentasRealizadasPorCliente.Margin = new Padding(6, 0, 6, 0);
            lblVentasRealizadasPorCliente.Name = "lblVentasRealizadasPorCliente";
            lblVentasRealizadasPorCliente.Size = new Size(751, 32);
            lblVentasRealizadasPorCliente.TabIndex = 0;
            lblVentasRealizadasPorCliente.Text = "Ventas Realizadas por Cliente, con su ID de venta y Cantidad Vendida";
            // 
            // lblClienteConMasVentas
            // 
            lblClienteConMasVentas.AutoSize = true;
            lblClienteConMasVentas.Location = new Point(375, 79);
            lblClienteConMasVentas.Margin = new Padding(6, 0, 6, 0);
            lblClienteConMasVentas.Name = "lblClienteConMasVentas";
            lblClienteConMasVentas.Size = new Size(324, 32);
            lblClienteConMasVentas.TabIndex = 1;
            lblClienteConMasVentas.Text = "El cliente con mas ventas es: ";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(72, 150);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(814, 740);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // FormA8V2S4VentasPorClientes
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 960);
            Controls.Add(listBox1);
            Controls.Add(lblClienteConMasVentas);
            Controls.Add(lblVentasRealizadasPorCliente);
            Margin = new Padding(6, 6, 6, 6);
            Name = "FormA8V2S4VentasPorClientes";
            Text = "FormA8VentasPorClientes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVentasRealizadasPorCliente;
        private Label lblClienteConMasVentas;
        private ListBox listBox1;
    }
}