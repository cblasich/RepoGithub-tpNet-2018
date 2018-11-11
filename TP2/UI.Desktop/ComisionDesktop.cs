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
    public partial class ComisionDesktop : ApplicationForm
    {

        public ComisionDesktop()
        {
            InitializeComponent();
        }

        private Comision _comisionActual;

        public Comision ComisionActual
        {
            get { return _comisionActual; }
            set { _comisionActual = value; }
        }
        
        public ComisionDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
            this.CambiarBotones();
            this.ComisionActual = new Comision();
            this.CargarCombo();
                       
        }

        public ComisionDesktop(int id, ModoForm modo): this()
        //este constructor servirá para las modificaciones y bajas
        {
            this.Modo = modo;
            ComisionLogic comisionLogic = new ComisionLogic();

            try
            {
                //Recupero la materia
                this.ComisionActual = comisionLogic.GetOne(id);
                //this.MapearDeDatos();
                               
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
                ComisionActual = new Comision();
                ComisionActual.State = BusinessEntity.States.New;
                ComisionActual.DescComision = this.txtDescripcion.Text.Trim();
                ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text.Trim());
                ComisionActual.IdPlan = (int)this.cbxPlan.SelectedValue;

            }
        }

        public override void GuardarCambios()
        /* método que se encargará de invocar al método correspondiente 
        de la capa de negocio según sea el ModoForm en que se encuentre el formulario*/
        {
            ComisionLogic comLogic = new ComisionLogic();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    //Copio datos del formulario al usuario
                    this.MapearADatos();
                    //Guardo el usuario y la persona
                    comLogic.Save(this.ComisionActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        public void CargarCombo()
        {
            cbxPlan.DataSource = new PlanLogic().GetAll();
        }

        public void CambiarBotones()
        {
            //Para cambiar textos de ventanas y botones
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Comision";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Comision";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Comision";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Comision";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
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
