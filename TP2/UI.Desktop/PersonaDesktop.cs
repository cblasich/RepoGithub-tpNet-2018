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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
            CargarComboTiposPersona();
            CargarComboPlanes();
        }

        public PersonaDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
        }
        public PersonaDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            try
            {
                PersonaLogic perLogic = new PersonaLogic();
                this.PersonaActual = perLogic.GetOnePorPersona(id);
                this.MapearDeDatos();
            }
             catch(Exception e)
            {
                this.Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Persona _personaActual;
        public Persona PersonaActual
        {
            get { return _personaActual; }
            set { _personaActual = value; }
        }

        private void CargarComboTiposPersona()
        {
            this.cmbTiposPersona.DataSource = Enum.GetValues(typeof(Enumeradores.TiposPersonas));
        }
        private void CargarComboPlanes()
        {
            PlanLogic planLogic = new PlanLogic();
            this.cmbPlanes.ValueMember = "id_plan";
            this.cmbPlanes.DisplayMember = "desc_plan";
            this.cmbPlanes.DataSource = planLogic.GetAllDT();
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                PersonaActual = new Persona();
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Modificacion)
                {
                    PersonaActual.Id = Convert.ToInt16(this.txtId.Text.Trim());
                }
                PersonaActual.Nombre = this.txtNombre.Text.Trim();
                PersonaActual.Apellido = this.txtApellido.Text.Trim();
                PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());
                PersonaActual.Email = this.txtEmail.Text.Trim();
                PersonaActual.Telefono = this.txtTelefono.Text.Trim();
                PersonaActual.Direccion = this.txtDireccion.Text.Trim();
                PersonaActual.FechaNac = this.dtpFechaNacimiento.Value.ToString();
                PersonaActual.TipoPersona = (int)this.cmbTiposPersona.SelectedItem;
                PersonaActual.IdPlan = (int)this.cmbPlanes.SelectedValue;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
        public override void MapearDeDatos()
        {
            this.txtId.Text = PersonaActual.Id.ToString();
            this.txtApellido.Text = PersonaActual.Apellido;
            this.txtNombre.Text = PersonaActual.Nombre;
            this.txtDireccion.Text = PersonaActual.Direccion;
            this.txtEmail.Text = PersonaActual.Email;
            this.txtLegajo.Text = PersonaActual.Legajo.ToString();
            this.txtTelefono.Text = PersonaActual.Telefono;
            this.dtpFechaNacimiento.Value = Convert.ToDateTime(PersonaActual.FechaNac);
            this.cmbTiposPersona.DisplayMember = PersonaActual.TipoPersona.ToString();
            this.cmbPlanes.SelectedValue = PersonaActual.IdPlan;

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Persona";
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    this.Text = "Modificacion de Persona";
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.Text = "Baja de Persona";
                    btnAceptar.Text = "Eliminar";
                    //this.BloquearControles();
                    break;
                case ModoForm.Consulta:
                    this.Text = "Consulta de Persona";
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void GuardarCambios()
        {
            PersonaLogic perLogic = new PersonaLogic();
            if (this.Modo == ModoForm.Alta)
            {
                Persona perNueva = new Persona();
                this.PersonaActual = perNueva;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    this.MapearADatos();
                    perLogic.Save(this.PersonaActual);
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
                    UsuarioLogic usuLogic = new UsuarioLogic();
                    Usuario usuActual = new Usuario();
                    usuActual = usuLogic.GetOnePorIdPersona(this.PersonaActual.Id);
                    //Elimino la persona. El usuario lo elimino desde la capa de datos
                    perLogic.Delete(PersonaActual.Id, usuActual.Id);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override bool Validar()
        {
            string mensaje = "";
            if (String.IsNullOrEmpty(this.txtApellido.Text))
            {
                mensaje += "- Complete el apellido\n";
            }
            if (String.IsNullOrEmpty(this.txtNombre.Text))
            {
                mensaje += "- Complete el nombre\n";
            }
            if (String.IsNullOrEmpty(this.txtDireccion.Text))
            {
                mensaje += "- Complete la direccion\n";
            }
            if (String.IsNullOrEmpty(this.txtEmail.Text))
            {
                mensaje += "- Complete el email\n";
            }
            if (String.IsNullOrEmpty(this.txtLegajo.Text))
            {
                mensaje += "- Complete el legajo\n";
            }
            else if (this.txtLegajo.Text.Length != 5)
            {
                mensaje += "- El legajo de la persona asociada debe tener 5 dígitos\n";
            }
            if (String.IsNullOrEmpty(this.txtTelefono.Text))
            {
                mensaje += "- Complete el telefono\n";
            }
            if (String.IsNullOrEmpty(this.dtpFechaNacimiento.Text))
            {
                mensaje += "- Complete la fecha de nacimiento\n";
            }
            
            if (!Validaciones.ValidarEmail(this.txtEmail.Text))
            {
                mensaje += "- El email ingresado no es válido\n";
            }
            if (mensaje.Length == 0)
            {
                return true;
            }
            else
            {
                this.Notificar("Advertencia", mensaje, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
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
