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
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        private Usuario _usuarioActual;

        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        //PROBANDO
        private Persona _personaActual;

        public Persona PersonaActual
        {
            get { return _personaActual; }
            set { _personaActual = value; }
        }

        public UsuarioDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
            this.UsuarioActual = new Usuario();
            //PROBANDO
            this.PersonaActual = new Persona();
        }

        public UsuarioDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            UsuarioLogic userLogic = new UsuarioLogic();
            try
            {
                //Recupero el usuario
                this.UsuarioActual = userLogic.GetOne(id);

                /*Enumeradores.TiposPersonas tipoPersona = new PersonaLogic().GetOnePorPersona(UsuarioActual.IdPersona).TipoPersona;
                if (tipoPersona == Enumeradores.TiposPersonas.Administrador)
                {
                    //Cargo la grilla de permisos
                    dgvPermisos.AutoGenerateColumns = false;
                    dgvPermisos.DataSource = new ModuloUsuarioLogic().GetAllTabla(this.Usuario.Id);
                }*/

                //Copio datos de la entidad al formulario
                this.MapearDeDatos();
            }
            catch (Exception e)
            {
                this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        

        public override void MapearDeDatos()
        /* va a ser utilizado en cada formulario para copiar la
         información de las entidades a los controles del formulario (TextBox,
         ComboBox, etc) para mostrar la información de cada entidad */
        {
            PersonaLogic pl = new PersonaLogic();
            Persona p = null;


            try
            {
                //Recupero persona correspondiente al usuario logueado
                p = pl.GetOnePorPersona(this.UsuarioActual.IdPersona);
                
                //Copio datos al formulario
                this.txtId.Text = this.UsuarioActual.Id.ToString();
                this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
                this.txtNombre.Text = p.Nombre.ToString();
                this.txtApellido.Text = p.Apellido.ToString();
                this.txtEmail.Text = p.Email.ToString();
                this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
                this.txtClave.Text = this.UsuarioActual.Clave.ToString();
                this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

                //Deshabilito textBoxes correspondientes a la entidad persona.
                this.txtDireccion.Enabled = false;
                this.txtTelefono.Enabled = false;
                this.txtTipoPersona.Enabled = false;
                this.txtLegajo.Enabled = false;
                this.txtIdPlan.Enabled = false;
                this.dtpFechaNac.Enabled = false;
                

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

        public override void MapearADatos() 
        /* se va a utilizar para pasar la información de los controles
        a una entidad para luego enviarla a las capas inferiores */
        {
            if (this.Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
                UsuarioActual.State = BusinessEntity.States.New;

                if (!chkExistePersona.Checked) //Si la Persona NO existe
                {
                    PersonaActual = new Persona();

                    PersonaActual.Nombre = this.txtNombre.Text.Trim();
                    PersonaActual.Apellido = this.txtApellido.Text.Trim();
                    PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());
                    PersonaActual.Email = this.txtEmail.Text.Trim();
                    PersonaActual.FechaNac = this.dtpFechaNac.Value;
                    PersonaActual.IdPlan = Convert.ToInt32(this.txtIdPlan.Text.Trim());
                    PersonaActual.Telefono = this.txtTelefono.Text.Trim();
                    PersonaActual.Direccion = this.txtDireccion.Text.Trim();
                    //PersonaActual.TipoPersona = this.txtTipoPersona.Text.Trim();
                }
            }

            if (this.Modo == ModoForm.Modificacion)
            {
                chkExistePersona.Enabled = false;
                this.txtDireccion.Enabled = false;
                this.txtTelefono.Enabled = false;
                this.txtTipoPersona.Enabled = false;
                this.txtLegajo.Enabled = false;
                this.txtIdPlan.Enabled = false;
                this.dtpFechaNac.Enabled = false;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                int legajo = Convert.ToInt32(this.txtLegajo.Text.Trim());

                try
                {
                    UsuarioActual.IdPersona = new PersonaLogic().GetOnePorLegajo(legajo).Id;
                    UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    UsuarioActual.NombreUsuario = this.txtUsuario.Text.Trim();
                    UsuarioActual.Clave = this.txtClave.Text.Trim();
                    //COMPLETAR CON LOS DATOS DE LA GRILLA. ENVIARLOS A LA ENTIDAD 
                    //USUARIO O PERSONA, SEGUN CORRESPONDAN!!!
                }
                catch(Exception e)
                {
                    this.Notificar("Se produjo un error.", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (this.Modo == ModoForm.Modificacion)
                {
                    UsuarioActual.Id = Convert.ToInt16(this.txtId.Text);
                    UsuarioActual.State = BusinessEntity.States.Modified;
                }
            }

            if (this.Modo == ModoForm.Baja)
            {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override void GuardarCambios() 
        /* método que se encargará de invocar al método correspondiente 
        de la capa de negocio según sea el ModoForm en que se encuentre el formulario*/
        {
            UsuarioLogic usuLogic = new UsuarioLogic();
            PersonaLogic perLogic = new PersonaLogic();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    //Copio datos del formulario al usuario
                    this.MapearADatos();
                    //Guardo el usuario y la persona
                    usuLogic.Save(this.UsuarioActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (this.Modo == ModoForm.Alta)
            {
                try
                {
                    if (!chkExistePersona.Checked) //check SIN TILDAR = NO existe persona todavia
                    {
                        perLogic.Save(this.PersonaActual);
                    }
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

            if (String.IsNullOrEmpty(this.txtNombre.Text.Trim()))
            {
                mensaje += "- Complete el campo Nombre.\n";
            }

            if (String.IsNullOrEmpty(this.txtApellido.Text.Trim()))
            {
                mensaje += "- Complete el campo Apellido.\n";
            }

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
        /* Notificar es el método que utilizaremos para unificar el mecanismo de
        avisos al usuario y en caso de tener que modificar la forma en que se
        realizan los avisos al usuario sólo se debe modificar este método, en
        lugar de tener que reemplazarlo en toda la aplicación.*/
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public override void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
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
             /*If CheckBox1.Checked = True Then
                TextBox3.enabled=true
                TextBox4.enabled=true
             else
                TextBox3.enabled=false
                TextBox4.enabled=false
             end if */
            if (chkExistePersona.Checked) {
                txtNombre.Enabled = false;
                txtEmail.Enabled = false;
                dtpFechaNac.Enabled = false;
                txtIdPlan.Enabled = false;
                txtApellido.Enabled = false;
                txtDireccion.Enabled = false;
                txtTelefono.Enabled = false;
                txtTipoPersona.Enabled = false;
            }
            else
            {
                txtNombre.Enabled = true;
                txtEmail.Enabled = true;
                dtpFechaNac.Enabled = true;
                txtIdPlan.Enabled = true;
                txtApellido.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
                txtTipoPersona.Enabled = true;
            }
        }


    }
}
