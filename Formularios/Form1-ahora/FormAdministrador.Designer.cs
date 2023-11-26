namespace Form1
{
    partial class FormAdministrador
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
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.bntRegistrarProveedor = new System.Windows.Forms.Button();
            this.btnDarDeBajaProveedor = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnRegistrarCliente = new System.Windows.Forms.Button();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.btnVerStockCritico = new System.Windows.Forms.Button();
            this.btnVentasPorClientes = new System.Windows.Forms.Button();
            this.btnProdMasVendidosPorCategoria = new System.Windows.Forms.Button();
            this.lblAdministrador = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(33, 45);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(122, 38);
            this.btnAgregarUsuario.TabIndex = 0;
            this.btnAgregarUsuario.Text = "1. Agregar Usuario";
            this.btnAgregarUsuario.UseVisualStyleBackColor = true;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // bntRegistrarProveedor
            // 
            this.bntRegistrarProveedor.Location = new System.Drawing.Point(33, 103);
            this.bntRegistrarProveedor.Name = "bntRegistrarProveedor";
            this.bntRegistrarProveedor.Size = new System.Drawing.Size(122, 43);
            this.bntRegistrarProveedor.TabIndex = 1;
            this.bntRegistrarProveedor.Text = "2. Registrar Proveedor";
            this.bntRegistrarProveedor.UseVisualStyleBackColor = true;
            this.bntRegistrarProveedor.Click += new System.EventHandler(this.bntRegistrarProveedor_Click);
            // 
            // btnDarDeBajaProveedor
            // 
            this.btnDarDeBajaProveedor.Location = new System.Drawing.Point(33, 169);
            this.btnDarDeBajaProveedor.Name = "btnDarDeBajaProveedor";
            this.btnDarDeBajaProveedor.Size = new System.Drawing.Size(122, 40);
            this.btnDarDeBajaProveedor.TabIndex = 2;
            this.btnDarDeBajaProveedor.Text = "3. Dar de Baja Proveedor";
            this.btnDarDeBajaProveedor.UseVisualStyleBackColor = true;
            this.btnDarDeBajaProveedor.Click += new System.EventHandler(this.btnDarDeBajaProveedor_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(207, 45);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(122, 38);
            this.btnAgregarProducto.TabIndex = 3;
            this.btnAgregarProducto.Text = "4. Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnRegistrarCliente
            // 
            this.btnRegistrarCliente.Location = new System.Drawing.Point(207, 103);
            this.btnRegistrarCliente.Name = "btnRegistrarCliente";
            this.btnRegistrarCliente.Size = new System.Drawing.Size(122, 43);
            this.btnRegistrarCliente.TabIndex = 4;
            this.btnRegistrarCliente.Text = "5. Registrar Cliente";
            this.btnRegistrarCliente.UseVisualStyleBackColor = true;
            this.btnRegistrarCliente.Click += new System.EventHandler(this.btnRegistrarCliente_Click);
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.Location = new System.Drawing.Point(207, 169);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(122, 40);
            this.btnModificarCliente.TabIndex = 5;
            this.btnModificarCliente.Text = "6. Modificar Cliente";
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // btnVerStockCritico
            // 
            this.btnVerStockCritico.Location = new System.Drawing.Point(379, 45);
            this.btnVerStockCritico.Name = "btnVerStockCritico";
            this.btnVerStockCritico.Size = new System.Drawing.Size(122, 38);
            this.btnVerStockCritico.TabIndex = 6;
            this.btnVerStockCritico.Text = "7. Ver Stock Critico";
            this.btnVerStockCritico.UseVisualStyleBackColor = true;
            this.btnVerStockCritico.Click += new System.EventHandler(this.btnVerStockCritico_Click);
            // 
            // btnVentasPorClientes
            // 
            this.btnVentasPorClientes.Location = new System.Drawing.Point(379, 103);
            this.btnVentasPorClientes.Name = "btnVentasPorClientes";
            this.btnVentasPorClientes.Size = new System.Drawing.Size(122, 43);
            this.btnVentasPorClientes.TabIndex = 7;
            this.btnVentasPorClientes.Text = "8. Ventas Por Clientes";
            this.btnVentasPorClientes.UseVisualStyleBackColor = true;
            this.btnVentasPorClientes.Click += new System.EventHandler(this.btnVentasPorClientes_Click);
            // 
            // btnProdMasVendidosPorCategoria
            // 
            this.btnProdMasVendidosPorCategoria.Location = new System.Drawing.Point(379, 169);
            this.btnProdMasVendidosPorCategoria.Name = "btnProdMasVendidosPorCategoria";
            this.btnProdMasVendidosPorCategoria.Size = new System.Drawing.Size(122, 40);
            this.btnProdMasVendidosPorCategoria.TabIndex = 8;
            this.btnProdMasVendidosPorCategoria.Text = "9. Prod. mas Vendidos por Cat.";
            this.btnProdMasVendidosPorCategoria.UseVisualStyleBackColor = true;
            this.btnProdMasVendidosPorCategoria.Click += new System.EventHandler(this.btnProdMasVendidosPorCategoria_Click);
            // 
            // lblAdministrador
            // 
            this.lblAdministrador.AutoSize = true;
            this.lblAdministrador.Location = new System.Drawing.Point(12, 9);
            this.lblAdministrador.Name = "lblAdministrador";
            this.lblAdministrador.Size = new System.Drawing.Size(150, 13);
            this.lblAdministrador.TabIndex = 9;
            this.lblAdministrador.Text = "Logueado como Administrador";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(449, 243);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(89, 20);
            this.btnCerrarSesion.TabIndex = 10;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 275);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblAdministrador);
            this.Controls.Add(this.btnProdMasVendidosPorCategoria);
            this.Controls.Add(this.btnVentasPorClientes);
            this.Controls.Add(this.btnVerStockCritico);
            this.Controls.Add(this.btnModificarCliente);
            this.Controls.Add(this.btnRegistrarCliente);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnDarDeBajaProveedor);
            this.Controls.Add(this.bntRegistrarProveedor);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Name = "FormAdministrador";
            this.Text = "FormAdministrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.Button bntRegistrarProveedor;
        private System.Windows.Forms.Button btnDarDeBajaProveedor;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnRegistrarCliente;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Button btnVerStockCritico;
        private System.Windows.Forms.Button btnVentasPorClientes;
        private System.Windows.Forms.Button btnProdMasVendidosPorCategoria;
        private System.Windows.Forms.Label lblAdministrador;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}