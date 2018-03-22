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
        public List<Persona> GetAllLista()
        {
            List<Persona> personas = new List<Persona>(); //instanciamos el objeto lista a retornar

            try
            {
                this.OpenConnection(); //abrimos la conexion a la base de datos con el metodo que creamos antes

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

                while (drPersonas.Read())
                {
                    /* Creamos un objeto Usuario de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    Persona per = new Persona();

                    // Ahora copiamos los datos de la fila al objeto:
                    /* private string _nombre;
                        private string _apellido;
                        private string _direccion;
                        private string _email;
                        private string _telefono;
                        private DateTime _fechaNac;
                        private int _legajo;
                        private int _tipoPersona;
                        private int _idPlan; 
                     */

                    per.Id = (int)drPersonas["id_persona"];
                    per.Nombre = drPersonas["nombre"].ToString();
                    per.Apellido = drPersonas["apellido"].ToString();
                    per.Direccion = drPersonas["direccion"].ToString();
                    per.Email = drPersonas["email"].ToString();
                    per.Telefono = drPersonas["telefono"].ToString();
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Enumeradores.TiposPersonas)drPersonas["tipo_persona"];
                    
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

            // Devolvemos el objeto:
            return personas;
        }

        public DataTable GetAllTabla()
        {
            DataTable dtPersonas = new DataTable("Personas");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAll = new SqlCommand("SELECT * FROM personas", SqlConn);
                SqlDataReader drPersonas = cmdGetAll.ExecuteReader();
                dtPersonas.Load(drPersonas);
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar la lista de personas", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return dtPersonas;
        }

        public DataTable GetAll(Enumeradores.TiposPersonas tipoPersona)
        {
            DataTable dtPersonas = new DataTable("Personas");
            try
            {
                this.OpenConnection();
                SqlCommand cmdGetAllPorTipo = new SqlCommand("SELECT * FROM personas" +
                    " WHERE tipo_persona = @tipo" +
                    " ORDER BY legajo", SqlConn);
                cmdGetAllPorTipo.Parameters.Add("@tipo", SqlDbType.Int).Value = (int)tipoPersona;
                SqlDataReader drPersonasTipo = cmdGetAllPorTipo.ExecuteReader();

                dtPersonas.Load(drPersonasTipo);
                drPersonasTipo.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar datos del " + tipoPersona.ToString(), Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return dtPersonas;
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

        public Persona GetOnePorPersona(int IdPersona)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = IdPersona;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                if (drPersonas.Read())
                {
                    per.Id = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNac = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Enumeradores.TiposPersonas)drPersonas["tipo_persona"];
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
                    p.FechaNac = (DateTime)drPersona["fecha_nac"];
                    p.Direccion = drPersona["direccion"].ToString();
                    p.TipoPersona = (Enumeradores.TiposPersonas)drPersona["tipo_persona"];
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
                    p.FechaNac = (DateTime)drPersona["fecha_nac"];
                    p.Direccion = drPersona["direccion"].ToString();
                    p.TipoPersona = (Enumeradores.TiposPersonas)drPersona["tipo_persona"];
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

        public void Delete(int ID)
        {
            try
            {
                //Abrimos conexion
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete = new SqlCommand("DELETE personas where id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecutamos la sentencia SQL
                cmdDelete.ExecuteNonQuery();
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
                "tipo_persona = @tipo_persona WHERE id_persona = @id", SqlConn);

                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = persona.Id;
                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdUpdate.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdUpdate.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdUpdate.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNac;
                cmdUpdate.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdUpdate.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
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
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona) " +
                "VALUES(@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona) " +
                "SELECT @@identity AS id_persona", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNac;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdInsert.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;

                if (persona.IdPlan != 0)
                {
                    cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
                }
                else
                {
                    cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = DBNull.Value;

                }
                
                persona.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar()); //Asi se obtiene el ID que asigno la BD automaticamente.
                
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.Id);
            }
            else if (persona.State == BusinessEntity.States.New)
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
