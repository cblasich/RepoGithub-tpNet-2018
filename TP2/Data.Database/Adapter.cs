using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //Clave1 por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocalCaro";

         //Clave2 por defecto a utlizar para la cadena de conexion
        //const string consKeyDefaultCnnString = "ConnStringLocalDavid";

        protected SqlConnection _sqlConn;
        public SqlConnection SqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }

        protected void OpenConnection()
        {
            //Recuperar el connection string
            string cnnString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

            _sqlConn = new SqlConnection(cnnString);

            //Abrir conexion
            _sqlConn.Open();  
        }

        protected void CloseConnection()
        {
            //Cerrar conexion
            _sqlConn.Close();

            //Liberar la memoria usada
            _sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
