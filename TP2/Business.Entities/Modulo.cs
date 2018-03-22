using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Modulo : BusinessEntity
    {
        private string _descModulo;

        public string DescModulo
        {
            get { return _descModulo; }
            set { _descModulo = value; }
        }

        private string _ejecuta;

        public string Ejecuta
        {
            get { return _ejecuta; }
            set { _ejecuta = value; }
        }
    }
}
