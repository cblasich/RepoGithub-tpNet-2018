namespace UI.Desktop
{
    partial class ComisionDesktop
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
            this.tlComisionDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblId = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblAnioEsp = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtAnioEspecialidad = new System.Windows.Forms.TextBox();
            this.cbxPlan = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlComisionDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlComisionDesktop
            // 
            this.tlComisionDesktop.ColumnCount = 4;
            this.tlComisionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlComisionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlComisionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlComisionDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlComisionDesktop.Controls.Add(this.lblId, 0, 0);
            this.tlComisionDesktop.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlComisionDesktop.Controls.Add(this.lblAnioEsp, 2, 0);
            this.tlComisionDesktop.Controls.Add(this.lblPlan, 2, 1);
            this.tlComisionDesktop.Controls.Add(this.txtId, 1, 0);
            this.tlComisionDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlComisionDesktop.Controls.Add(this.txtAnioEspecialidad, 3, 0);
            this.tlComisionDesktop.Controls.Add(this.cbxPlan, 3, 1);
            this.tlComisionDesktop.Controls.Add(this.btnAceptar, 2, 2);
            this.tlComisionDesktop.Controls.Add(this.btnCancelar, 3, 2);
            this.tlComisionDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlComisionDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlComisionDesktop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlComisionDesktop.Name = "tlComisionDesktop";
            this.tlComisionDesktop.RowCount = 3;
            this.tlComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.0531F));
            this.tlComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.39823F));
            this.tlComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.87413F));
            this.tlComisionDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlComisionDesktop.Size = new System.Drawing.Size(559, 139);
            this.tlComisionDesktop.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(34, 18);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 17);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(4, 69);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(82, 17);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblAnioEsp
            // 
            this.lblAnioEsp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAnioEsp.AutoSize = true;
            this.lblAnioEsp.Location = new System.Drawing.Point(234, 18);
            this.lblAnioEsp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnioEsp.Name = "lblAnioEsp";
            this.lblAnioEsp.Size = new System.Drawing.Size(117, 17);
            this.lblAnioEsp.TabIndex = 2;
            this.lblAnioEsp.Text = "Año Especialidad";
            // 
            // lblPlan
            // 
            this.lblPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(234, 69);
            this.lblPlan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(36, 17);
            this.lblPlan.TabIndex = 3;
            this.lblPlan.Text = "Plan";
            // 
            // txtId
            // 
            this.txtId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(94, 15);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(132, 22);
            this.txtId.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Location = new System.Drawing.Point(94, 66);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(132, 22);
            this.txtDescripcion.TabIndex = 5;
            // 
            // txtAnioEspecialidad
            // 
            this.txtAnioEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAnioEspecialidad.Location = new System.Drawing.Point(359, 15);
            this.txtAnioEspecialidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAnioEspecialidad.Name = "txtAnioEspecialidad";
            this.txtAnioEspecialidad.Size = new System.Drawing.Size(132, 22);
            this.txtAnioEspecialidad.TabIndex = 6;
            // 
            // cbxPlan
            // 
            this.cbxPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxPlan.DisplayMember = "DescPlan";
            this.cbxPlan.FormattingEnabled = true;
            this.cbxPlan.Location = new System.Drawing.Point(359, 65);
            this.cbxPlan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxPlan.Name = "cbxPlan";
            this.cbxPlan.Size = new System.Drawing.Size(160, 24);
            this.cbxPlan.TabIndex = 7;
            this.cbxPlan.ValueMember = "Id";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(242, 106);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(407, 106);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ComisionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 139);
            this.Controls.Add(this.tlComisionDesktop);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ComisionDesktop";
            this.Text = "ComisionDesktop";
            this.tlComisionDesktop.ResumeLayout(false);
            this.tlComisionDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlComisionDesktop;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblAnioEsp;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtAnioEspecialidad;
        private System.Windows.Forms.ComboBox cbxPlan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}