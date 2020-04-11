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
                 que vamos a ejecutar contra la base de datos */

                SqlCommand cmdPlanes = new SqlCommand("select * from planes", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql, carga los datos en drPlanes para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos y avanza a la fila siguiente para el proximo read. */

                while (drPlanes.Read()) 
                {
                    /* Creamos un objeto Plan de la capa de entidades para copiar
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

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();

            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan = @id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan.Id = (int)drPlanes["id_plan"];
                    plan.DescPlan = (string)drPlanes["desc_plan"];
                    plan.IdEspecialidad = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar datos del plan.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }

        public void Delete(int idPlan)
        {
            try
            {
                this.OpenConnection();
                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDeletePlan = new SqlCommand("delete planes where id_plan=@idPlan", SqlConn);
                cmdDeletePlan.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                //Ejecutamos la sentencia SQL
                cmdDeletePlan.ExecuteNonQuery();
            }
            catch (SqlException SqlEx)
            {
                Exception ExcepcionSqlManejada = new Exception("Plan tiene Comisiones asociadas. Debe eliminarlas antes de eliminar el plan.",SqlEx);
                throw ExcepcionSqlManejada;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO planes(desc_plan, id_especialidad) " +
                "VALUES(@desc_plan, @id_especialidad) " +
                "select @@identity",   //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.DescPlan;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                plan.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar()); //Asi se obtiene el ID que asigno la BD automaticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar crear plan.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @desc_plan, id_especialidad = @id_especialidad " +
                "WHERE id_plan = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.Id;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.DescPlan;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar modificar datos del plan.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
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
    }
}
