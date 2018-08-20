using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
       
        }

        private Materia _materiaActual;

        public Materia MateriaActual
        {
            get { return _materiaActual; }
            set { _materiaActual = value; }
        }

        public void CargarCombo()
        {
            cbxPlan.DataSource = new PlanLogic().GetAll();
        }

        public MateriaDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
            this.MateriaActual = new Materia();
            this.CargarCombo();
                       
        }

        public MateriaDesktop(int id, ModoForm modo)
            : this()
        //este constructor servirá para las modificaciones y bajas
        {
            this.Modo = modo;
            MateriaLogic materiaLogic = new MateriaLogic();

            try
            {
                //Recupero la materia
                this.MateriaActual = materiaLogic.GetOne(id);
                this.MapearDeDatos();
                               
            }

            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override void MapearADatos()
        /* se va a utilizar para pasar la información de los controles
        a una entidad para luego enviarla a las capas inferiores */
        {
            if (this.Modo == ModoForm.Alta)
            {
                MateriaActual = new Materia();
                MateriaActual.State = BusinessEntity.States.New;
                MateriaActual.DescMateria = this.txtDescripcion.Text.Trim();
                MateriaActual.HorasSemanales = Convert.ToInt32(this.txtHorasSemanales.Text.Trim());
                MateriaActual.HorasTotales = Convert.ToInt32(this.txtHorasTotales.Text.Trim());
                MateriaActual.IdPlan = (int)this.cbxPlan.SelectedValue;
                           
                }
            

            if (this.Modo == ModoForm.Modificacion)
            {

                MateriaActual.State = BusinessEntity.States.Modified;
                MateriaActual.DescMateria = this.txtDescripcion.Text.Trim();
                MateriaActual.HorasSemanales = Convert.ToInt32(this.txtHorasSemanales.Text.Trim());
                MateriaActual.HorasTotales = Convert.ToInt32(this.txtHorasTotales.Text.Trim());
                MateriaActual.IdPlan = (int)this.cbxPlan.SelectedValue;
                
            }

            
            if (this.Modo == ModoForm.Baja)
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void MapearDeDatos()        
        {
            
            try
            {
                if (this.Modo == ModoForm.Modificacion || this.Modo == ModoForm.Baja)
                {
                    //Copio datos al formulario
                    this.txtIdMateria.Text = this.MateriaActual.Id.ToString();
                    this.txtDescripcion.Text = this.MateriaActual.DescMateria.ToString();
                    this.txtHorasSemanales.Text = this.MateriaActual.HorasSemanales.ToString();
                    this.txtHorasTotales.Text = this.MateriaActual.HorasTotales.ToString();
                    this.CargarCombo();
                    this.cbxPlan.SelectedValue = this.MateriaActual.IdPlan;
                }

                if (this.Modo == ModoForm.Baja)
                {
                    this.txtIdMateria.Enabled = false;
                    this.txtDescripcion.Enabled = false;
                    this.txtHorasSemanales.Enabled = false;
                    this.txtHorasTotales.Enabled = false;
                    this.cbxPlan.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Se produjo un error.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Para cambiar textos de ventanas y botones
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Usuario";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Usuario";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Usuario";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Usuario";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }


        public override void GuardarCambios()
        /* método que se encargará de invocar al método correspondiente 
        de la capa de negocio según sea el ModoForm en que se encuentre el formulario*/
        {
            MateriaLogic matLogic = new MateriaLogic();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    //Copio datos del formulario al usuario
                    this.MapearADatos();
                    //Guardo el usuario y la persona
                    matLogic.Save(this.MateriaActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    //Copio datos del formulario al usuario
                    this.MapearADatos();
                    //Guardo el usuario y la persona
                    matLogic.Delete(this.MateriaActual.Id);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

           
        private void tlABMForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
