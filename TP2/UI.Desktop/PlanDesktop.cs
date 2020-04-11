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
using Util;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        private Plan _planActual;

        public Plan PlanActual
        {
            get { return _planActual; }
            set { _planActual = value; }
        }

        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
            this.CambiarBotones();
            this.PlanActual = new Plan();
            this.CargarCombo();        
        }
        public PlanDesktop(int id, ModoForm modo): this()
        //este constructor servirá para las modificaciones y bajas
        {
            this.Modo = modo;
            PlanLogic planLogic = new PlanLogic();
            this.CambiarBotones();

            try
            {
                //Recupero el plan
                this.PlanActual = planLogic.GetOne(id);
                this.CargarCombo();
                this.MapearDeDatos();
            }

            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.PlanActual.Id.ToString();
            this.txtDescripcion.Text = this.PlanActual.DescPlan.ToString();
            this.cbxEspecialidades.SelectedValue = this.PlanActual.IdEspecialidad; 
        }

        public override void MapearADatos()
        /* se va a utilizar para pasar la información de los controles
        a una entidad para luego enviarla a las capas inferiores */
        {
            if (this.Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
                PlanActual.State = BusinessEntity.States.New;
                PlanActual.DescPlan = this.txtDescripcion.Text.Trim();
                PlanActual.IdEspecialidad = (int)this.cbxEspecialidades.SelectedValue;

            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                PlanActual.Id = Convert.ToInt16(this.txtId.Text);
                PlanActual.State = BusinessEntity.States.Modified;
                PlanActual.DescPlan = this.txtDescripcion.Text.Trim();
                PlanActual.IdEspecialidad = (int)this.cbxEspecialidades.SelectedValue;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public override bool Validar()
        /* método que devuelva si los datos son válidos para poder
        registrar los cambios realizados.*/
        {
            string mensaje = "";

            if (String.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                mensaje += "- Complete el campo Descripción.\n";
            }
            if (this.cbxEspecialidades.SelectedIndex == -1 )
            {
                mensaje += "- Debe seleccionar una Especialidad.\n";
            }
            if (mensaje.Length == 0)
            {
                return true;
            }
            else
            {
                Notificar("Advertencia", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public override void GuardarCambios()
        /* método que se encargará de invocar al método correspondiente 
        de la capa de negocio según sea el ModoForm en que se encuentre el formulario*/
        {
            PlanLogic planLogic = new PlanLogic();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    this.MapearADatos();  //Copio datos del form a la entidad
                    planLogic.Save(this.PlanActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    planLogic.Delete(PlanActual.Id);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CargarCombo()
        {
            cbxEspecialidades.DataSource = new EspecialidadLogic().GetAll();
        }
        public void CambiarBotones()
        {
            //Para cambiar textos de ventanas y botones
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Plan";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Plan";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Plan";
                    this.btnAceptar.Text = "Eliminar";
                    this.txtDescripcion.Enabled = false;
                    this.cbxEspecialidades.Enabled = false;
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Plan";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar()) this.GuardarCambios();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
