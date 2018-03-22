using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {

        private int _idDictado;
        private int _idCurso;
        private int _idDocente;
        private int _cargo;
        public int IdDictado
        {
            get { return _idDictado; }
            set { _idDictado = value; }
        }

        public int IdCurso
        {
            get { return _idCurso; }
            set { _idCurso = value; }
        }

        public int IdDocente
        {
            get { return _idDocente; }
            set { _idDocente = value; }
        }

        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

    }
}
