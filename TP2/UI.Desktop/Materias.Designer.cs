namespace UI.Desktop
{//redo pull request
    partial class Materias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Materias));
            this.tscMateria = new System.Windows.Forms.ToolStripContainer();
            this.tlMateria = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMateria = new System.Windows.Forms.DataGridView();
            this.idMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsSemanales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsTotales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsMateria = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscMateria.ContentPanel.SuspendLayout();
            this.tscMateria.TopToolStripPanel.SuspendLayout();
            this.tscMateria.SuspendLayout();
            this.tlMateria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateria)).BeginInit();
            this.tsMateria.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscMateria
            // 
            // 
            // tscMateria.ContentPanel
            // 
            this.tscMateria.ContentPanel.Controls.Add(this.tlMateria);
            this.tscMateria.ContentPanel.Size = new System.Drawing.Size(660, 221);
            this.tscMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscMateria.Location = new System.Drawing.Point(0, 0);
            this.tscMateria.Name = "tscMateria";
            this.tscMateria.Size = new System.Drawing.Size(660, 246);
            this.tscMateria.TabIndex = 0;
            this.tscMateria.Text = "toolStripContainer1";
            // 
            // tscMateria.TopToolStripPanel
            // 
            this.tscMateria.TopToolStripPanel.Controls.Add(this.tsMateria);
            // 
            // tlMateria
            // 
            this.tlMateria.ColumnCount = 2;
            this.tlMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMateria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMateria.Controls.Add(this.dgvMateria, 0, 0);
            this.tlMateria.Controls.Add(this.btnActualizar, 0, 1);
            this.tlMateria.Controls.Add(this.btnSalir, 1, 1);
            this.tlMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMateria.Location = new System.Drawing.Point(0, 0);
            this.tlMateria.Name = "tlMateria";
            this.tlMateria.RowCount = 2;
            this.tlMateria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMateria.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMateria.Size = new System.Drawing.Size(660, 221);
            this.tlMateria.TabIndex = 0;
            // 
            // dgvMateria
            // 
            this.dgvMateria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMateria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMateria,
            this.descMateria,
            this.hsSemanales,
            this.hsTotales,
            this.idPlan});
            this.tlMateria.SetColumnSpan(this.dgvMateria, 2);
            this.dgvMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMateria.Location = new System.Drawing.Point(3, 3);
            this.dgvMateria.Name = "dgvMateria";
            this.dgvMateria.Size = new System.Drawing.Size(654, 186);
            this.dgvMateria.TabIndex = 0;
            // 
            // idMateria
            // 
            this.idMateria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idMateria.DataPropertyName = "Id";
            this.idMateria.HeaderText = "ID";
            this.idMateria.Name = "idMateria";
            this.idMateria.ReadOnly = true;
            // 
            // descMateria
            // 
            this.descMateria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descMateria.DataPropertyName = "DescMateria";
            this.descMateria.HeaderText = "Descripcion";
            this.descMateria.Name = "descMateria";
            this.descMateria.ReadOnly = true;
            // 
            // hsSemanales
            // 
            this.hsSemanales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hsSemanales.DataPropertyName = "HorasSemanales";
            this.hsSemanales.HeaderText = "Horas Semanales";
            this.hsSemanales.Name = "hsSemanales";
            this.hsSemanales.ReadOnly = true;
            // 
            // hsTotales
            // 
            this.hsTotales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hsTotales.DataPropertyName = "HorasTotales";
            this.hsTotales.HeaderText = "Horas Totales";
            this.hsTotales.Name = "hsTotales";
            this.hsTotales.ReadOnly = true;
            // 
            // idPlan
            // 
            this.idPlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idPlan.DataPropertyName = "IdPlan";
            this.idPlan.HeaderText = "ID Plan";
            this.idPlan.Name = "idPlan";
            this.idPlan.ReadOnly = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(501, 195);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(582, 195);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsMateria
            // 
            this.tsMateria.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMateria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsMateria.Location = new System.Drawing.Point(3, 0);
            this.tsMateria.Name = "tsMateria";
            this.tsMateria.Size = new System.Drawing.Size(112, 25);
            this.tsMateria.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Materias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 246);
            this.Controls.Add(this.tscMateria);
            this.Name = "Materias";
            this.Text = "Materias";
            this.Load += new System.EventHandler(this.Materias_Load);
            this.tscMateria.ContentPanel.ResumeLayout(false);
            this.tscMateria.TopToolStripPanel.ResumeLayout(false);
            this.tscMateria.TopToolStripPanel.PerformLayout();
            this.tscMateria.ResumeLayout(false);
            this.tscMateria.PerformLayout();
            this.tlMateria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateria)).EndInit();
            this.tsMateria.ResumeLayout(false);
            this.tsMateria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscMateria;
        private System.Windows.Forms.ToolStrip tsMateria;
        private System.Windows.Forms.TableLayoutPanel tlMateria;
        private System.Windows.Forms.DataGridView dgvMateria;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn descMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsSemanales;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsTotales;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlan;

    }
}

//redo pull request