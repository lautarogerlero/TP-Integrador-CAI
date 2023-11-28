namespace Formularios
{
    partial class FormS2DevolverVenta
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
            this.lblNombreClienteDevolverVenta = new System.Windows.Forms.Label();
            this.lblApellidoClienteDevolverVenta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxNombreClienteDevolverVenta = new System.Windows.Forms.TextBox();
            this.txtBoxApellidoClienteDevolverVenta = new System.Windows.Forms.TextBox();
            this.txtBoxCantVendidaDevolverVenta = new System.Windows.Forms.TextBox();
            this.btnDevolverVenta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNombreClienteDevolverVenta
            // 
            this.lblNombreClienteDevolverVenta.AutoSize = true;
            this.lblNombreClienteDevolverVenta.Location = new System.Drawing.Point(37, 36);
            this.lblNombreClienteDevolverVenta.Name = "lblNombreClienteDevolverVenta";
            this.lblNombreClienteDevolverVenta.Size = new System.Drawing.Size(161, 15);
            this.lblNombreClienteDevolverVenta.TabIndex = 0;
            this.lblNombreClienteDevolverVenta.Text = "Ingrese el nombre del Cliente";
            // 
            // lblApellidoClienteDevolverVenta
            // 
            this.lblApellidoClienteDevolverVenta.AutoSize = true;
            this.lblApellidoClienteDevolverVenta.Location = new System.Drawing.Point(37, 70);
            this.lblApellidoClienteDevolverVenta.Name = "lblApellidoClienteDevolverVenta";
            this.lblApellidoClienteDevolverVenta.Size = new System.Drawing.Size(159, 15);
            this.lblApellidoClienteDevolverVenta.TabIndex = 1;
            this.lblApellidoClienteDevolverVenta.Text = "Ingrese el apellido del cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ingrese la cantidad vendida";
            // 
            // txtBoxNombreClienteDevolverVenta
            // 
            this.txtBoxNombreClienteDevolverVenta.Location = new System.Drawing.Point(279, 33);
            this.txtBoxNombreClienteDevolverVenta.Name = "txtBoxNombreClienteDevolverVenta";
            this.txtBoxNombreClienteDevolverVenta.Size = new System.Drawing.Size(96, 23);
            this.txtBoxNombreClienteDevolverVenta.TabIndex = 3;
            // 
            // txtBoxApellidoClienteDevolverVenta
            // 
            this.txtBoxApellidoClienteDevolverVenta.Location = new System.Drawing.Point(279, 67);
            this.txtBoxApellidoClienteDevolverVenta.Name = "txtBoxApellidoClienteDevolverVenta";
            this.txtBoxApellidoClienteDevolverVenta.Size = new System.Drawing.Size(96, 23);
            this.txtBoxApellidoClienteDevolverVenta.TabIndex = 4;
            // 
            // txtBoxCantVendidaDevolverVenta
            // 
            this.txtBoxCantVendidaDevolverVenta.Location = new System.Drawing.Point(279, 101);
            this.txtBoxCantVendidaDevolverVenta.Name = "txtBoxCantVendidaDevolverVenta";
            this.txtBoxCantVendidaDevolverVenta.Size = new System.Drawing.Size(96, 23);
            this.txtBoxCantVendidaDevolverVenta.TabIndex = 5;
            // 
            // btnDevolverVenta
            // 
            this.btnDevolverVenta.Location = new System.Drawing.Point(305, 149);
            this.btnDevolverVenta.Name = "btnDevolverVenta";
            this.btnDevolverVenta.Size = new System.Drawing.Size(108, 31);
            this.btnDevolverVenta.TabIndex = 6;
            this.btnDevolverVenta.Text = "Devolver Venta";
            this.btnDevolverVenta.UseVisualStyleBackColor = true;
            // 
            // FormS2DevolverVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 192);
            this.Controls.Add(this.btnDevolverVenta);
            this.Controls.Add(this.txtBoxCantVendidaDevolverVenta);
            this.Controls.Add(this.txtBoxApellidoClienteDevolverVenta);
            this.Controls.Add(this.txtBoxNombreClienteDevolverVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblApellidoClienteDevolverVenta);
            this.Controls.Add(this.lblNombreClienteDevolverVenta);
            this.Name = "FormS2DevolverVenta";
            this.Text = "FormS2DevolverVenta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNombreClienteDevolverVenta;
        private Label lblApellidoClienteDevolverVenta;
        private Label label3;
        private TextBox txtBoxNombreClienteDevolverVenta;
        private TextBox txtBoxApellidoClienteDevolverVenta;
        private TextBox txtBoxCantVendidaDevolverVenta;
        private Button btnDevolverVenta;
    }
}