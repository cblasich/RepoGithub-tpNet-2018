using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;
using System.Data;
using Util;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _personaData;
        public PersonaAdapter PersonaData
        {
            get { return _personaData; }
            set { _personaData = value; }
        }

        public PersonaLogic()
        {
            this.PersonaData = new PersonaAdapter();
        }

        public Persona GetOnePorPersona(int idPersona)
        {
            return PersonaData.GetOnePorPersona(idPersona);
        }

        public Persona GetOnePorUsuario(int idUsuario)
        {
            return PersonaData.GetOnePorUsuario(idUsuario);
        }

        public Persona GetOnePorLegajo(int legajo)
        {
            return PersonaData.GetOnePorLegajo(legajo);
        }

        public DataTable GetAllTabla()
        {
            return PersonaData.GetAllTabla();
        }

        public List<Persona> GetAllLista()
        {
            return PersonaData.GetAllLista();
        }

        public DataTable GetAll(Enumeradores.TiposPersonas tipoPersona)
        {
            return PersonaData.GetAll(tipoPersona);
        }

        public DataTable GetAllConPlanes()
        {
            return PersonaData.GetAllConPlanes();
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New || persona.State == BusinessEntity.States.Modified)
            {
                if (this.ValidarLegajo(persona))
                {
                    this.PersonaData.Save(persona);
                }
                else throw new Exception("El legajo ingresado ya existe.");
            }
        }

        public bool ValidarLegajo(Persona persona)
        {
            bool valido = true;
            List<Persona> personas = this.GetAllLista();
            foreach (Persona p in personas)
            {
                if (p.Legajo == persona.Legajo && p.Id != persona.Id)
                {
                    valido = false;
                    break;
                }
            }
            return valido;
        }

        public void Delete(int ID)
        {
            this.PersonaData.Delete(ID);
        }

    }
}
