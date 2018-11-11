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
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll() //este metodo es el GetAllLista de Tincho
        {
            //instanciamos el objeto lista a retornar
            List<Plan> planes = new List<Plan>();
            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /* Creamos un objeto SqlCommand que sera la sentencia SQL
                 que vamos a ejecutar contra la base de datos
                 (los datos de la BD usuario, contraseña, servidor, etc.
                 estan en el connection string */

                SqlCommand cmdPlanes = new SqlCommand("select * from planes", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql, carga los datos en drUsuarios para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos y avanza a la fila siguiente para el proximo read. */

                while (drPlanes.Read()) 
                {
                    /* Creamos un objeto Usuario de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/
                    Plan plan = new Plan();
                    if ((int)drPlanes["id_plan"] > 0)
                    {
                        // Ahora copiamos los datos de la fila al objeto:
                        plan.Id = (int)drPlanes["id_plan"];
                        plan.DescPlan = drPlanes["desc_plan"].ToString();
                        plan.IdEspecialidad = (int)drPlanes["id_especialidad"];
                    }
                    if (drPlanes["id_plan"] != DBNull.Value)
                    {
                        plan.Id = (int)(drPlanes["id_plan"]);
                    }
                    else plan.Id = 0;

                    // Agregamos el objeto con datos a la lista que devolveremos
                    planes.Add(plan);
                }
                //Cerramos el DataReader
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                //Cerramos la conexion a la BD
                this.CloseConnection();
            }
            // Devolvemos el objeto:
            return planes;
        }

        public DataTable GetAllDT()
        {
            this.OpenConnection();
            DataTable dtPlanes = new DataTable();
            SqlCommand cmdPlanes = new SqlCommand("select * from planes", SqlConn);
            SqlDataAdapter daPlanes = new SqlDataAdapter(cmdPlanes);
            daPlanes.Fill(dtPlanes);
            return dtPlanes;
        }

        public List<Plan> GetPlanesPorIdEspecialidad(int idEspec)
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_especialidad = @idEspec", SqlConn);
                cmdPlanes.Parameters.Add("@idEspec", SqlDbType.Int).Value = idEspec;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = new Plan();
                    plan.Id = (int)drPlanes["id_plan"];
                    plan.DescPlan = (string)drPlanes["desc_plan"];
                    plan.IdEspecialidad = idEspec;
                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar planes por el id especialidad.", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }
       

        //public void Delete(int idPersona, int idUsuario)
        //{
        //    try
        //    {
        //        //Abrimos conexion
        //        this.OpenConnection();

        //        //Creamos la sentencia SQL y asignamos un valor al parametro
        //        SqlCommand cmdDelete1 = new SqlCommand("IF EXISTS(SELECT * FROM usuarios WHERE id_usuario=@idUsu) DELETE FROM usuarios WHERE id_usuario=@idUsu", SqlConn);
        //        cmdDelete1.Parameters.Add("@idUsu", SqlDbType.Int).Value = idUsuario;
        //        SqlCommand cmdDelete2 = new SqlCommand("IF EXISTS(SELECT * FROM modulos_usuarios WHERE id_usuario=@idUsu) DELETE FROM modulos_usuarios WHERE id_usuario=@idUsu", SqlConn);
        //        cmdDelete2.Parameters.Add("@idUsu", SqlDbType.Int).Value = idUsuario;
        //        SqlCommand cmdDelete3 = new SqlCommand("DELETE personas where id_persona=@idPer", SqlConn);
        //        cmdDelete3.Parameters.Add("@idPer", SqlDbType.Int).Value = idPersona;



        //        //Ejecutamos la sentencia SQL
        //        cmdDelete1.ExecuteNonQuery();
        //        cmdDelete2.ExecuteNonQuery();
        //        cmdDelete3.ExecuteNonQuery();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al eliminar persona.", Ex);
        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}


        //protected void Update(Persona persona)
        //{
        //    try
        //    {
        //        this.OpenConnection();
        //        SqlCommand cmdUpdate = new SqlCommand("UPDATE personas SET nombre = @nombre, apellido = @apellido, direccion = @direccion, " +
        //        "email = @email, telefono = @telefono, fecha_nac = @fecha_nac, legajo = @legajo, " +
        //        "tipo_persona = @tipo_persona WHERE id_persona = @id", SqlConn);

        //        cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = persona.Id;
        //        cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
        //        cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
        //        cmdUpdate.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
        //        cmdUpdate.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
        //        cmdUpdate.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
        //        cmdUpdate.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 10).Value = persona.FechaNac;
        //        cmdUpdate.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
        //        cmdUpdate.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
        //        cmdUpdate.ExecuteNonQuery();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona.", Ex);
        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}
        //protected void Insert(Persona persona)
        //{
        //    try
        //    {
        //        this.OpenConnection();
        //        SqlCommand cmdInsert = new SqlCommand("INSERT INTO personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
        //        "VALUES(@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " +
        //        "SELECT @@identity AS id_persona", //linea para recuperar el ID que asigno el Sql automaticamente
        //        SqlConn);

        //        cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
        //        cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
        //        cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
        //        cmdInsert.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
        //        cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
        //        cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.VarChar, 10).Value = persona.FechaNac;
        //        cmdInsert.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
        //        cmdInsert.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
        //        cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;

        //        persona.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar()); //Asi se obtiene el ID que asigno la BD automaticamente.

        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al crear persona.", Ex);
        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //}
        //public void Save(Plan plan)
        //{
        //    if (plan.State == BusinessEntity.States.New)
        //    {
        //        this.Insert(plan);
        //    }
        //    else if (plan.State == BusinessEntity.States.Modified)
        //    {
        //        this.Update(plan);
        //    }
        //    plan.State = BusinessEntity.States.Unmodified;
        //}
    }
}
