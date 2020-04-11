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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll() 
        {
            //instanciamos el objeto lista a retornar
            List<Materia> materias = new List<Materia>();
            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /* Creamos un objeto SqlCommand que sera la sentencia SQL
                 que vamos a ejecutar contra la base de datos */

                SqlCommand cmdMaterias = new SqlCommand("select * from materias", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql, carga los datos en drPlanes para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos y avanza a la fila siguiente para el proximo read. */

                while (drMaterias.Read())
                {
                    /* Creamos un objeto Plan de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/
                    Materia mat = new Materia();
                    if ((int)drMaterias["id_plan"] > 0)
                    {
                        // Ahora copiamos los datos de la fila al objeto:
                        mat.Id = (int)drMaterias["id_materia"];
                        mat.DescMateria = drMaterias["desc_materia"].ToString();
                        mat.HorasSemanales = (int)drMaterias["hs_semanales"];
                        mat.HorasTotales = (int)drMaterias["hs_totales"];
                        mat.IdPlan = (int)drMaterias["id_plan"];
                    }
                    if (drMaterias["id_materia"] != DBNull.Value)
                    {
                        mat.Id = (int)(drMaterias["id_materia"]);
                    }
                    else mat.Id = 0;

                    // Agregamos el objeto con datos a la lista que devolveremos
                    materias.Add(mat);
                }
                //Cerramos el DataReader
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                //Cerramos la conexion a la BD
                this.CloseConnection();
            }
            // Devolvemos el objeto:
            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();

            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia = @id", SqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMateria.ExecuteReader();
                if (drMaterias.Read())
                {
                    mat.Id = (int)drMaterias["id_materia"];
                    mat.DescMateria = (string)drMaterias["desc_materia"];
                    mat.HorasSemanales = (int)drMaterias["hs_semanales"];
                    mat.HorasTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar datos de la materia.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }

        public void Delete(int idMat)
        {
            try
            {
                this.OpenConnection();
                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDeleteMat = new SqlCommand("delete materias where id_materia=@idMat", SqlConn);
                cmdDeleteMat.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;
                //Ejecutamos la sentencia SQL
                cmdDeleteMat.ExecuteNonQuery();
            }
            //catch (SqlException SqlEx)
            //{
            //    Exception ExcepcionSqlManejada = new Exception("Plan tiene Comisiones asociadas. Debe eliminarlas antes de eliminar el plan.", SqlEx);
            //    throw ExcepcionSqlManejada;
            //}
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }
            mat.State = BusinessEntity.States.Unmodified;
        }
        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias(desc_materia, hs_semanales, hs_totales, id_plan) " +
                "VALUES(@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                "select @@identity",   //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.DescMateria;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HorasSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HorasTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IdPlan;
                mat.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());  //Asi se obtiene el ID que asigno la BD automaticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar crear materia.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia, hs_semanales = @hs_semanales, " +
                "hs_totales = @hs_totales, id_plan = @id_plan " +
                "WHERE id_materia = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mat.Id;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.DescMateria;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HorasSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HorasTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IdPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar modificar datos de la materia.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
