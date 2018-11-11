using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll() //este metodo es el GetAllLista de Tincho
        {
            //instanciamos el objeto lista a retornar
            List<Persona> personas = new List<Persona>();

            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /* Creamos un objeto SqlCommand que sera la sentencia SQL
                 que vamos a ejecutar contra la base de datos
                 (los datos de la BD usuario, contraseña, servidor, etc.
                 estan en el connection string */

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql,
                 carga los datos en drUsuarios para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos
                 y avanza a la fila siguiente para el proximo read. */

                while (drPersonas.Read()) //Mientras haya filas para leer...
                {
                    /* Creamos un objeto Usuario de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    Persona per = new Persona();

                    if ((int)drPersonas["id_persona"] > 0)
                    {
                        per.Id = (int)drPersonas["id_persona"];
                        per.Nombre = drPersonas["nombre"].ToString();
                        per.Apellido = drPersonas["apellido"].ToString();
                        per.Direccion = drPersonas["direccion"].ToString();
                        per.Email = drPersonas["email"].ToString();
                        per.Telefono = drPersonas["telefono"].ToString();
                        per.FechaNac = drPersonas["fecha_nac"].ToString();
                        per.Legajo = (int)drPersonas["legajo"];
                        per.TipoPersona = (int)drPersonas["tipo_persona"];
                    }

                    if (drPersonas["id_plan"] != DBNull.Value)
                    {
                        per.IdPlan = (int)(drPersonas["id_plan"]);
                    }
                    else per.IdPlan = 0;

                    // Agregamos el objeto con datos a la lista que devolveremos
                    personas.Add(per);
                }
                //Cerramos el DataReader
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                //Cerramos la conexion a la BD
                this.CloseConnection();
            }
            return personas;
        }

        public DataTable GetAllConPlanes()
        {
            DataTable alumnos = new DataTable("AlumnosConPlanes");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAllConPlanes = new SqlCommand("SELECT personas.*, planes.desc_plan FROM personas" +
                    " JOIN planes on planes.id_plan = personas.id_plan" +
                    " WHERE tipo_persona=@tipo_persona" +
                    " ORDER BY personas.legajo", SqlConn);
                cmdGetAllConPlanes.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = Enumeradores.TiposPersonas.Alumno;
                SqlDataReader drPersonasTipo = cmdGetAllConPlanes.ExecuteReader();

                alumnos.Load(drPersonasTipo);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de las personas del tipo "
                    + Enum.GetName(typeof(Enumeradores.TiposPersonas), Enumeradores.TiposPersonas.Alumno), Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnos;
        }
        public Persona GetOnePorPersona(int idPersona)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = idPersona;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    per.Id = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNac = drPersonas["fecha_nac"].ToString();
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (int)drPersonas["tipo_persona"];
                    if (drPersonas["id_plan"] != DBNull.Value)
                    {
                        per.IdPlan = (int)(drPersonas["id_plan"]);
                    }
                    else per.IdPlan = 0;
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }
        public Persona GetOnePorUsuario(int idUsuario)
        {
            Persona p = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM personas p " +
                    "INNER JOIN usuarios u ON p.id_persona = u.id_persona " +
                    "WHERE u.id_usuario = @id_usuario", this.SqlConn);

                cmdGetOne.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUsuario;
                SqlDataReader drPersona = cmdGetOne.ExecuteReader();
                while (drPersona.Read())
                {
                    p.Id = (int)drPersona["id_persona"];
                    p.Apellido = drPersona["apellido"].ToString();
                    p.Nombre = drPersona["nombre"].ToString();
                    p.Legajo = (int)drPersona["legajo"];
                    p.Telefono = drPersona["telefono"].ToString();
                    p.Email = drPersona["email"].ToString();
                    p.FechaNac = drPersona["fecha_nac"].ToString(); 
                    p.Direccion = drPersona["direccion"].ToString();
                    p.TipoPersona = (int)drPersona["tipo_persona"];
                    if (drPersona["id_plan"] != DBNull.Value)
                    {
                        p.IdPlan = (int)(drPersona["id_plan"]);
                    }
                    else p.IdPlan = 0;
                }
                drPersona.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de la Persona: " + idUsuario, Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return p;
        }

        public Persona GetOnePorLegajo(int legajo)
        {
            Persona p = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetOne = new SqlCommand("SELECT * FROM personas p " +
                    "WHERE p.legajo = @legajo", this.SqlConn);

                cmdGetOne.Parameters.Add("@legajo", SqlDbType.Int).Value = legajo;
                SqlDataReader drPersona = cmdGetOne.ExecuteReader();
                while (drPersona.Read())
                {
                    p.Id = (int)drPersona["id_persona"];
                    p.Apellido = drPersona["apellido"].ToString();
                    p.Nombre = drPersona["nombre"].ToString();
                    p.Legajo = (int)drPersona["legajo"];
                    p.Telefono = drPersona["telefono"].ToString();
                    p.Email = drPersona["email"].ToString();
                    p.FechaNac = drPersona["fecha_nac"].ToString(); ;
                    p.Direccion = drPersona["direccion"].ToString();
                    p.TipoPersona = (int)drPersona["tipo_persona"];
                    if (drPersona["id_plan"] != DBNull.Value)
                    {
                        p.IdPlan = (int)(drPersona["id_plan"]);
                    }
                    else p.IdPlan = 0;
                }
                drPersona.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos de la Persona con legajo: " + legajo, Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            
            if (p.Id == 0) throw new Exception("El legajo ingresado no corresponde a una persona registrada en el sistema.");
            else return p;
        }

        public void Delete(int idPersona, int idUsuario)
        {
            try
            {
                //Abrimos conexion
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete1 = new SqlCommand("IF EXISTS(SELECT * FROM usuarios WHERE id_usuario=@idUsu) DELETE FROM usuarios WHERE id_usuario=@idUsu", SqlConn);
                cmdDelete1.Parameters.Add("@idUsu", SqlDbType.Int).Value = idUsuario;
                SqlCommand cmdDelete2 = new SqlCommand("IF EXISTS(SELECT * FROM modulos_usuarios WHERE id_usuario=@idUsu) DELETE FROM modulos_usuarios WHERE id_usuario=@idUsu", SqlConn);
                cmdDelete2.Parameters.Add("@idUsu", SqlDbType.Int).Value = idUsuario;
                SqlCommand cmdDelete3 = new SqlCommand("DELETE personas where id_persona=@idPer", SqlConn);
                cmdDelete3.Parameters.Add("@idPer", SqlDbType.Int).Value = idPersona;
                
                //Ejecutamos la sentencia SQL
                cmdDelete1.ExecuteNonQuery();
                cmdDelete2.ExecuteNonQuery();
                cmdDelete3.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand("UPDATE personas SET nombre = @nombre, apellido = @apellido, direccion = @direccion, " +
                "email = @email, telefono = @telefono, fecha_nac = @fecha_nac, legajo = @legajo, " +
                "tipo_persona = @tipo_persona, id_plan = @id_plan WHERE id_persona = @id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = persona.Id;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdUpdate.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdUpdate.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdUpdate.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 10).Value = persona.FechaNac;
                cmdUpdate.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdUpdate.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = (int)persona.IdPlan;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                "VALUES(@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " +
                "SELECT @@identity AS id_persona", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 10).Value = persona.FechaNac;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdInsert.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                                            
                persona.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar()); //Asi se obtiene el ID que asigno la BD automaticamente.
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
