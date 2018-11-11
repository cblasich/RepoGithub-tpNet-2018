using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public List<Especialidad> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", SqlConn);
                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                /* Read() lee una fila de las devueltas por el comando sql,
                 carga los datos en drEspecialidades para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos
                 y avanza a la fila siguiente para el proximo read. */

                while (drEspecialidades.Read())
                {
                    /* Creamos un objeto Especialidade de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    Especialidad especialidad = new Especialidad();

                    // Ahora copiamos los datos de la fila al objeto:

                    especialidad.Id = (int)drEspecialidades["id_especialidad"];
                    especialidad.DescEspecialidad = (string)drEspecialidades["desc_especialidad"];

                    // Agregamos el objeto con datos a la lista que devolveremos
                    especialidades.Add(especialidad);
                }
                //Cerramos el DataReader
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                //Cerramos la conexion a la BD
                this.CloseConnection();
            }

            // Devolvemos el objeto:
            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad especialidad = new Especialidad();

            try
            {
                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad = @id", SqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {
                    especialidad.Id = (int)drEspecialidades["id_especialidad"];
                    especialidad.DescEspecialidad = (string)drEspecialidades["desc_especialidad"];
                }

                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidad;
        }
        public void SetNullPlanDePersona(int idPlan)
        {
            //seteo en null el plan de la persona cuyo plan = idPlan recibido
            try
            {
                this.OpenConnection();
                SqlCommand cmdSetNullPlan = new SqlCommand("update personas set id_plan=null where id_plan=@idPlan", SqlConn);
                cmdSetNullPlan.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                cmdSetNullPlan.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al setear en null el plan de las personas.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int idEspec)
        {
            try
            {
                this.OpenConnection();
                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDeleteEsp = new SqlCommand("delete especialidades where id_especialidad=@idEspec", SqlConn);
                cmdDeleteEsp.Parameters.Add("@idEspec", SqlDbType.Int).Value = idEspec;
                SqlCommand cmdDeletePlanes = new SqlCommand("delete planes where id_especialidad=@idEspec", SqlConn);
                cmdDeletePlanes.Parameters.Add("@idEspec", SqlDbType.Int).Value = idEspec;
                //Ejecutamos la sentencia SQL
                cmdDeletePlanes.ExecuteNonQuery();
                cmdDeleteEsp.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc_especialidad " +
                "WHERE id_especialidad = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.Id;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.DescEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades(desc_especialidad) " +
                "VALUES(@desc_especialidad) " +
                "select @@identity", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.DescEspecialidad;
                especialidad.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el ID que asigno la BD automaticamente.
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
