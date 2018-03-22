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

        public override void MapearADatos()
        /* se va a utilizar para pasar la información de los controles
         a una entidad para luego enviarla a las capas inferiores */
        {
            if (this.Modo == ModoForm.Alta)
            {
                PersonaActual = new Persona();
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.PersonaActual.Nombre = this.txtNombre.Text.Trim();
                this.PersonaActual.Apellido = this.txtApellido.Text.Trim();
                this.PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());
                this.PersonaActual.Email = this.txtEmail.Text.Trim();
                this.PersonaActual.Telefono = this.txtTelefono.Text.Trim();
                this.PersonaActual.Direccion = this.txtDireccion.Text.Trim();
                this.PersonaActual.FechaNac = this.dtpFechaNacimiento.Value;
                this.PersonaActual.TipoPersona = (Enumeradores.TiposPersonas)this.cmbTiposPersona.SelectedItem;

                
                if (this.Modo == ModoForm.Modificacion)
                {
                    PersonaActual.Id = Convert.ToInt16(this.txtId.Text.Trim());
                }
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
        /* va a ser utilizado en cada formulario para copiar la
         información de las entidades a los controles del formulario (TextBox,
         ComboBox, etc) para mostrar la información de cada entidad */
        {
            this.txtId.Text = this.PersonaActual.Id.ToString();
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.dtpFechaNacimiento.Value = this.PersonaActual.FechaNac;

            switch (this.Modo)
            {
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
            PersonaLogic pl = new PersonaLogic();
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                //Copio datos del formulario a la persona
                this.MapearADatos();
                try
                {
                    pl.Save(this.PersonaActual);
                }
                catch (Exception e)
                {
                    this.Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                try
                {
                    //Elimino la persona
                    pl.Delete(PersonaActual.Id);
                }
                catch (Exception e)
                {
                    this.Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
