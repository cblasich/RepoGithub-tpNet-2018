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
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            //instanciamos el objeto lista a retornar
            List<ModuloUsuario> modulosUsuarios = new List<ModuloUsuario>();

            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();
                
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios", SqlConn);

                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    /* Creamos un objeto ModuloUsuario de la capa de entidades para copiar
                     los datos de la fila del DataReader al objeto de entidades.*/

                    ModuloUsuario modUsr = new ModuloUsuario();

                    // Ahora copiamos los datos de la fila al objeto:

                    modUsr.Id = (int)drModulosUsuarios["id_modulo_usuario"];
                    modUsr.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modUsr.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modUsr.PermiteAlta = drModulosUsuarios.IsDBNull(3) ? false : (bool)drModulosUsuarios["alta"];
                    modUsr.PermiteBaja = drModulosUsuarios.IsDBNull(4) ? false : (bool)drModulosUsuarios["baja"];
                    modUsr.PermiteModificacion = drModulosUsuarios.IsDBNull(5) ? false : (bool)drModulosUsuarios["modificacion"];
                    modUsr.PermiteConsulta = drModulosUsuarios.IsDBNull(6) ? false : (bool)drModulosUsuarios["consulta"];

                    // Agregamos el objeto con datos a la lista que devolveremos
                    modulosUsuarios.Add(modUsr);
                }
                //Cerramos el DataReader
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al intentar recuperar la lista de modulos de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulosUsuarios;
        }



    }
}
