using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic  : BusinessLogic
    {
        private EspecialidadAdapter _especialidadData;
        public EspecialidadAdapter EspecialidadData
        {
            get { return _especialidadData; }
            set { _especialidadData = value; }
        }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public Especialidad GetOne(int id)
        {
            return EspecialidadData.GetOne(id);
        }

        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
        }
        public void SetNullPlanDePersona(int idPlan)
        {
            EspecialidadData.SetNullPlanDePersona(idPlan);
        }
        public void Delete(int idEspec)
        {
            EspecialidadData.Delete(idEspec);
        }
    }
}
