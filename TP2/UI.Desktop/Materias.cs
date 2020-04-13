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
{//redo pull request
    public partial class Materias : ApplicationForm
    {
        public Materias()
        {
            InitializeComponent();
            this.dgvMateria.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMateria.DataSource = ml.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMateria.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Materia)this.dgvMateria.SelectedRows[0].DataBoundItem).Id;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMateria.SelectedRows.Count == 1)
            {
                int ID = ((Business.Entities.Materia)this.dgvMateria.SelectedRows[0].DataBoundItem).Id;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }
        }

      
    }

    //redo pull request
}
