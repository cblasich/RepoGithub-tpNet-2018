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
                 que vamos a ejecutar contra la base de datos
                 (los datos de la BD materia, contraseña, servidor, etc.
                 estan en el connection string */

                SqlCommand cmdMaterias = new SqlCommand("select * from materias", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql,
                 carga los datos en drMaterias para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos
                 y avanza a la fila siguiente para el proximo read. */

                while (drMaterias.Read()) //Mientras haya filas para leer...
                {
                    /* Creamos un objeto Materia de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    Materia mat = new Materia();
                    
                        // Ahora copiamos los datos de la fila al objeto:
                        mat.Id = (int)drMaterias["id_materia"];
                        mat.DescMateria = (string)drMaterias["desc_materia"];
                        mat.HorasSemanales = (int)drMaterias["hs_semanales"];
                        mat.HorasTotales = (int)drMaterias["hs_totales"];
                        mat.IdPlan = (int)drMaterias["id_plan"];
                    
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
                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia = @id", SqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
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

        public void Delete(int ID)
        {
            try
            {
                //Abrimos conexion
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecutamos la sentencia SQL
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar materia.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET nombre_materia = @nombre_materia, clave = @clave, " +
                "habilitado = @habilitado, id_persona = @id_persona " +
                "WHERE id_materia = @id", SqlConn);

       
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.DescMateria;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HorasSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HorasTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
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


        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO materias(desc_materia,hs_semanales,hs_totales,id_plan) " +
                "VALUES(@desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                "select @@identity", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdInsert.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.DescMateria;
                cmdInsert.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HorasSemanales;
                cmdInsert.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HorasTotales;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
                materia.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
                //Asi se obtiene el ID que asigno la BD automaticamente y ejecuta toda la consulta.
                
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


        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.Id);
            }
            else if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
