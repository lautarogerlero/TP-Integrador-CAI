namespace Form1
{
    partial class FormA4S1AgregarProducto
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
            this.lblCategoriaNuevoProducto = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblNombreProductoNuevo = new System.Windows.Forms.Label();
            this.txtBoxNombreNuevoProducto = new System.Windows.Forms.TextBox();
            this.lblPrecioNuevoProducto = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnConfirmarAgregarProductoNuevo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCategoriaNuevoProducto
            // 
            this.lblCategoriaNuevoProducto.AutoSize = true;
            this.lblCategoriaNuevoProducto.Location = new System.Drawing.Point(97, 87);
            this.lblCategoriaNuevoProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoriaNuevoProducto.Name = "lblCategoriaNuevoProducto";
            this.lblCategoriaNuevoProducto.Size = new System.Drawing.Size(244, 15);
            this.lblCategoriaNuevoProducto.TabIndex = 0;
            this.lblCategoriaNuevoProducto.Text = "Ingrese la categoria del nuevo producto (1-5)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(472, 83);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(39, 23);
            this.textBox1.TabIndex = 1;
            // 
            // lblNombreProductoNuevo
            // 
            this.lblNombreProductoNuevo.AutoSize = true;
            this.lblNombreProductoNuevo.Location = new System.Drawing.Point(97, 150);
            this.lblNombreProductoNuevo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreProductoNuevo.Name = "lblNombreProductoNuevo";
            this.lblNombreProductoNuevo.Size = new System.Drawing.Size(209, 15);
            this.lblNombreProductoNuevo.TabIndex = 2;
            this.lblNombreProductoNuevo.Text = "Ingrese el nombre del nuevo producto";
            // 
            // txtBoxNombreNuevoProducto
            // 
            this.txtBoxNombreNuevoProducto.Location = new System.Drawing.Point(447, 147);
            this.txtBoxNombreNuevoProducto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxNombreNuevoProducto.Name = "txtBoxNombreNuevoProducto";
            this.txtBoxNombreNuevoProducto.Size = new System.Drawing.Size(94, 23);
            this.txtBoxNombreNuevoProducto.TabIndex = 3;
            // 
            // lblPrecioNuevoProducto
            // 
            this.lblPrecioNuevoProducto.AutoSize = true;
            this.lblPrecioNuevoProducto.Location = new System.Drawing.Point(97, 222);
            this.lblPrecioNuevoProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioNuevoProducto.Name = "lblPrecioNuevoProducto";
            this.lblPrecioNuevoProducto.Size = new System.Drawing.Size(200, 15);
            this.lblPrecioNuevoProducto.TabIndex = 4;
            this.lblPrecioNuevoProducto.Text = "Ingrese el precio del nuevo producto";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(447, 218);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 23);
            this.textBox2.TabIndex = 5;
            // 
            // btnConfirmarAgregarProductoNuevo
            // 
            this.btnConfirmarAgregarProductoNuevo.Location = new System.Drawing.Point(510, 319);
            this.btnConfirmarAgregarProductoNuevo.Name = "btnConfirmarAgregarProductoNuevo";
            this.btnConfirmarAgregarProductoNuevo.Size = new System.Drawing.Size(171, 31);
            this.btnConfirmarAgregarProductoNuevo.TabIndex = 6;
            this.btnConfirmarAgregarProductoNuevo.Text = "Confirmar Producto Nuevo";
            this.btnConfirmarAgregarProductoNuevo.UseVisualStyleBackColor = true;
            this.btnConfirmarAgregarProductoNuevo.Click += new System.EventHandler(this.btnConfirmarAgregarProductoNuevo_Click);
            // 
            // FormA4AgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 362);
            this.Controls.Add(this.btnConfirmarAgregarProductoNuevo);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblPrecioNuevoProducto);
            this.Controls.Add(this.txtBoxNombreNuevoProducto);
            this.Controls.Add(this.lblNombreProductoNuevo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCategoriaNuevoProducto);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormA4AgregarProducto";
            this.Text = "FormA4AgregarProducto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoriaNuevoProducto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblNombreProductoNuevo;
        private System.Windows.Forms.TextBox txtBoxNombreNuevoProducto;
        private System.Windows.Forms.Label lblPrecioNuevoProducto;
        private System.Windows.Forms.TextBox textBox2;
        private Button btnConfirmarAgregarProductoNuevo;
    }
}