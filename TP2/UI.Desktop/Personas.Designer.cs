namespace UI.Desktop
{
    partial class Personas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Personas));
            this.tscPersonas = new System.Windows.Forms.ToolStripContainer();
            this.tlPersonas = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsPersonas = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tscPersonas.ContentPanel.SuspendLayout();
            this.tscPersonas.TopToolStripPanel.SuspendLayout();
            this.tscPersonas.SuspendLayout();
            this.tlPersonas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.tsPersonas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscPersonas
            // 
            // 
            // tscPersonas.ContentPanel
            // 
            this.tscPersonas.ContentPanel.Controls.Add(this.tlPersonas);
            this.tscPersonas.ContentPanel.Size = new System.Drawing.Size(1084, 276);
            this.tscPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscPersonas.Location = new System.Drawing.Point(0, 0);
            this.tscPersonas.Name = "tscPersonas";
            this.tscPersonas.Size = new System.Drawing.Size(1084, 303);
            this.tscPersonas.TabIndex = 0;
            this.tscPersonas.Text = "toolStripContainer1";
            // 
            // tscPersonas.TopToolStripPanel
            // 
            this.tscPersonas.TopToolStripPanel.Controls.Add(this.tsPersonas);
            // 
            // tlPersonas
            // 
            this.tlPersonas.ColumnCount = 2;
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPersonas.Controls.Add(this.dgvPersonas, 0, 0);
            this.tlPersonas.Controls.Add(this.btnActualizar, 0, 1);
            this.tlPersonas.Controls.Add(this.btnSalir, 1, 1);
            this.tlPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPersonas.Location = new System.Drawing.Point(0, 0);
            this.tlPersonas.Name = "tlPersonas";
            this.tlPersonas.RowCount = 2;
            this.tlPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPersonas.Size = new System.Drawing.Size(1084, 276);
            this.tlPersonas.TabIndex = 0;
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AllowUserToDeleteRows = false;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.apellido,
            this.direccion,
            this.email,
            this.telefono,
            this.fechaNacimiento,
            this.legajo,
            this.tipoPersona,
            this.idPlan});
            this.tlPersonas.SetColumnSpan(this.dgvPersonas, 2);
            this.dgvPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonas.Location = new System.Drawing.Point(3, 3);
            this.dgvPersonas.MultiSelect = false;
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.RowTemplate.Height = 24;
            this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonas.Size = new System.Drawing.Size(1078, 241);
            this.dgvPersonas.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "Apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "Direccion";
            this.direccion.HeaderText = "Dirección";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // email
            // 
            this.email.DataPropertyName = "Email";
            this.email.HeaderText = "Email";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "Telefono";
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.DataPropertyName = "FechaNac";
            this.fechaNacimiento.HeaderText = "Fecha de nacimiento";
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.ReadOnly = true;
            // 
            // legajo
            // 
            this.legajo.DataPropertyName = "Legajo";
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            this.legajo.ReadOnly = true;
            // 
            // tipoPersona
            // 
            this.tipoPersona.DataPropertyName = "TipoPersona";
            this.tipoPersona.HeaderText = "Tipo de persona";
            this.tipoPersona.Name = "tipoPersona";
            this.tipoPersona.ReadOnly = true;
            // 
            // idPlan
            // 
            this.idPlan.DataPropertyName = "IdPlan";
            this.idPlan.HeaderText = "ID Plan";
            this.idPlan.Name = "idPlan";
            this.idPlan.ReadOnly = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(918, 250);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(82, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1006, 250);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsPersonas
            // 
            this.tsPersonas.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPersonas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsPersonas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsPersonas.Location = new System.Drawing.Point(3, 0);
            this.tsPersonas.Name = "tsPersonas";
            this.tsPersonas.Size = new System.Drawing.Size(84, 27);
            this.tsPersonas.TabIndex = 0;
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
            this.tsbEliminar.Text = "toolStripButton2";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Personas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 303);
            this.Controls.Add(this.tscPersonas);
            this.Name = "Personas";
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.Personas_Load);
            this.tscPersonas.ContentPanel.ResumeLayout(false);
            this.tscPersonas.TopToolStripPanel.ResumeLayout(false);
            this.tscPersonas.TopToolStripPanel.PerformLayout();
            this.tscPersonas.ResumeLayout(false);
            this.tscPersonas.PerformLayout();
            this.tlPersonas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.tsPersonas.ResumeLayout(false);
            this.tsPersonas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscPersonas;
        private System.Windows.Forms.TableLayoutPanel tlPersonas;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsPersonas;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlan;
    }
}