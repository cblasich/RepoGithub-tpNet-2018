using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<ModuloUsuario> modulosUsuarios = new List<ModuloUsuario>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios", SqlConn);
                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();
                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modUsr = new ModuloUsuario();

                    modUsr.Id = (int)drModulosUsuarios["id_modulo_usuario"];
                    modUsr.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modUsr.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modUsr.PermiteAlta = drModulosUsuarios.IsDBNull(3) ? false : (bool)drModulosUsuarios["alta"];
                    modUsr.PermiteBaja = drModulosUsuarios.IsDBNull(4) ? false : (bool)drModulosUsuarios["baja"];
                    modUsr.PermiteModificacion = drModulosUsuarios.IsDBNull(5) ? false : (bool)drModulosUsuarios["modificacion"];
                    modUsr.PermiteConsulta = drModulosUsuarios.IsDBNull(6) ? false : (bool)drModulosUsuarios["consulta"];

                    modulosUsuarios.Add(modUsr);
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de modulos de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosUsuarios;
        }
        public ModuloUsuario GetOne(int id)
        {
            ModuloUsuario modUsu = new ModuloUsuario();

            try
            {
                this.OpenConnection();
                SqlCommand cmdModUsu = new SqlCommand("select * from modulos_usuarios where id_modulo_usuario = @id", SqlConn);
                cmdModUsu.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader drModUsu = cmdModUsu.ExecuteReader();
                if (drModUsu.Read())
                {
                    modUsu.Id = (int)drModUsu["id_modulo_usuario"];
                    modUsu.IdModulo = (int)drModUsu["id_modulo"];
                    modUsu.IdUsuario = (int)drModUsu["id_usuario"];
                    modUsu.PermiteAlta = (bool)drModUsu["alta"];
                    modUsu.PermiteBaja = (bool)drModUsu["baja"];
                    modUsu.PermiteModificacion = (bool)drModUsu["modificacion"];
                    modUsu.PermiteConsulta = (bool)drModUsu["consulta"];
                }
                drModUsu.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del modulo de usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modUsu;
        }
        public void Delete(int id)
        {
            try
            {
                //Abrimos conexion
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete1 = new SqlCommand("DELETE modulos_usuarios where id_modulo_usuario=@id", this.SqlConn);
                cmdDelete1.Parameters.Add("@id", SqlDbType.Int).Value = id;

                //Ejecutamos la sentencia SQL
                cmdDelete1.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar modulo de usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(ModuloUsuario modUsu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos_usuarios SET id_usuario = @id_usuario, id_modulo = @id_modulo, " +
                "alta = @alta, baja = @baja, modificacion = @modificacion, consulta = @consulta " +
                "WHERE id_modulo_usuario = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modUsu.Id;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = modUsu.IdUsuario;
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = modUsu.IdModulo;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = modUsu.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = modUsu.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = modUsu.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = modUsu.PermiteConsulta;
                
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar modificar datos del módulo de usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario modUsu)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO modulos_usuarios(id_modulo, id_usuario, " +
                "alta, baja, modificacion, consulta) " +
                "VALUES(@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta) " +
                "select @@identity", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                //cmdSave.Parameters.Add("id_modulo_usuario", SqlDbType.Int).Value = modUsu.Id;
                cmdSave.Parameters.Add("id_modulo", SqlDbType.Int).Value = modUsu.IdModulo;
                cmdSave.Parameters.Add("id_usuario", SqlDbType.Int).Value = modUsu.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = modUsu.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = modUsu.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = modUsu.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = modUsu.PermiteConsulta;
                modUsu.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());  //Asi se obtiene el ID que asigno la BD automaticamente.
               
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar crear modulo de usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(ModuloUsuario modUsu)
        {
            if (modUsu.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modUsu.Id);
            }
            else if (modUsu.State == BusinessEntity.States.New)
            {
                this.Insert(modUsu);
            }
            else if (modUsu.State == BusinessEntity.States.Modified)
            {
                this.Update(modUsu);
            }
            modUsu.State = BusinessEntity.States.Unmodified;
        }
    }
}
