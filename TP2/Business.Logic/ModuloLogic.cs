using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        private ModuloAdapter _moduloData;
        public ModuloAdapter ModuloData
        {
            get { return _moduloData; }
            set { _moduloData = value; }
        }

        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }
        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }
        public Modulo GetOne(int id)
        {
            return ModuloData.GetOne(id);
        }
        public void Save(Modulo modulo)
        {
            ModuloData.Save(modulo);
        }
        public void Delete(int id)
        {
            ModuloData.Delete(id);
        }
    }
}
