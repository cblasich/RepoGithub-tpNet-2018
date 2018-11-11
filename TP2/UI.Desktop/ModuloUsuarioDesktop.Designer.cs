namespace UI.Desktop
{
    partial class ModuloUsuarioDesktop
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
            this.tlModuloUsuario = new System.Windows.Forms.TableLayoutPanel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtIdModulo = new System.Windows.Forms.TextBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAlta = new System.Windows.Forms.CheckBox();
            this.chkBaja = new System.Windows.Forms.CheckBox();
            this.chkModificacion = new System.Windows.Forms.CheckBox();
            this.chkConsulta = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlModuloUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlModuloUsuario
            // 
            this.tlModuloUsuario.ColumnCount = 4;
            this.tlModuloUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlModuloUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlModuloUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlModuloUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlModuloUsuario.Controls.Add(this.txtId, 1, 0);
            this.tlModuloUsuario.Controls.Add(this.txtIdModulo, 1, 1);
            this.tlModuloUsuario.Controls.Add(this.txtIdUsuario, 3, 1);
            this.tlModuloUsuario.Controls.Add(this.label1, 0, 0);
            this.tlModuloUsuario.Controls.Add(this.label2, 0, 1);
            this.tlModuloUsuario.Controls.Add(this.label3, 2, 1);
            this.tlModuloUsuario.Controls.Add(this.chkAlta, 0, 2);
            this.tlModuloUsuario.Controls.Add(this.chkBaja, 1, 2);
            this.tlModuloUsuario.Controls.Add(this.chkModificacion, 2, 2);
            this.tlModuloUsuario.Controls.Add(this.chkConsulta, 3, 2);
            this.tlModuloUsuario.Controls.Add(this.btnAceptar, 1, 4);
            this.tlModuloUsuario.Controls.Add(this.btnCancelar, 2, 4);
            this.tlModuloUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlModuloUsuario.Location = new System.Drawing.Point(0, 0);
            this.tlModuloUsuario.Name = "tlModuloUsuario";
            this.tlModuloUsuario.RowCount = 5;
            this.tlModuloUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlModuloUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlModuloUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlModuloUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlModuloUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlModuloUsuario.Size = new System.Drawing.Size(488, 155);
            this.tlModuloUsuario.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(125, 3);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(116, 22);
            this.txtId.TabIndex = 0;
            // 
            // txtIdModulo
            // 
            this.txtIdModulo.Location = new System.Drawing.Point(125, 34);
            this.txtIdModulo.Name = "txtIdModulo";
            this.txtIdModulo.Size = new System.Drawing.Size(116, 22);
            this.txtIdModulo.TabIndex = 1;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(369, 34);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(115, 22);
            this.txtIdUsuario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Id Módulo";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Id Usuario";
            // 
            // chkAlta
            // 
            this.chkAlta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkAlta.AutoSize = true;
            this.chkAlta.Location = new System.Drawing.Point(34, 65);
            this.chkAlta.Name = "chkAlta";
            this.chkAlta.Size = new System.Drawing.Size(54, 21);
            this.chkAlta.TabIndex = 6;
            this.chkAlta.Text = "Alta";
            this.chkAlta.UseVisualStyleBackColor = true;
            // 
            // chkBaja
            // 
            this.chkBaja.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkBaja.AutoSize = true;
            this.chkBaja.Location = new System.Drawing.Point(154, 65);
            this.chkBaja.Name = "chkBaja";
            this.chkBaja.Size = new System.Drawing.Size(58, 21);
            this.chkBaja.TabIndex = 7;
            this.chkBaja.Text = "Baja";
            this.chkBaja.UseVisualStyleBackColor = true;
            // 
            // chkModificacion
            // 
            this.chkModificacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkModificacion.AutoSize = true;
            this.chkModificacion.Location = new System.Drawing.Point(251, 65);
            this.chkModificacion.Name = "chkModificacion";
            this.chkModificacion.Size = new System.Drawing.Size(108, 21);
            this.chkModificacion.TabIndex = 8;
            this.chkModificacion.Text = "Modificación";
            this.chkModificacion.UseVisualStyleBackColor = true;
            // 
            // chkConsulta
            // 
            this.chkConsulta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkConsulta.AutoSize = true;
            this.chkConsulta.Location = new System.Drawing.Point(384, 65);
            this.chkConsulta.Name = "chkConsulta";
            this.chkConsulta.Size = new System.Drawing.Size(85, 21);
            this.chkConsulta.TabIndex = 9;
            this.chkConsulta.Text = "Consulta";
            this.chkConsulta.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnAceptar.Location = new System.Drawing.Point(145, 127);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 25);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCancelar.Location = new System.Drawing.Point(267, 127);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ModuloUsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 155);
            this.Controls.Add(this.tlModuloUsuario);
            this.Name = "ModuloUsuarioDesktop";
            this.Text = "ModuloUsuarioDesktop";
            this.tlModuloUsuario.ResumeLayout(false);
            this.tlModuloUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlModuloUsuario;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtIdModulo;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAlta;
        private System.Windows.Forms.CheckBox chkBaja;
        private System.Windows.Forms.CheckBox chkModificacion;
        private System.Windows.Forms.CheckBox chkConsulta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;


    }
}