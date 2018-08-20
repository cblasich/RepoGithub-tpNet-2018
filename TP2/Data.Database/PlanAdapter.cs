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
        public List<Plan> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<Plan> planes = new List<Plan>();

            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                /* Creamos un objeto SqlCommand que sera la sentencia SQL
                 que vamos a ejecutar contra la base de datos
                 (los datos de la BD materia, contraseña, servidor, etc.
                 estan en el connection string */

                SqlCommand cmdPlanes = new SqlCommand("select * from planes", SqlConn);

                /* instanciamos un objeto DataReader que sera 
                 el que recuperara los datos de la BD */

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                /* Read() lee una fila de las devueltas por el comando sql,
                 carga los datos en drMaterias para poder accederlos,
                 devuelve verdadero mientras haya podido leer datos
                 y avanza a la fila siguiente para el proximo read. */

                while (drPlanes.Read()) //Mientras haya filas para leer...
                {
                    /* Creamos un objeto Materia de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    Plan pl = new Plan();
                    
                        // Ahora copiamos los datos de la fila al objeto:
                        pl.Id = (int)drPlanes["id_plan"];
                        pl.DescPlan = (string)drPlanes["desc_plan"];
                        pl.IdEspecialidad = (int)drPlanes["id_especialidad"];
                                            
                    // Agregamos el objeto con datos a la lista que devolveremos
                    planes.Add(pl);
                }
                //Cerramos el DataReader
                drPlanes.Close();
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
            return planes;
        }
    }
}