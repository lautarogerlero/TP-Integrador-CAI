namespace Formularios
{
    partial class FormSupervisor
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
            this.lblLogueadoComoSupervisor = new System.Windows.Forms.Label();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnDevolverVenta = new System.Windows.Forms.Button();
            this.btnVentasPorClientes = new System.Windows.Forms.Button();
            this.btnProductosMasVendidosPorCategoria = new System.Windows.Forms.Button();
            this.btnMostrarStockCritico = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLogueadoComoSupervisor
            // 
            this.lblLogueadoComoSupervisor.AutoSize = true;
            this.lblLogueadoComoSupervisor.Location = new System.Drawing.Point(12, 9);
            this.lblLogueadoComoSupervisor.Name = "lblLogueadoComoSupervisor";
            this.lblLogueadoComoSupervisor.Size = new System.Drawing.Size(154, 15);
            this.lblLogueadoComoSupervisor.TabIndex = 0;
            this.lblLogueadoComoSupervisor.Text = "Logueado Como Supervisor";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(56, 42);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(151, 36);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "1. Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnDevolverVenta
            // 
            this.btnDevolverVenta.Location = new System.Drawing.Point(56, 84);
            this.btnDevolverVenta.Name = "btnDevolverVenta";
            this.btnDevolverVenta.Size = new System.Drawing.Size(151, 36);
            this.btnDevolverVenta.TabIndex = 2;
            this.btnDevolverVenta.Text = "2. Devolver Venta";
            this.btnDevolverVenta.UseVisualStyleBackColor = true;
            this.btnDevolverVenta.Click += new System.EventHandler(this.btnDevolverVenta_Click);
            // 
            // btnVentasPorClientes
            // 
            this.btnVentasPorClientes.Location = new System.Drawing.Point(241, 42);
            this.btnVentasPorClientes.Name = "btnVentasPorClientes";
            this.btnVentasPorClientes.Size = new System.Drawing.Size(161, 50);
            this.btnVentasPorClientes.TabIndex = 3;
            this.btnVentasPorClientes.Text = "4. Mostrar Ventas por Clientes";
            this.btnVentasPorClientes.UseVisualStyleBackColor = true;
            this.btnVentasPorClientes.Click += new System.EventHandler(this.btnVentasPorClientes_Click);
            // 
            // btnProductosMasVendidosPorCategoria
            // 
            this.btnProductosMasVendidosPorCategoria.Location = new System.Drawing.Point(241, 112);
            this.btnProductosMasVendidosPorCategoria.Name = "btnProductosMasVendidosPorCategoria";
            this.btnProductosMasVendidosPorCategoria.Size = new System.Drawing.Size(161, 50);
            this.btnProductosMasVendidosPorCategoria.TabIndex = 4;
            this.btnProductosMasVendidosPorCategoria.Text = "5. Productos Mas Vendidos Por Categoria";
            this.btnProductosMasVendidosPorCategoria.UseVisualStyleBackColor = true;
            this.btnProductosMasVendidosPorCategoria.Click += new System.EventHandler(this.btnProductosMasVendidosPorCategoria_Click);
            // 
            // btnMostrarStockCritico
            // 
            this.btnMostrarStockCritico.Location = new System.Drawing.Point(56, 126);
            this.btnMostrarStockCritico.Name = "btnMostrarStockCritico";
            this.btnMostrarStockCritico.Size = new System.Drawing.Size(151, 36);
            this.btnMostrarStockCritico.TabIndex = 5;
            this.btnMostrarStockCritico.Text = "3. Mostrar Stock Critico";
            this.btnMostrarStockCritico.UseVisualStyleBackColor = true;
            this.btnMostrarStockCritico.Click += new System.EventHandler(this.btnMostrarStockCritico_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(327, 196);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(133, 36);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FormSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 244);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnMostrarStockCritico);
            this.Controls.Add(this.btnProductosMasVendidosPorCategoria);
            this.Controls.Add(this.btnVentasPorClientes);
            this.Controls.Add(this.btnDevolverVenta);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.lblLogueadoComoSupervisor);
            this.Name = "FormSupervisor";
            this.Text = "FormSupervisor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblLogueadoComoSupervisor;
        private Button btnAgregarProducto;
        private Button btnDevolverVenta;
        private Button btnVentasPorClientes;
        private Button btnProductosMasVendidosPorCategoria;
        private Button btnMostrarStockCritico;
        private Button btnCerrarSesion;
    }
}