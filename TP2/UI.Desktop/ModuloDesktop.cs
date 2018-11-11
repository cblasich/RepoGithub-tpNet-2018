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

namespace UI.Desktop
{
    public partial class ModuloDesktop : ApplicationForm
    {
        public ModuloDesktop()
        {
            InitializeComponent();
        }
        public ModuloDesktop(ModoForm modo):this () //para altas
        {
            this.Modo = modo;
        }
        public ModuloDesktop(int id, ModoForm modo):this()
        {
            this.Modo = modo;
            ModuloLogic modLogic = new ModuloLogic();
            this.ModuloActual = modLogic.GetOne(id);
            this.MapearDeDatos();
        }

        private Modulo _moduloActual;
        public Modulo ModuloActual
        {
            get { return _moduloActual; }
            set { _moduloActual = value; }
        }
        public override void MapearDeDatos()
        {
            this.txtIdModulo.Text = this.ModuloActual.Id.ToString();
            this.txtDescripcion.Text = this.ModuloActual.DescModulo;
            this.txtEjecuta.Text = this.ModuloActual.Ejecuta;

            //seteo del texto del botón Aceptar según Modo del formulario
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.Text = "Alta de Modulo";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    this.Text = "Modificación de Modulo";
                    this.btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    this.Text = "Baja de Modulo";
                    this.btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    this.Text = "Consulta de Modulo";
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                ModuloActual = new Modulo();
                ModuloActual.State = BusinessEntity.States.New;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                ModuloActual.DescModulo = this.txtDescripcion.Text.Trim();
                ModuloActual.Ejecuta = this.txtEjecuta.Text.Trim();
                
                if (this.Modo == ModoForm.Modificacion)
                {
                    ModuloActual.Id = Convert.ToInt16(this.txtIdModulo.Text);
                    ModuloActual.State = BusinessEntity.States.Modified;
                }
            }
            if (this.Modo == ModoForm.Baja)
            {
                ModuloActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override void GuardarCambios()
        {
            ModuloLogic modLogic = new ModuloLogic();
            if (this.Modo == ModoForm.Alta)
            {
                Modulo modNuevo = new Modulo();
                this.ModuloActual = modNuevo;
            }
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                try
                {
                    this.MapearADatos();
                    modLogic.Save(this.ModuloActual);
                }
                catch (Exception e)
                {
                    this.Notificar(this.Text, e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                //buscar modulos_usuario con id_modulo a eliminar.
                //Si cantidad>0 , entonces avisar que no se puede eliminar
                //Si cantidad == 0 eliminar el modulo requerido.
                try
                {
                    modLogic.Delete(ModuloActual.Id);
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

            if (String.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                mensaje += "- Complete el campo Descripción.\n";
            }

            if (String.IsNullOrEmpty(this.txtEjecuta.Text.Trim()))
            {
                mensaje += "- Complete el campo Ejecuta.\n";
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
