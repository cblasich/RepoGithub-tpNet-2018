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
    public partial class Modulos : ApplicationForm
    {
        public Modulos()
        {
            InitializeComponent();
            this.dgvModulos.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            try
            {
                ModuloLogic ml = new ModuloLogic();
                this.dgvModulos.DataSource = ml.GetAll();
            }
            catch (Exception e)
            {
                this.Notificar("Se produjo un error al intentar mostrar la lista de módulos.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Modulos_Load(object sender, EventArgs e)
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
            ModuloDesktop formModulo = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            formModulo.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulos.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).Id;
                ModuloDesktop formModulo = new ModuloDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formModulo.ShowDialog();
            }
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulos.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).Id;
                ModuloDesktop formModulo = new ModuloDesktop(ID, ApplicationForm.ModoForm.Baja);
                formModulo.ShowDialog();
            }
            this.Listar();
        }
    }
}
