namespace Form1
{
    partial class FormA3DarDeBajaProveedor
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
            this.lblApellidoProveedorABorrar = new System.Windows.Forms.Label();
            this.lblNombreProveedorABorrar = new System.Windows.Forms.Label();
            this.txtBoxApellidoUsuarioNuevo = new System.Windows.Forms.TextBox();
            this.txtBoxNombreUsuarioNuevo = new System.Windows.Forms.TextBox();
            this.btnConfirmarBajaDeProveedor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblApellidoProveedorABorrar
            // 
            this.lblApellidoProveedorABorrar.AutoSize = true;
            this.lblApellidoProveedorABorrar.Location = new System.Drawing.Point(85, 168);
            this.lblApellidoProveedorABorrar.Name = "lblApellidoProveedorABorrar";
            this.lblApellidoProveedorABorrar.Size = new System.Drawing.Size(92, 13);
            this.lblApellidoProveedorABorrar.TabIndex = 27;
            this.lblApellidoProveedorABorrar.Text = "Ingrese el apellido";
            // 
            // lblNombreProveedorABorrar
            // 
            this.lblNombreProveedorABorrar.AutoSize = true;
            this.lblNombreProveedorABorrar.Location = new System.Drawing.Point(85, 129);
            this.lblNombreProveedorABorrar.Name = "lblNombreProveedorABorrar";
            this.lblNombreProveedorABorrar.Size = new System.Drawing.Size(91, 13);
            this.lblNombreProveedorABorrar.TabIndex = 26;
            this.lblNombreProveedorABorrar.Text = "Ingrese el nombre";
            // 
            // txtBoxApellidoUsuarioNuevo
            // 
            this.txtBoxApellidoUsuarioNuevo.Location = new System.Drawing.Point(315, 168);
            this.txtBoxApellidoUsuarioNuevo.Name = "txtBoxApellidoUsuarioNuevo";
            this.txtBoxApellidoUsuarioNuevo.Size = new System.Drawing.Size(117, 20);
            this.txtBoxApellidoUsuarioNuevo.TabIndex = 25;
            // 
            // txtBoxNombreUsuarioNuevo
            // 
            this.txtBoxNombreUsuarioNuevo.Location = new System.Drawing.Point(315, 126);
            this.txtBoxNombreUsuarioNuevo.Name = "txtBoxNombreUsuarioNuevo";
            this.txtBoxNombreUsuarioNuevo.Size = new System.Drawing.Size(117, 20);
            this.txtBoxNombreUsuarioNuevo.TabIndex = 24;
            // 
            // btnConfirmarBajaDeProveedor
            // 
            this.btnConfirmarBajaDeProveedor.Location = new System.Drawing.Point(342, 275);
            this.btnConfirmarBajaDeProveedor.Name = "btnConfirmarBajaDeProveedor";
            this.btnConfirmarBajaDeProveedor.Size = new System.Drawing.Size(163, 28);
            this.btnConfirmarBajaDeProveedor.TabIndex = 32;
            this.btnConfirmarBajaDeProveedor.Text = "Confirmar Baja de Proveedor";
            this.btnConfirmarBajaDeProveedor.UseVisualStyleBackColor = true;
            this.btnConfirmarBajaDeProveedor.Click += new System.EventHandler(this.btnConfirmarBajaDeProveedor_Click);
            // 
            // FormA3DarDeBajaProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 315);
            this.Controls.Add(this.btnConfirmarBajaDeProveedor);
            this.Controls.Add(this.lblApellidoProveedorABorrar);
            this.Controls.Add(this.lblNombreProveedorABorrar);
            this.Controls.Add(this.txtBoxApellidoUsuarioNuevo);
            this.Controls.Add(this.txtBoxNombreUsuarioNuevo);
            this.Name = "FormA3DarDeBajaProveedor";
            this.Text = "FormA3DarDeBajaProveedor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApellidoProveedorABorrar;
        private System.Windows.Forms.Label lblNombreProveedorABorrar;
        private System.Windows.Forms.TextBox txtBoxApellidoUsuarioNuevo;
        private System.Windows.Forms.TextBox txtBoxNombreUsuarioNuevo;
        private System.Windows.Forms.Button btnConfirmarBajaDeProveedor;
    }
}