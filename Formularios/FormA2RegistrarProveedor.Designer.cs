namespace Form1
{
    partial class FormA2RegistrarProveedor
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
            txtBoxCUITProovedorNuevo = new TextBox();
            lblCUITProveedorNuevo = new Label();
            lblEmailProveedorNuevo = new Label();
            lblApellidoProveedorNuevo = new Label();
            lblNombreProveedorNuevo = new Label();
            txtBoxApellidoProovedorNuevo = new TextBox();
            txtBoxEmailProovedorNuevo = new TextBox();
            txtBoxNombreProovedorNuevo = new TextBox();
            btnConfirmarUsuarioNuevo = new Button();
            SuspendLayout();
            // 
            // txtBoxCUITProovedorNuevo
            // 
            txtBoxCUITProovedorNuevo.Location = new Point(732, 485);
            txtBoxCUITProovedorNuevo.Margin = new Padding(6, 7, 6, 7);
            txtBoxCUITProovedorNuevo.Name = "txtBoxCUITProovedorNuevo";
            txtBoxCUITProovedorNuevo.Size = new Size(249, 39);
            txtBoxCUITProovedorNuevo.TabIndex = 30;
            // 
            // lblCUITProveedorNuevo
            // 
            lblCUITProveedorNuevo.AutoSize = true;
            lblCUITProveedorNuevo.Location = new Point(234, 492);
            lblCUITProveedorNuevo.Margin = new Padding(6, 0, 6, 0);
            lblCUITProveedorNuevo.Name = "lblCUITProveedorNuevo";
            lblCUITProveedorNuevo.Size = new Size(175, 32);
            lblCUITProveedorNuevo.TabIndex = 29;
            lblCUITProveedorNuevo.Text = "Ingrese el CUIT";
            // 
            // lblEmailProveedorNuevo
            // 
            lblEmailProveedorNuevo.AutoSize = true;
            lblEmailProveedorNuevo.Location = new Point(234, 389);
            lblEmailProveedorNuevo.Margin = new Padding(6, 0, 6, 0);
            lblEmailProveedorNuevo.Name = "lblEmailProveedorNuevo";
            lblEmailProveedorNuevo.Size = new Size(183, 32);
            lblEmailProveedorNuevo.TabIndex = 26;
            lblEmailProveedorNuevo.Text = "Ingrese el email";
            // 
            // lblApellidoProveedorNuevo
            // 
            lblApellidoProveedorNuevo.AutoSize = true;
            lblApellidoProveedorNuevo.Location = new Point(234, 298);
            lblApellidoProveedorNuevo.Margin = new Padding(6, 0, 6, 0);
            lblApellidoProveedorNuevo.Name = "lblApellidoProveedorNuevo";
            lblApellidoProveedorNuevo.Size = new Size(210, 32);
            lblApellidoProveedorNuevo.TabIndex = 23;
            lblApellidoProveedorNuevo.Text = "Ingrese el apellido";
            // 
            // lblNombreProveedorNuevo
            // 
            lblNombreProveedorNuevo.AutoSize = true;
            lblNombreProveedorNuevo.Location = new Point(234, 202);
            lblNombreProveedorNuevo.Margin = new Padding(6, 0, 6, 0);
            lblNombreProveedorNuevo.Name = "lblNombreProveedorNuevo";
            lblNombreProveedorNuevo.Size = new Size(209, 32);
            lblNombreProveedorNuevo.TabIndex = 22;
            lblNombreProveedorNuevo.Text = "Ingrese el nombre";
            // 
            // txtBoxApellidoProovedorNuevo
            // 
            txtBoxApellidoProovedorNuevo.Location = new Point(732, 298);
            txtBoxApellidoProovedorNuevo.Margin = new Padding(6, 7, 6, 7);
            txtBoxApellidoProovedorNuevo.Name = "txtBoxApellidoProovedorNuevo";
            txtBoxApellidoProovedorNuevo.Size = new Size(249, 39);
            txtBoxApellidoProovedorNuevo.TabIndex = 21;
            // 
            // txtBoxEmailProovedorNuevo
            // 
            txtBoxEmailProovedorNuevo.Location = new Point(732, 389);
            txtBoxEmailProovedorNuevo.Margin = new Padding(6, 7, 6, 7);
            txtBoxEmailProovedorNuevo.Name = "txtBoxEmailProovedorNuevo";
            txtBoxEmailProovedorNuevo.Size = new Size(249, 39);
            txtBoxEmailProovedorNuevo.TabIndex = 18;
            // 
            // txtBoxNombreProovedorNuevo
            // 
            txtBoxNombreProovedorNuevo.Location = new Point(732, 194);
            txtBoxNombreProovedorNuevo.Margin = new Padding(6, 7, 6, 7);
            txtBoxNombreProovedorNuevo.Name = "txtBoxNombreProovedorNuevo";
            txtBoxNombreProovedorNuevo.Size = new Size(249, 39);
            txtBoxNombreProovedorNuevo.TabIndex = 17;
            // 
            // btnConfirmarUsuarioNuevo
            // 
            btnConfirmarUsuarioNuevo.Location = new Point(767, 699);
            btnConfirmarUsuarioNuevo.Margin = new Padding(6, 7, 6, 7);
            btnConfirmarUsuarioNuevo.Name = "btnConfirmarUsuarioNuevo";
            btnConfirmarUsuarioNuevo.Size = new Size(400, 69);
            btnConfirmarUsuarioNuevo.TabIndex = 31;
            btnConfirmarUsuarioNuevo.Text = "Confirmar Proveedor Nuevo";
            btnConfirmarUsuarioNuevo.UseVisualStyleBackColor = true;
            btnConfirmarUsuarioNuevo.Click += btnConfirmarProveedorNuevo_Click;
            // 
            // FormA2RegistrarProveedor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 798);
            Controls.Add(btnConfirmarUsuarioNuevo);
            Controls.Add(txtBoxCUITProovedorNuevo);
            Controls.Add(lblCUITProveedorNuevo);
            Controls.Add(lblEmailProveedorNuevo);
            Controls.Add(lblApellidoProveedorNuevo);
            Controls.Add(lblNombreProveedorNuevo);
            Controls.Add(txtBoxApellidoProovedorNuevo);
            Controls.Add(txtBoxEmailProovedorNuevo);
            Controls.Add(txtBoxNombreProovedorNuevo);
            Margin = new Padding(6, 7, 6, 7);
            Name = "FormA2RegistrarProveedor";
            Text = "FormA2RegistrarProveedor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBoxCUITProovedorNuevo;
        private Label lblCUITProveedorNuevo;
        private Label lblEmailProveedorNuevo;
        private Label lblApellidoProveedorNuevo;
        private Label lblNombreProveedorNuevo;
        private TextBox txtBoxApellidoProovedorNuevo;
        private TextBox txtBoxEmailProovedorNuevo;
        private TextBox txtBoxNombreProovedorNuevo;
        private Button btnConfirmarUsuarioNuevo;
    }
}