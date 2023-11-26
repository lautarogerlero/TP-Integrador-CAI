namespace Form1
{
    partial class FormLogin
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtBoxUsuario = new System.Windows.Forms.TextBox();
            this.txtBoxContrasena = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(56, 66);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(56, 140);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(61, 13);
            this.lblContrasena.TabIndex = 1;
            this.lblContrasena.Text = "Contrasena";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Location = new System.Drawing.Point(207, 198);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(100, 30);
            this.btnIniciarSesion.TabIndex = 2;
            this.btnIniciarSesion.Text = "Iniciar Sesion";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtBoxUsuario
            // 
            this.txtBoxUsuario.Location = new System.Drawing.Point(330, 62);
            this.txtBoxUsuario.Name = "txtBoxUsuario";
            this.txtBoxUsuario.Size = new System.Drawing.Size(126, 20);
            this.txtBoxUsuario.TabIndex = 3;
            // 
            // txtBoxContrasena
            // 
            this.txtBoxContrasena.Location = new System.Drawing.Point(330, 133);
            this.txtBoxContrasena.Name = "txtBoxContrasena";
            this.txtBoxContrasena.Size = new System.Drawing.Size(126, 20);
            this.txtBoxContrasena.TabIndex = 4;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 256);
            this.Controls.Add(this.txtBoxContrasena);
            this.Controls.Add(this.txtBoxUsuario);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.lblUsuario);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox txtBoxUsuario;
        private System.Windows.Forms.TextBox txtBoxContrasena;
    }
}

