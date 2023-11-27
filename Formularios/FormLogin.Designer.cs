namespace Formularios
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxUsuarioLogin = new System.Windows.Forms.TextBox();
            this.txtBoxContraseñaLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblBienvenidoElectroHogar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxUsuarioLogin
            // 
            this.txtBoxUsuarioLogin.Location = new System.Drawing.Point(298, 68);
            this.txtBoxUsuarioLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxUsuarioLogin.Name = "txtBoxUsuarioLogin";
            this.txtBoxUsuarioLogin.Size = new System.Drawing.Size(110, 23);
            this.txtBoxUsuarioLogin.TabIndex = 0;
            // 
            // txtBoxContraseñaLogin
            // 
            this.txtBoxContraseñaLogin.Location = new System.Drawing.Point(298, 110);
            this.txtBoxContraseñaLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxContraseñaLogin.Name = "txtBoxContraseñaLogin";
            this.txtBoxContraseñaLogin.Size = new System.Drawing.Size(110, 23);
            this.txtBoxContraseñaLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 189);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Iniciar Sesion";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblBienvenidoElectroHogar
            // 
            this.lblBienvenidoElectroHogar.AutoSize = true;
            this.lblBienvenidoElectroHogar.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBienvenidoElectroHogar.Location = new System.Drawing.Point(90, 9);
            this.lblBienvenidoElectroHogar.Name = "lblBienvenidoElectroHogar";
            this.lblBienvenidoElectroHogar.Size = new System.Drawing.Size(362, 36);
            this.lblBienvenidoElectroHogar.TabIndex = 6;
            this.lblBienvenidoElectroHogar.Text = "Bienvenido a ElectroHogar SA!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 238);
            this.Controls.Add(this.lblBienvenidoElectroHogar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxContraseñaLogin);
            this.Controls.Add(this.txtBoxUsuarioLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtBoxUsuarioLogin;
        private TextBox txtBoxContraseñaLogin;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label lblBienvenidoElectroHogar;
    }
}