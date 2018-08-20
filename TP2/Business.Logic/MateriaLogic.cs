using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriaAdapter _materiaData;
        public MateriaAdapter MateriaData
        {
            get { return _materiaData; }
            set { _materiaData = value; }
        }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
        }

        public Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);        
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }

        public void Save(Materia materia)
        {
                    MateriaData.Save(materia);
               
        }

       /* private bool ValidarNombreMateria(Materia materia)
        {
            bool valido = true;
            List<Materia> materias = this.GetAll();
            foreach (Materia u in materias)
            {
                if (u.NombreMateria == materia.NombreMateria && u.Id != materia.Id)
                {
                    valido = false;
                    break;
                }
            }
            return valido;
        }*/

        /*private bool ExisteMateriaParaPersona(Materia materia)
        {
            bool existe = false;
            List<Materia> materias = new MateriaLogic().GetAll();
            foreach (Materia u in materias)
            {
                if (u.IdPersona == materia.IdPersona && u.Id != materia.Id)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }*/

    }



    }

