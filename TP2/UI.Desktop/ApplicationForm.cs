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


namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
        }

        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }

        private ModoForm _modo;

        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }
        
        public virtual void MapearDeDatos()
        /* va a ser utilizado en cada formulario para copiar la
         información de las entidades a los controles del formulario (TextBox,
         ComboBox, etc) para mostrar la infromación de cada entidad */
        { }

        public virtual void MapearADatos() { }
        /* se va a utilizar para pasar la información de los controles
        a una entidad para luego enviarla a las capas inferiores */
        
        public virtual void GuardarCambios() { }
        /* método que se encargará de invocar al método correspondiente 
        de la capa de negocio según sea el ModoForm en que se encuentre el formulario*/

        public virtual bool Validar() { return false; }
        /* método que devuelva si los datos son válidos para poder
        registrar los cambios realizados.*/
        
        public virtual void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        /* Notificar es el método que utilizaremos para unificar el mecanismo de
        avisos al usuario y en caso de tener que modificar la forma en que se
        realizan los avisos al usuario sólo se debe modificar este método, en
        lugar de tener que reemplazarlo en toda la aplicación.*/
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public virtual void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

    }
}
