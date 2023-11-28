namespace Formularios
{
    partial class FormA6ModificarCliente
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
            this.lblNombreClienteAModificar = new System.Windows.Forms.Label();
            this.lblApellidoClienteAModificar = new System.Windows.Forms.Label();
            this.txtBoxNombreCliente = new System.Windows.Forms.TextBox();
            this.txtBoxApellidoClienteAModificar = new System.Windows.Forms.TextBox();
            this.btnModificarDireccionTelefonoEmailCliente = new System.Windows.Forms.Button();
            this.btnModificarEstadoCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombreClienteAModificar
            // 
            this.lblNombreClienteAModificar.AutoSize = true;
            this.lblNombreClienteAModificar.Location = new System.Drawing.Point(119, 64);
            this.lblNombreClienteAModificar.Name = "lblNombreClienteAModificar";
            this.lblNombreClienteAModificar.Size = new System.Drawing.Size(51, 15);
            this.lblNombreClienteAModificar.TabIndex = 0;
            this.lblNombreClienteAModificar.Text = "Nombre";
            // 
            // lblApellidoClienteAModificar
            // 
            this.lblApellidoClienteAModificar.AutoSize = true;
            this.lblApellidoClienteAModificar.Location = new System.Drawing.Point(119, 129);
            this.lblApellidoClienteAModificar.Name = "lblApellidoClienteAModificar";
            this.lblApellidoClienteAModificar.Size = new System.Drawing.Size(51, 15);
            this.lblApellidoClienteAModificar.TabIndex = 1;
            this.lblApellidoClienteAModificar.Text = "Apellido";
            // 
            // txtBoxNombreCliente
            // 
            this.txtBoxNombreCliente.Location = new System.Drawing.Point(344, 61);
            this.txtBoxNombreCliente.Name = "txtBoxNombreCliente";
            this.txtBoxNombreCliente.Size = new System.Drawing.Size(125, 23);
            this.txtBoxNombreCliente.TabIndex = 2;
            // 
            // txtBoxApellidoClienteAModificar
            // 
            this.txtBoxApellidoClienteAModificar.Location = new System.Drawing.Point(344, 121);
            this.txtBoxApellidoClienteAModificar.Name = "txtBoxApellidoClienteAModificar";
            this.txtBoxApellidoClienteAModificar.Size = new System.Drawing.Size(125, 23);
            this.txtBoxApellidoClienteAModificar.TabIndex = 3;
            // 
            // btnModificarDireccionTelefonoEmailCliente
            // 
            this.btnModificarDireccionTelefonoEmailCliente.Location = new System.Drawing.Point(119, 225);
            this.btnModificarDireccionTelefonoEmailCliente.Name = "btnModificarDireccionTelefonoEmailCliente";
            this.btnModificarDireccionTelefonoEmailCliente.Size = new System.Drawing.Size(138, 38);
            this.btnModificarDireccionTelefonoEmailCliente.TabIndex = 4;
            this.btnModificarDireccionTelefonoEmailCliente.Text = "Modificar Direccion, Telefono y Email";
            this.btnModificarDireccionTelefonoEmailCliente.UseVisualStyleBackColor = true;
            this.btnModificarDireccionTelefonoEmailCliente.Click += new System.EventHandler(this.btnModificarDireccionTelefonoEmailCliente_Click);
            // 
            // btnModificarEstadoCliente
            // 
            this.btnModificarEstadoCliente.Location = new System.Drawing.Point(320, 225);
            this.btnModificarEstadoCliente.Name = "btnModificarEstadoCliente";
            this.btnModificarEstadoCliente.Size = new System.Drawing.Size(135, 38);
            this.btnModificarEstadoCliente.TabIndex = 5;
            this.btnModificarEstadoCliente.Text = "Modificar Estado";
            this.btnModificarEstadoCliente.UseVisualStyleBackColor = true;
            this.btnModificarEstadoCliente.Click += new System.EventHandler(this.btnModificarEstadoCliente_Click);
            // 
            // FormA6ModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 301);
            this.Controls.Add(this.btnModificarEstadoCliente);
            this.Controls.Add(this.btnModificarDireccionTelefonoEmailCliente);
            this.Controls.Add(this.txtBoxApellidoClienteAModificar);
            this.Controls.Add(this.txtBoxNombreCliente);
            this.Controls.Add(this.lblApellidoClienteAModificar);
            this.Controls.Add(this.lblNombreClienteAModificar);
            this.Name = "FormA6ModificarCliente";
            this.Text = "FormA6ModificarCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNombreClienteAModificar;
        private Label lblApellidoClienteAModificar;
        private TextBox txtBoxNombreCliente;
        private TextBox txtBoxApellidoClienteAModificar;
        private Button btnModificarDireccionTelefonoEmailCliente;
        private Button btnModificarEstadoCliente;
    }
}