using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter _usuarioData;
        public UsuarioAdapter UsuarioData
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }

        public Usuario GetOne(int id) //trae usuario por idUsuario
        {
            return UsuarioData.GetOne(id);        
        }

        
        public Usuario GetOnePorIdPersona(int idPersona) //ELIMINAR
        {
            return UsuarioData.GetOnePorIdPersona(idPersona);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public void Save(Usuario usuario)
        {
            if (ValidarNombreUsuario(usuario))
            {
                if (!ExisteUsuarioParaPersona(usuario))
                {
                    UsuarioData.Save(usuario);
                }
                else throw new Exception("La persona ingresada ya posee un usuario en el sistema.");
            }
            else throw new Exception("Lo sentimos, el nombre de usuario ingresado ya existe.");
        }

        private bool ValidarNombreUsuario(Usuario usuario)
        {
            bool valido = true;
            List<Usuario> usuarios = this.GetAll();
            foreach (Usuario u in usuarios)
            {
                if (u.NombreUsuario == usuario.NombreUsuario && u.Id != usuario.Id)
                {
                    valido = false;
                    break;
                }
            }
            return valido;
        }

        private bool ExisteUsuarioParaPersona(Usuario usuario)
        {
            bool existe = false;
            List<Usuario> usuarios = new UsuarioLogic().GetAll();
            foreach (Usuario u in usuarios)
            {
                if (u.IdPersona == usuario.IdPersona && u.Id != usuario.Id)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }

    }

}
