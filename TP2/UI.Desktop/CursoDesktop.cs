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
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }

         public CursoDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
        }

        public CursoDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            CursoLogic cursoLogic = new CursoLogic();
            this.CursoActual = cursoLogic.GetOne(id);
            this.MapearDeDatos();
        }

        private Curso _cursoActual;
        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }

        public override void MapearDeDatos()
        /* va a ser utilizado en cada formulario para copiar la
         información de las entidades a los controles del formulario (TextBox,
         ComboBox, etc) para mostrar la infromación de cada entidad */
        {
            
            this.txtIdMateria.Text = this.CursoActual.IdMateria.ToString();
            this.txtIdComision.Text = this.CursoActual.IdComision.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtAnio.Text = this.CursoActual.AnioCalendario.ToString();

            //seteo del texto del botón Aceptar según Modo del formulario
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Curso";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Curso";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Curso";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Curso";
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
                CursoActual = new Curso();
                CursoActual.State = BusinessEntity.States.New;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text.Trim());
                CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnio.Text.Trim());

                if (this.Modo == ModoForm.Modificacion)
                {
                    CursoActual.Id = Convert.ToInt16(this.textIdCurso.Text);
                    CursoActual.State = BusinessEntity.States.Modified;
                }
            }

            if (this.Modo == ModoForm.Baja)
            {
                CursoActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override void GuardarCambios()
        /* método que se encargará de invocar al método correspondiente 
        de la capa de negocio según sea el ModoForm en que se encuentre el formulario*/
        {
            this.MapearADatos();
            CursoLogic cursoLogic = new CursoLogic();
            cursoLogic.Save(this.CursoActual);

        }
        public override bool Validar()
        /* método que devuelva si los datos son válidos para poder
        registrar los cambios realizados.*/
        {
            string mensaje = "";

            if (String.IsNullOrEmpty(this.txtCupo.Text.Trim()))
            {
                mensaje += "- Complete el campo Cupo.\n";
            }

            if (String.IsNullOrEmpty(this.txtAnio.Text.Trim()))
            {
                mensaje += "- Complete el campo Año.\n";
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

    }
}
