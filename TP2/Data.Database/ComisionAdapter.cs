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
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Comision> comisiones = new List<Comision>();

            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /* Creamos un objeto SqlCommand que sera la sentencia SQL
                 que vamos a ejecutar contra la base de datos
                 (los datos de la BD materia, contraseña, servidor, etc.
                 estan en el connection string */

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql,
                 carga los datos en drMaterias para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos
                 y avanza a la fila siguiente para el proximo read. */

                while (drComisiones.Read()) //Mientras haya filas para leer...
                {
                    /* Creamos un objeto Materia de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    Comision com = new Comision();

                    // Ahora copiamos los datos de la fila al objeto:
                    com.Id = (int)drComisiones["id_comision"];
                    com.DescComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IdPlan = (int)drComisiones["id_plan"];
                   

                    // Agregamos el objeto con datos a la lista que devolveremos
                    comisiones.Add(com);
                }
                //Cerramos el DataReader
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                //Cerramos la conexion a la BD
                this.CloseConnection();
            }

            // Devolvemos el objeto:
            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision com = new Comision();

            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision = @id", SqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();
                if (drComisiones.Read())
                {
                    com.Id = (int)drComisiones["id_comision"];
                    com.DescComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IdPlan = (int)drComisiones["id_plan"];

                }

                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar datos de la comision.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                //Abrimos conexion
                this.OpenConnection();

                //Creamos la sentencia SQL y asignamos un valor al parametro
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecutamos la sentencia SQL
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar eliminar comision.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision, anio_especialidad = @anio_especialidad, id_plan = @id_plan " +
                "WHERE id_comision = @id_comision", SqlConn);


                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = comision.Id;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.DescComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
                cmdSave.ExecuteNonQuery();


            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar modificar datos de la comision.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand("INSERT INTO comisiones(desc_comision,anio_especialidad,id_plan) " +
                "VALUES(@desc_comision, @anio_especialidad, @id_plan) " +
                "select @@identity", //linea para recuperar el ID que asigno el Sql automaticamente
                SqlConn);

                cmdInsert.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.DescComision;
                cmdInsert.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
                comision.Id = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
                //Asi se obtiene el ID que asigno la BD automaticamente y ejecuta toda la consulta.

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar crear comision.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.Id);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
