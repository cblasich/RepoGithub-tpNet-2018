using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Usuarios());
            //Application.Run(new Personas());
            //Application.Run(new Especialidades());
            //Application.Run(new Modulos());
            //Application.Run(new Cursos());
            //Application.Run(new Materias());
            Application.Run(new Comisiones());
            //Application.Run(new MateriaDesktop(20,ApplicationForm.ModoForm.Modificacion));
        }
    }
}
