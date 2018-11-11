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
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        private Persona _personaActual;
        public Persona PersonaActual
        {
            get { return _personaActual; }
            set { _personaActual = value; }
        }
        public UsuarioDesktop()
        {
            InitializeComponent();
            CargarComboTiposPersona();
            CargarComboPlanes();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        //este constructor servirá para las altas
        {
            this.Modo = modo;
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
        public UsuarioDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            try
            {
                UsuarioLogic usuLogic = new UsuarioLogic();
                //Recupero el usuario
                this.UsuarioActual = usuLogic.GetOne(id);
                this.MapearDeDatos(); 

                /*Enumeradores.TiposPersonas tipoPersona = new PersonaLogic().GetOnePorPersona(UsuarioActual.IdPersona).TipoPersona;
                if (tipoPersona == Enumeradores.TiposPersonas.Administrador)
                {
                    //Cargo la grilla de permisos
                    dgvPermisos.AutoGenerateColumns = false;
                    dgvPermisos.DataSource = new ModuloUsuarioLogic().GetAllTabla(this.Usuario.Id);
                }*/
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    UsuarioActual = new Usuario();

                    if (!chkExistePersona.Checked) //Si la Persona NO existe
                    {
                        PersonaActual = new Persona();

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
                    else //Persona SI existe, entonces deshabilito controles del WinForm
                    {
                        this.txtNombre.Enabled = false;
                        this.txtApellido.Enabled = false;
                        this.txtEmail.Enabled = false;
                        this.txtTelefono.Enabled = false;
                        this.txtDireccion.Enabled = false;
                        this.dtpFechaNacimiento.Enabled = false;
                        this.cmbTiposPersona.Enabled = false;
                        this.cmbPlanes.Enabled = false;

                        int legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());
                        UsuarioActual.IdPersona = new PersonaLogic().GetOnePorLegajo(legajo).Id;
                    }
                }
                if (this.Modo == ModoForm.Modificacion)
                {
                    int legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());

                    UsuarioActual.Id = Convert.ToInt16(this.txtId.Text.Trim());
                    UsuarioActual.IdPersona = new PersonaLogic().GetOnePorLegajo(legajo).Id;
                    
                    PersonaLogic perLogic = new PersonaLogic();
                    this.PersonaActual = perLogic.GetOnePorPersona(UsuarioActual.IdPersona);
                    
                    PersonaActual.Nombre = this.txtNombre.Text.Trim();
                    PersonaActual.Apellido = this.txtApellido.Text.Trim();
                    PersonaActual.Email = this.txtEmail.Text.Trim();
                }
                try
                {
                    UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    UsuarioActual.NombreUsuario = this.txtUsuario.Text.Trim();
                    UsuarioActual.Clave = this.txtClave.Text.Trim();
                }
                catch (Exception e)
                {
                    this.Notificar("Se produjo un error al agregar datos del usuario.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
        public override void MapearDeDatos()
        {
            PersonaLogic pl = new PersonaLogic();
            Persona p = null;

            try
            {
                //Recupero persona correspondiente al usuario logueado
                p = pl.GetOnePorPersona(this.UsuarioActual.IdPersona);
                
                //Copio datos al formulario
                this.txtId.Text = UsuarioActual.Id.ToString();
                this.txtUsuario.Text = UsuarioActual.NombreUsuario;
                this.txtClave.Text = UsuarioActual.Clave.ToString();
                this.txtConfirmarClave.Text = UsuarioActual.Clave;
                this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
                this.txtNombre.Text = p.Nombre.ToString();
                this.txtApellido.Text = p.Apellido.ToString();
                this.txtLegajo.Text = p.Legajo.ToString();
                this.txtEmail.Text = p.Email.ToString();
                this.txtDireccion.Text = p.Direccion.ToString();
                this.txtTelefono.Text = p.Telefono.ToString();

                //Deshabilito textBoxes correspondientes a la entidad persona.
                chkExistePersona.Enabled = false;
                this.txtTelefono.Enabled = false;
                this.txtDireccion.Enabled = false;
                this.dtpFechaNacimiento.Enabled = false;
                this.cmbTiposPersona.Enabled = false;
                this.cmbPlanes.Enabled = false;
                this.txtLegajo.Enabled = false;
            }
            catch(Exception ex)
            {
                this.Notificar("Se produjo un error.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //seteo del texto del botón Aceptar según Modo del formulario
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
            UsuarioLogic usuLogic = new UsuarioLogic();
            PersonaLogic perLogic = new PersonaLogic();

            if (this.Modo == ModoForm.Alta)
            {
                Usuario usuNuevo = new Usuario();
                this.UsuarioActual = usuNuevo;
                Persona perNueva = new Persona();
                this.PersonaActual = perNueva;

                try
                {
                    this.MapearADatos();
                    if (!chkExistePersona.Checked) //check SIN TILDAR = NO existe persona todavia
                    {
                        perLogic.Save(this.PersonaActual);

                    } 
                    int legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());
                    UsuarioActual.IdPersona = new PersonaLogic().GetOnePorLegajo(legajo).Id;
                    usuLogic.Save(this.UsuarioActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
            else if (this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    //Copio datos del formulario al usuario
                    this.MapearADatos();
                    //Guardo el usuario 
                    usuLogic.Save(this.UsuarioActual);
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
                    //Elimino el usuario
                    usuLogic.Delete(UsuarioActual.Id);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override bool Validar() 
        /* método que devuelva si los datos son válidos para poder
        registrar los cambios realizados.*/
        {
            string mensaje = "";
            if (!chkExistePersona.Checked) //si persona NO existe
            {
                if (String.IsNullOrEmpty(this.txtNombre.Text.Trim()))
                {
                    mensaje += "- Complete el campo Nombre.\n";
                }
                if (String.IsNullOrEmpty(this.txtApellido.Text.Trim()))
                {
                    mensaje += "- Complete el campo Apellido.\n";
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
            }
            else
            {
                if (String.IsNullOrEmpty(this.txtUsuario.Text.Trim()))
                {
                    mensaje += "- Complete el campo Usuario.\n";
                }
                if (String.IsNullOrEmpty(this.txtClave.Text))
                {
                    mensaje += "- Complete el campo Clave.\n";
                }
                if (String.IsNullOrEmpty(this.txtConfirmarClave.Text))
                {
                    mensaje += "- Complete el campo Confirmar clave.\n";
                }
                if (this.txtClave.Text != this.txtConfirmarClave.Text)
                {
                    mensaje += "- Los campos Clave y Confirmar clave no coinciden.\n";
                }
                if (this.txtClave.Text.Length < 8)
                {
                    mensaje += "- La clave debe tener al menos 8 caracteres.\n";
                }
                if (String.IsNullOrEmpty(this.txtLegajo.Text))
                {
                    mensaje += "- Complete el legajo\n";
                }
                else if (this.txtLegajo.Text.Length != 5)
                {
                    mensaje += "- El legajo de la persona asociada debe tener 5 dígitos\n";
                }
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
        private void chkExistePersona_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExistePersona.Checked) {
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtEmail.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
                dtpFechaNacimiento.Enabled = false;
                cmbPlanes.Enabled = false;
                cmbTiposPersona.Enabled = false;
            }
            else
            {
                txtNombre.Enabled = true;
                txtEmail.Enabled = true;
                dtpFechaNacimiento.Enabled = true;
                cmbPlanes.Enabled = true;
                txtApellido.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
                cmbTiposPersona.Enabled = true;
            }
        }
    }
}
