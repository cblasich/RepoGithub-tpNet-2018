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
    }
}
