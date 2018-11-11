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
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo):this () 
        //este constructor servirá para las altas
        {
            this.Modo = modo;
        }

        public EspecialidadDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            this.EspecialidadActual = especialidadLogic.GetOne(id);
            this.MapearDeDatos();
        }

        private Especialidad _especialidadActual;
        public Especialidad EspecialidadActual
        {
            get { return _especialidadActual; }
            set { _especialidadActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtIdEspecialidad.Text = this.EspecialidadActual.Id.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.DescEspecialidad;

            //seteo del texto del botón Aceptar según Modo del formulario
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Especialidad";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Especialidad";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Especialidad";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Especialidad";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                EspecialidadActual = new Especialidad();
                EspecialidadActual.State = BusinessEntity.States.New;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.DescEspecialidad = this.txtDescripcion.Text.Trim();

                if (this.Modo == ModoForm.Modificacion)
                {
                    EspecialidadActual.Id = Convert.ToInt16(this.txtIdEspecialidad.Text);
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                EspecialidadActual.State = BusinessEntity.States.Deleted;
            }
            if (this.Modo == ModoForm.Consulta)
            {
                EspecialidadActual.State = BusinessEntity.States.Unmodified;
            }
        }
        public override void GuardarCambios()
        {
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            if (this.Modo == ModoForm.Alta)
            {
                Especialidad especNueva = new Especialidad();
                this.EspecialidadActual = especNueva;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    this.MapearADatos();
                    especialidadLogic.Save(this.EspecialidadActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                PlanLogic planLogic = new PlanLogic();
                List<Plan> planes = new List<Plan>();
                planes = planLogic.GetPlanesPorIdEspecialidad(this.EspecialidadActual.Id);
                if (planes.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Hay planes asociados a la especialidad elegida. Si elimina la especialidad, se borrarán dichos planes. Continuar de todos modos?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.Yes))
                    {
                        //traer el id de cada plan de planes y set null el id_plan de las personas afectadas a ese plan
                        foreach (Plan p in planes)
                        {
                            especialidadLogic.SetNullPlanDePersona(p.Id);
                        }
                        especialidadLogic.Delete(EspecialidadActual.Id);
                    }
                    else
                    {
                        this.Close();
                    }
                }
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
