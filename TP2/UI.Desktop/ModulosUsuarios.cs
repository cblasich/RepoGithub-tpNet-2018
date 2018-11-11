using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class ModulosUsuarios : ApplicationForm
    {
        public ModulosUsuarios()
        {
            InitializeComponent();
            this.dgvModulosUsuarios.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                ModuloUsuarioLogic modUsuLogic = new ModuloUsuarioLogic();
                this.dgvModulosUsuarios.DataSource = modUsuLogic.GetAll();
            }
            catch (Exception e)
            {
                this.Notificar("Se produjo un error al intentar mostrar la lista de modulos de usuarios.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ModulosUsuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ModuloUsuarioDesktop formModUsu = new ModuloUsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formModUsu.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulosUsuarios.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).Id;
                ModuloUsuarioDesktop formModUsu = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formModUsu.ShowDialog();
            }

            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulosUsuarios.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).Id;
                ModuloUsuarioDesktop formModUsu = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formModUsu.ShowDialog();
            }
            this.Listar();
        }
    }
}
