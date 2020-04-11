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
    public partial class Planes : ApplicationForm
    {
        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        private void tlPlanes_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Listar()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                this.dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception e)
            {
                this.Notificar("Se produjo un error al intentar mostrar la lista de planes.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Planes_Load(object sender, EventArgs e)
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
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).Id;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
            }
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).Id;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
            }
            this.Listar();
        }

    }
}
