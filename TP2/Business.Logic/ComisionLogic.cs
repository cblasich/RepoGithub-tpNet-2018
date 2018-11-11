using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {

        private ComisionAdapter _comisionData;
        public ComisionAdapter ComisionData
        {
            get { return _comisionData; }
            set { _comisionData = value; }
        }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
        }

        public Comision GetOne(int id)
        {
            return ComisionData.GetOne(id);        
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }

        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
               
        }
    }
}
