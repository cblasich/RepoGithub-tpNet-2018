namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.tlMateria = new System.Windows.Forms.TableLayoutPanel();
            this.txtIdMateria = new System.Windows.Forms.TextBox();
            this.lblIdMateria = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblHsSemanales = new System.Windows.Forms.Label();
            this.lblHsTotales = new System.Windows.Forms.Label();
            this.txtHorasSemanales = new System.Windows.Forms.TextBox();
            this.txtHorasTotales = new System.Windows.Forms.TextBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cbxPlan = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlMateria.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMateria
            // 
            this.tlMateria.ColumnCount = 4;
            this.tlMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tlMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tlMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateria.Controls.Add(this.txtIdMateria, 1, 0);
            this.tlMateria.Controls.Add(this.lblIdMateria, 0, 0);
            this.tlMateria.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlMateria.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlMateria.Controls.Add(this.lblHsSemanales, 0, 2);
            this.tlMateria.Controls.Add(this.lblHsTotales, 0, 3);
            this.tlMateria.Controls.Add(this.txtHorasSemanales, 1, 2);
            this.tlMateria.Controls.Add(this.txtHorasTotales, 1, 3);
            this.tlMateria.Controls.Add(this.lblPlan, 2, 0);
            this.tlMateria.Controls.Add(this.cbxPlan, 3, 0);
            this.tlMateria.Controls.Add(this.btnAceptar, 2, 4);
            this.tlMateria.Controls.Add(this.btnCancelar, 3, 4);
            this.tlMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMateria.Location = new System.Drawing.Point(0, 0);
            this.tlMateria.Name = "tlMateria";
            this.tlMateria.RowCount = 5;
            this.tlMateria.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateria.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateria.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateria.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMateria.Size = new System.Drawing.Size(762, 139);
            this.tlMateria.TabIndex = 0;
            this.tlMateria.Paint += new System.Windows.Forms.PaintEventHandler(this.tlABMForm_Paint);
            // 
            // txtIdMateria
            // 
            this.txtIdMateria.Location = new System.Drawing.Point(279, 3);
            this.txtIdMateria.Name = "txtIdMateria";
            this.txtIdMateria.ReadOnly = true;
            this.txtIdMateria.Size = new System.Drawing.Size(100, 20);
            this.txtIdMateria.TabIndex = 0;
            // 
            // lblIdMateria
            // 
            this.lblIdMateria.AutoSize = true;
            this.lblIdMateria.Location = new System.Drawing.Point(3, 0);
            this.lblIdMateria.Name = "lblIdMateria";
            this.lblIdMateria.Size = new System.Drawing.Size(56, 13);
            this.lblIdMateria.TabIndex = 1;
            this.lblIdMateria.Text = "ID Materia";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(279, 30);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(3, 27);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblHsSemanales
            // 
            this.lblHsSemanales.AutoSize = true;
            this.lblHsSemanales.Location = new System.Drawing.Point(3, 53);
            this.lblHsSemanales.Name = "lblHsSemanales";
            this.lblHsSemanales.Size = new System.Drawing.Size(90, 13);
            this.lblHsSemanales.TabIndex = 4;
            this.lblHsSemanales.Text = "Horas Semanales";
            // 
            // lblHsTotales
            // 
            this.lblHsTotales.AutoSize = true;
            this.lblHsTotales.Location = new System.Drawing.Point(3, 79);
            this.lblHsTotales.Name = "lblHsTotales";
            this.lblHsTotales.Size = new System.Drawing.Size(73, 13);
            this.lblHsTotales.TabIndex = 5;
            this.lblHsTotales.Text = "Horas Totales";
            // 
            // txtHorasSemanales
            // 
            this.txtHorasSemanales.Location = new System.Drawing.Point(279, 56);
            this.txtHorasSemanales.Name = "txtHorasSemanales";
            this.txtHorasSemanales.Size = new System.Drawing.Size(100, 20);
            this.txtHorasSemanales.TabIndex = 6;
            // 
            // txtHorasTotales
            // 
            this.txtHorasTotales.Location = new System.Drawing.Point(279, 82);
            this.txtHorasTotales.Name = "txtHorasTotales";
            this.txtHorasTotales.Size = new System.Drawing.Size(100, 20);
            this.txtHorasTotales.TabIndex = 7;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(556, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 8;
            this.lblPlan.Text = "Plan";
            // 
            // cbxPlan
            // 
            this.cbxPlan.DisplayMember = "DescPlan";
            this.cbxPlan.FormattingEnabled = true;
            this.cbxPlan.Location = new System.Drawing.Point(637, 3);
            this.cbxPlan.Name = "cbxPlan";
            this.cbxPlan.Size = new System.Drawing.Size(121, 21);
            this.cbxPlan.TabIndex = 2;
            this.cbxPlan.ValueMember = "Id";
            this.cbxPlan.SelectedIndexChanged += new System.EventHandler(this.cbxPlan_SelectedIndexChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(556, 108);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(684, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 139);
            this.Controls.Add(this.tlMateria);
            this.Name = "MateriaDesktop";
            this.Text = "MateriaDesktop";
            this.tlMateria.ResumeLayout(false);
            this.tlMateria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected internal System.Windows.Forms.TableLayoutPanel tlMateria;
        private System.Windows.Forms.TextBox txtIdMateria;
        private System.Windows.Forms.Label lblIdMateria;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblHsSemanales;
        private System.Windows.Forms.Label lblHsTotales;
        private System.Windows.Forms.TextBox txtHorasSemanales;
        private System.Windows.Forms.TextBox txtHorasTotales;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cbxPlan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}