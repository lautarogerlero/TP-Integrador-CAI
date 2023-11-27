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
            this.lblVentasRealizadasPorCliente = new System.Windows.Forms.Label();
            this.lblClienteConMasVentas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVentasRealizadasPorCliente
            // 
            this.lblVentasRealizadasPorCliente.AutoSize = true;
            this.lblVentasRealizadasPorCliente.Location = new System.Drawing.Point(202, 22);
            this.lblVentasRealizadasPorCliente.Name = "lblVentasRealizadasPorCliente";
            this.lblVentasRealizadasPorCliente.Size = new System.Drawing.Size(367, 15);
            this.lblVentasRealizadasPorCliente.TabIndex = 0;
            this.lblVentasRealizadasPorCliente.Text = "Ventas Realizadas por Cliente, con su ID de venta y Cantidad Vendida";
            // 
            // lblClienteConMasVentas
            // 
            this.lblClienteConMasVentas.AutoSize = true;
            this.lblClienteConMasVentas.Location = new System.Drawing.Point(202, 37);
            this.lblClienteConMasVentas.Name = "lblClienteConMasVentas";
            this.lblClienteConMasVentas.Size = new System.Drawing.Size(159, 15);
            this.lblClienteConMasVentas.TabIndex = 1;
            this.lblClienteConMasVentas.Text = "El cliente con mas ventas es: ";
            // 
            // FormA8VentasPorClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblClienteConMasVentas);
            this.Controls.Add(this.lblVentasRealizadasPorCliente);
            this.Name = "FormA8VentasPorClientes";
            this.Text = "FormA8VentasPorClientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblVentasRealizadasPorCliente;
        private Label lblClienteConMasVentas;
    }
}