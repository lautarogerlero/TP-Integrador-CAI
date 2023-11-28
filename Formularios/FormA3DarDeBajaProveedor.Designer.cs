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
            lblApellidoProveedorABorrar = new Label();
            lblNombreProveedorABorrar = new Label();
            txtBoxApellidoProovedorADarDeBaja = new TextBox();
            txtBoxNombreProovedorADarDeBaja = new TextBox();
            btnConfirmarBajaDeProveedor = new Button();
            lblDarDeBajaUnProveedor = new Label();
            SuspendLayout();
            // 
            // lblApellidoProveedorABorrar
            // 
            lblApellidoProveedorABorrar.AutoSize = true;
            lblApellidoProveedorABorrar.Location = new Point(184, 414);
            lblApellidoProveedorABorrar.Margin = new Padding(6, 0, 6, 0);
            lblApellidoProveedorABorrar.Name = "lblApellidoProveedorABorrar";
            lblApellidoProveedorABorrar.Size = new Size(210, 32);
            lblApellidoProveedorABorrar.TabIndex = 27;
            lblApellidoProveedorABorrar.Text = "Ingrese el apellido";
            // 
            // lblNombreProveedorABorrar
            // 
            lblNombreProveedorABorrar.AutoSize = true;
            lblNombreProveedorABorrar.Location = new Point(184, 318);
            lblNombreProveedorABorrar.Margin = new Padding(6, 0, 6, 0);
            lblNombreProveedorABorrar.Name = "lblNombreProveedorABorrar";
            lblNombreProveedorABorrar.Size = new Size(209, 32);
            lblNombreProveedorABorrar.TabIndex = 26;
            lblNombreProveedorABorrar.Text = "Ingrese el nombre";
            // 
            // txtBoxApellidoProovedorADarDeBaja
            // 
            txtBoxApellidoProovedorADarDeBaja.Location = new Point(682, 414);
            txtBoxApellidoProovedorADarDeBaja.Margin = new Padding(6, 7, 6, 7);
            txtBoxApellidoProovedorADarDeBaja.Name = "txtBoxApellidoProovedorADarDeBaja";
            txtBoxApellidoProovedorADarDeBaja.Size = new Size(249, 39);
            txtBoxApellidoProovedorADarDeBaja.TabIndex = 25;
            // 
            // txtBoxNombreProovedorADarDeBaja
            // 
            txtBoxNombreProovedorADarDeBaja.Location = new Point(682, 310);
            txtBoxNombreProovedorADarDeBaja.Margin = new Padding(6, 7, 6, 7);
            txtBoxNombreProovedorADarDeBaja.Name = "txtBoxNombreProovedorADarDeBaja";
            txtBoxNombreProovedorADarDeBaja.Size = new Size(249, 39);
            txtBoxNombreProovedorADarDeBaja.TabIndex = 24;
            // 
            // btnConfirmarBajaDeProveedor
            // 
            btnConfirmarBajaDeProveedor.Location = new Point(741, 677);
            btnConfirmarBajaDeProveedor.Margin = new Padding(6, 7, 6, 7);
            btnConfirmarBajaDeProveedor.Name = "btnConfirmarBajaDeProveedor";
            btnConfirmarBajaDeProveedor.Size = new Size(353, 69);
            btnConfirmarBajaDeProveedor.TabIndex = 32;
            btnConfirmarBajaDeProveedor.Text = "Confirmar Baja de Proveedor";
            btnConfirmarBajaDeProveedor.UseVisualStyleBackColor = true;
            btnConfirmarBajaDeProveedor.Click += btnConfirmarBajaDeProveedor_Click;
            // 
            // lblDarDeBajaUnProveedor
            // 
            lblDarDeBajaUnProveedor.AutoSize = true;
            lblDarDeBajaUnProveedor.Location = new Point(429, 94);
            lblDarDeBajaUnProveedor.Margin = new Padding(6, 0, 6, 0);
            lblDarDeBajaUnProveedor.Name = "lblDarDeBajaUnProveedor";
            lblDarDeBajaUnProveedor.Size = new Size(287, 32);
            lblDarDeBajaUnProveedor.TabIndex = 33;
            lblDarDeBajaUnProveedor.Text = "Dar de baja un Proveedor";
            // 
            // FormA3DarDeBajaProveedor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 775);
            Controls.Add(lblDarDeBajaUnProveedor);
            Controls.Add(btnConfirmarBajaDeProveedor);
            Controls.Add(lblApellidoProveedorABorrar);
            Controls.Add(lblNombreProveedorABorrar);
            Controls.Add(txtBoxApellidoProovedorADarDeBaja);
            Controls.Add(txtBoxNombreProovedorADarDeBaja);
            Margin = new Padding(6, 7, 6, 7);
            Name = "FormA3DarDeBajaProveedor";
            Text = "FormA3DarDeBajaProveedor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblApellidoProveedorABorrar;
        private Label lblNombreProveedorABorrar;
        private TextBox txtBoxApellidoProovedorADarDeBaja;
        private TextBox txtBoxNombreProovedorADarDeBaja;
        private Button btnConfirmarBajaDeProveedor;
        private Label lblDarDeBajaUnProveedor;
    }
}