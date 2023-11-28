namespace Formularios
{
    partial class FormA7S3MostrarStockCritico
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
            this.lblProductosStockCritico = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProductosStockCritico
            // 
            this.lblProductosStockCritico.AutoSize = true;
            this.lblProductosStockCritico.Location = new System.Drawing.Point(259, 9);
            this.lblProductosStockCritico.Name = "lblProductosStockCritico";
            this.lblProductosStockCritico.Size = new System.Drawing.Size(202, 15);
            this.lblProductosStockCritico.TabIndex = 0;
            this.lblProductosStockCritico.Text = "Productos Con Stock en Nivel Critico";
            // 
            // FormA7MostrarStockCritico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 304);
            this.Controls.Add(this.lblProductosStockCritico);
            this.Name = "FormA7MostrarStockCritico";
            this.Text = "FormA7MostrarStockCritico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblProductosStockCritico;
    }
}