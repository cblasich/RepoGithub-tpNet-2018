using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        private string _descPlan;
        private int _idEspecialidad;

        public string DescPlan
        {
            get { return _descPlan; }
            set { _descPlan = value; }
        }

        public int IdEspecialidad
        {
            get { return _idEspecialidad; }
            set { _idEspecialidad = value; }
        }
    }
}
