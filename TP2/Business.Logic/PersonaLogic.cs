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
        public List<Persona> GetAll()
        {
            try
            {
                return PersonaData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
        }
        public DataTable GetAllConPlanes()
        {
            return PersonaData.GetAllConPlanes();
        }
        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                if (this.ValidarLegajo(persona))
                {
                    this.PersonaData.Save(persona);
                }
                else throw new Exception("El legajo ingresado ya existe.");
            }
            if (persona.State == BusinessEntity.States.Modified)
            {
                this.PersonaData.Save(persona);
            }
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.PersonaData.Save(persona);
            }
        }

        public bool ValidarLegajo(Persona persona)
        {
            bool valido = true;
            List<Persona> personas = this.GetAll();
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

        public void Delete(int idPersona, int idUsuario)
        {
            this.PersonaData.Delete(idPersona, idUsuario);
        }

    }
}
