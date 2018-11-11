using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Usuario> usuarios = new List<Usuario>();

            try 
            { 
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /* Creamos un objeto SqlCommand que sera la sentencia SQL
                 que vamos a ejecutar contra la base de datos
                 (los datos de la BD usuario, contraseña, servidor, etc.
                 estan en el connection string */

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios inner join personas ON usuarios.id_persona = personas.id_persona", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */
            
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql,
                 carga los datos en drUsuarios para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos
                 y avanza a la fila siguiente para el proximo read. */

                while (drUsuarios.Read()) //Mientras haya filas para leer...
                {
                    /* Creamos un objeto Usuario de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    Usuario usr = new Usuario();

                    if ((int)drUsuarios["id_persona"] > 0) 
                    {
                        // Ahora copiamos los datos de la fila al objeto:
                        usr.Id = (int)drUsuarios["id_usuario"];
                        usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                        usr.Clave = (string)drUsuarios["clave"];
                        usr.Habilitado = (bool)drUsuarios["habilitado"];
                        usr.IdPersona = (int)drUsuarios["id_persona"];
                        usr.Nombre = (string)drUsuarios["nombre"];
                        usr.Apellido = (string)drUsuarios["apellido"];
                        usr.Email = (string)drUsuarios["email"];
                    }
                    // Agregamos el objeto con datos a la lista que devolveremos
                    usuarios.Add(usr);
                }
                    //Cerramos el DataReader
                    drUsuarios.Close();
            }
            catch(Exception Ex) {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally {
                //Cerramos la conexion a la BD
                this.CloseConnection();
            }
                
            // Devolvemos el objeto:
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();

            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", SqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.Id = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                }

                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar datos del usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return usr;
        }
        public Usuario GetOnePorIdPersona(int idPersona)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM usuarios u " +
                    "INNER JOIN personas p ON p.id_persona = u.id_persona " +
                    "WHERE u.id_persona = @id_persona", this.SqlConn);

                cmdGetOne.Parameters.Add("@id_persona", SqlDbType.Int).Value = idPersona;
                SqlDataReader drUsuarios = cmdGetOne.ExecuteReader();
                while (drUsuarios.Read())
                {
                    usr.Id = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del usuario: " + idPersona, Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
        public void Delete(int ID)
        {
            try
            {
                //Abrimos conexion
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete1 = new SqlCommand("DELETE modulos_usuarios where id_usuario=@id", this.SqlConn);
                cmdDelete1.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlCommand cmdDelete2 = new SqlCommand("DELETE usuarios where id_usuario=@id", this.SqlConn);
                cmdDelete2.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecutamos la sentencia SQL
                cmdDelete1.ExecuteNonQuery();
                cmdDelete2.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void DeleteUsuPorIdPersona(int ID)
        {
            try
            {
                //Abrimos conexion
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecutamos la sentencia SQL
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                "habilitado = @habilitado, id_persona = @id_persona " +
                "WHERE id_usuario = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar,50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar,50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar modificar datos del usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert (Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO usuarios(nombre_usuario,clave,habilitado,id_persona) " +
                "VALUES(@nombre_usuario, @clave, @habilitado, @id_persona) " +
                "select @@identity", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdInsert.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdInsert.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdInsert.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdInsert.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                usuario.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
                //Asi se obtiene el ID que asigno la BD automaticamente.
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar crear usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.Id);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }
    }
}
