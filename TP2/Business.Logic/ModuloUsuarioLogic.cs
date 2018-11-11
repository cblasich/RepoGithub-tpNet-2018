using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        private ModuloUsuarioAdapter _moduloUsuarioData;
        public ModuloUsuarioAdapter ModuloUsuarioData
        {
            get { return _moduloUsuarioData; }
            set { _moduloUsuarioData = value; }
        }
        public ModuloUsuarioLogic()
        {
            ModuloUsuarioData = new ModuloUsuarioAdapter();
        }
        public List<ModuloUsuario> GetAll()
        {
            return ModuloUsuarioData.GetAll();
        }
        public ModuloUsuario GetOne(int id)
        {
            return ModuloUsuarioData.GetOne(id);
        }
        public void Save(ModuloUsuario modUsu)
        {
            ModuloUsuarioData.Save(modUsu);
        }
        public void Delete(int id)
        {
            ModuloUsuarioData.Delete(id);
        }
    }
}
