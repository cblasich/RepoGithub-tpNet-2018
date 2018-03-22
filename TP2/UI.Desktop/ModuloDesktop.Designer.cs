namespace UI.Desktop
{
    partial class ModuloDesktop
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
            this.tlModuloDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdModulo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtEjecuta = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlModuloDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlModuloDesktop
            // 
            this.tlModuloDesktop.ColumnCount = 2;
            this.tlModuloDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModuloDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModuloDesktop.Controls.Add(this.label1, 0, 0);
            this.tlModuloDesktop.Controls.Add(this.label2, 0, 1);
            this.tlModuloDesktop.Controls.Add(this.label3, 0, 2);
            this.tlModuloDesktop.Controls.Add(this.txtIdModulo, 1, 0);
            this.tlModuloDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlModuloDesktop.Controls.Add(this.txtEjecuta, 1, 2);
            this.tlModuloDesktop.Controls.Add(this.btnAceptar, 0, 3);
            this.tlModuloDesktop.Controls.Add(this.btnCancelar, 1, 3);
            this.tlModuloDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlModuloDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlModuloDesktop.Name = "tlModuloDesktop";
            this.tlModuloDesktop.RowCount = 4;
            this.tlModuloDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModuloDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModuloDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModuloDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModuloDesktop.Size = new System.Drawing.Size(291, 132);
            this.tlModuloDesktop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Modulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ejecuta";
            // 
            // txtIdModulo
            // 
            this.txtIdModulo.Location = new System.Drawing.Point(91, 3);
            this.txtIdModulo.Name = "txtIdModulo";
            this.txtIdModulo.ReadOnly = true;
            this.txtIdModulo.Size = new System.Drawing.Size(197, 22);
            this.txtIdModulo.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(91, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(197, 22);
            this.txtDescripcion.TabIndex = 4;
            // 
            // txtEjecuta
            // 
            this.txtEjecuta.Location = new System.Drawing.Point(91, 59);
            this.txtEjecuta.Name = "txtEjecuta";
            this.txtEjecuta.Size = new System.Drawing.Size(197, 22);
            this.txtEjecuta.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(10, 91);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 33);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.Location = new System.Drawing.Point(91, 91);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 33);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ModuloDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 132);
            this.Controls.Add(this.tlModuloDesktop);
            this.Name = "ModuloDesktop";
            this.Text = "ModuloDesktop";
            this.tlModuloDesktop.ResumeLayout(false);
            this.tlModuloDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlModuloDesktop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdModulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtEjecuta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}