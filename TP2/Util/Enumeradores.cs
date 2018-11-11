using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Enumeradores
    {
        public enum TiposPersonas
        {
            Alumno=1,
            Docente,
            Administrador
        }

        public enum NrosTipos
        {
            al,
            doc,
            admin
        }

        public enum TiposCargos
        {
            Titular,
            Auxiliar,
            JTP
        }

        public enum Condiciones
        {
            Inscripto,
            Aprobado,
            Libre
        }
    }
}
