namespace Form1
{
    partial class FormVendedor
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
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.btnVentasPorClientes = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Location = new System.Drawing.Point(213, 70);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(111, 31);
            this.btnRegistrarVenta.TabIndex = 0;
            this.btnRegistrarVenta.Text = "Registrar Venta4444";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            // 
            // btnVentasPorClientes
            // 
            this.btnVentasPorClientes.Location = new System.Drawing.Point(213, 137);
            this.btnVentasPorClientes.Name = "btnVentasPorClientes";
            this.btnVentasPorClientes.Size = new System.Drawing.Size(111, 31);
            this.btnVentasPorClientes.TabIndex = 1;
            this.btnVentasPorClientes.Text = "Ventas por Clientes";
            this.btnVentasPorClientes.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(413, 206);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(106, 22);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(12, 9);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(133, 13);
            this.lblVendedor.TabIndex = 3;
            this.lblVendedor.Text = "Logueado como Vendedor";
            // 
            // FormVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 240);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnVentasPorClientes);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Name = "FormVendedor";
            this.Text = "FormVendedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.Button btnVentasPorClientes;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblVendedor;
    }
}