namespace UI.Desktop
{
    partial class ModulosUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModulosUsuarios));
            this.tscModulosUsuarios = new System.Windows.Forms.ToolStripContainer();
            this.tlModulosUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.dgvModulosUsuarios = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.baja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.modif = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.consulta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsModulosUsuarios = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscModulosUsuarios.ContentPanel.SuspendLayout();
            this.tscModulosUsuarios.TopToolStripPanel.SuspendLayout();
            this.tscModulosUsuarios.SuspendLayout();
            this.tlModulosUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).BeginInit();
            this.tsModulosUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscModulosUsuarios
            // 
            // 
            // tscModulosUsuarios.ContentPanel
            // 
            this.tscModulosUsuarios.ContentPanel.Controls.Add(this.tlModulosUsuarios);
            this.tscModulosUsuarios.ContentPanel.Size = new System.Drawing.Size(755, 272);
            this.tscModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tscModulosUsuarios.Name = "tscModulosUsuarios";
            this.tscModulosUsuarios.Size = new System.Drawing.Size(755, 299);
            this.tscModulosUsuarios.TabIndex = 0;
            this.tscModulosUsuarios.Text = "toolStripContainer1";
            // 
            // tscModulosUsuarios.TopToolStripPanel
            // 
            this.tscModulosUsuarios.TopToolStripPanel.Controls.Add(this.tsModulosUsuarios);
            // 
            // tlModulosUsuarios
            // 
            this.tlModulosUsuarios.AutoSize = true;
            this.tlModulosUsuarios.ColumnCount = 2;
            this.tlModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulosUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModulosUsuarios.Controls.Add(this.dgvModulosUsuarios, 0, 0);
            this.tlModulosUsuarios.Controls.Add(this.btnActualizar, 0, 1);
            this.tlModulosUsuarios.Controls.Add(this.btnSalir, 1, 1);
            this.tlModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlModulosUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlModulosUsuarios.Name = "tlModulosUsuarios";
            this.tlModulosUsuarios.RowCount = 2;
            this.tlModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulosUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModulosUsuarios.Size = new System.Drawing.Size(755, 272);
            this.tlModulosUsuarios.TabIndex = 0;
            // 
            // dgvModulosUsuarios
            // 
            this.dgvModulosUsuarios.AllowUserToAddRows = false;
            this.dgvModulosUsuarios.AllowUserToDeleteRows = false;
            this.dgvModulosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulosUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idModulo,
            this.idUsuario,
            this.alta,
            this.baja,
            this.modif,
            this.consulta});
            this.tlModulosUsuarios.SetColumnSpan(this.dgvModulosUsuarios, 2);
            this.dgvModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulosUsuarios.Location = new System.Drawing.Point(3, 3);
            this.dgvModulosUsuarios.Name = "dgvModulosUsuarios";
            this.dgvModulosUsuarios.ReadOnly = true;
            this.dgvModulosUsuarios.RowTemplate.Height = 24;
            this.dgvModulosUsuarios.Size = new System.Drawing.Size(749, 237);
            this.dgvModulosUsuarios.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // idModulo
            // 
            this.idModulo.DataPropertyName = "IdModulo";
            this.idModulo.HeaderText = "Id Modulo";
            this.idModulo.Name = "idModulo";
            this.idModulo.ReadOnly = true;
            // 
            // idUsuario
            // 
            this.idUsuario.DataPropertyName = "IdUsuario";
            this.idUsuario.HeaderText = "Id Usuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            // 
            // alta
            // 
            this.alta.DataPropertyName = "PermiteAlta";
            this.alta.HeaderText = "Alta";
            this.alta.Name = "alta";
            this.alta.ReadOnly = true;
            // 
            // baja
            // 
            this.baja.DataPropertyName = "PermiteBaja";
            this.baja.HeaderText = "Baja";
            this.baja.Name = "baja";
            this.baja.ReadOnly = true;
            // 
            // modif
            // 
            this.modif.DataPropertyName = "PermiteModificacion";
            this.modif.HeaderText = "Modificación";
            this.modif.Name = "modif";
            this.modif.ReadOnly = true;
            // 
            // consulta
            // 
            this.consulta.DataPropertyName = "PermiteConsulta";
            this.consulta.HeaderText = "Consulta";
            this.consulta.Name = "consulta";
            this.consulta.ReadOnly = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(586, 246);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(85, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(677, 246);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsModulosUsuarios
            // 
            this.tsModulosUsuarios.Dock = System.Windows.Forms.DockStyle.None;
            this.tsModulosUsuarios.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsModulosUsuarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsModulosUsuarios.Location = new System.Drawing.Point(3, 0);
            this.tsModulosUsuarios.Name = "tsModulosUsuarios";
            this.tsModulosUsuarios.Size = new System.Drawing.Size(123, 27);
            this.tsModulosUsuarios.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(24, 24);
            this.tsbNuevo.Text = "toolStripButton1";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(24, 24);
            this.tsbEditar.Text = "toolStripButton1";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(24, 24);
            this.tsbEliminar.Text = "toolStripButton1";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // ModulosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(755, 299);
            this.Controls.Add(this.tscModulosUsuarios);
            this.Name = "ModulosUsuarios";
            this.Text = "Modulos de Usuarios";
            this.Load += new System.EventHandler(this.ModulosUsuarios_Load);
            this.tscModulosUsuarios.ContentPanel.ResumeLayout(false);
            this.tscModulosUsuarios.ContentPanel.PerformLayout();
            this.tscModulosUsuarios.TopToolStripPanel.ResumeLayout(false);
            this.tscModulosUsuarios.TopToolStripPanel.PerformLayout();
            this.tscModulosUsuarios.ResumeLayout(false);
            this.tscModulosUsuarios.PerformLayout();
            this.tlModulosUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).EndInit();
            this.tsModulosUsuarios.ResumeLayout(false);
            this.tsModulosUsuarios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscModulosUsuarios;
        private System.Windows.Forms.TableLayoutPanel tlModulosUsuarios;
        private System.Windows.Forms.DataGridView dgvModulosUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsModulosUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn baja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn modif;
        private System.Windows.Forms.DataGridViewCheckBoxColumn consulta;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
    }
}