using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;
using System.Data.SqlClient;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter _planData;
        public PlanAdapter PlanData
        {
            get { return _planData; }
            set { _planData = value; }
        }
        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }
        public List<Plan> GetPlanesPorIdEspecialidad(int idEspec)
        {
            return PlanData.GetPlanesPorIdEspecialidad(idEspec);
        }
        public Plan GetOne(int id)
        {
            return PlanData.GetOne(id);
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }

        public void Delete(int id)
        {
            PlanData.Delete(id);
        }

        public DataTable GetAllDT()
        {
            return PlanData.GetAllDT();
        }
    }
}
