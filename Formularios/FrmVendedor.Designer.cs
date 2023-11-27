namespace Formularios
{
    partial class FrmVendedor
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
            this.btnVerVentasPorClientes = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVerVentasPorClientes
            // 
            this.btnVerVentasPorClientes.Location = new System.Drawing.Point(322, 113);
            this.btnVerVentasPorClientes.Name = "btnVerVentasPorClientes";
            this.btnVerVentasPorClientes.Size = new System.Drawing.Size(127, 32);
            this.btnVerVentasPorClientes.TabIndex = 5;
            this.btnVerVentasPorClientes.Text = "2. Ventas por Clientes";
            this.btnVerVentasPorClientes.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Location = new System.Drawing.Point(79, 113);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(125, 32);
            this.btnRegistrarVenta.TabIndex = 4;
            this.btnRegistrarVenta.Text = "1. Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Logueado Como Vendedor";
            // 
            // FrmVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 247);
            this.Controls.Add(this.btnVerVentasPorClientes);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmVendedor";
            this.Text = "FrmVendedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnVerVentasPorClientes;
        private Button btnRegistrarVenta;
        private Label label1;
    }
}