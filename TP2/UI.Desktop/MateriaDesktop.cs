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

        public MateriaDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
            this.MateriaActual = new Materia();
            
        }

        /*public MateriaDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            MateriaLogic materiaLogic = new MateriaLogic();
            try
            {
                //Recupero la materia
                this.MateriaActual = materiaLogic.GetOne(id);

                /*Enumeradores.TiposPersonas tipoPersona = new PersonaLogic().GetOnePorPersona(MateriaActual.IdPersona).TipoPersona;
                if (tipoPersona == Enumeradores.TiposPersonas.Administrador)
                {
                    //Cargo la grilla de permisos
                    dgvPermisos.AutoGenerateColumns = false;
                    dgvPermisos.DataSource = new ModuloMateriaLogic().GetAllTabla(this.Materia.Id);
                }

                //Copio datos de la entidad al formulario
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }*/

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
                //falta definir lo de idplan, que esta en un combobox
           
                }
            

            if (this.Modo == ModoForm.Modificacion)
            {
                this.txtDescripcion.Enabled = false;
                this.txtHorasSemanales.Enabled = false;
                this.txtHorasTotales.Enabled = false;
                this.txtIdMateria.Enabled = false;
                this.cbxPlan.Enabled = false;
                
            }

            /*if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                int legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());

                try
                {
                    MateriaActual.IdPersona = new PersonaLogic().GetOnePorLegajo(legajo).Id;
                    MateriaActual.Habilitado = this.chkHabilitado.Checked;
                    MateriaActual.NombreMateria = this.txtMateria.Text.Trim();
                    MateriaActual.Clave = this.txtClave.Text.Trim();
                    //COMPLETAR CON LOS DATOS DE LA GRILLA. ENVIARLOS A LA ENTIDAD 
                    //USUARIO O PERSONA, SEGUN CORRESPONDAN!!!
                }
                catch (Exception e)
                {
                    this.Notificar("Se produjo un error.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (this.Modo == ModoForm.Modificacion)
                {
                    MateriaActual.Id = Convert.ToInt16(this.txtId.Text);
                    MateriaActual.State = BusinessEntity.States.Modified;
                }
            }*/

            if (this.Modo == ModoForm.Baja)
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
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
    }
}
