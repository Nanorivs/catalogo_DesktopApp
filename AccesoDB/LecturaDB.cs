using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO.Pipes;

namespace AccesoDB
{
    public class LecturaDB
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;



        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public LecturaDB()
        {
            conexion = new SqlConnection("server = .\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true");
            comando = new SqlCommand();
        }

        public void SetearConsulta(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }
        public void EjecutarConsulta()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            { throw error; }

        }

        public void SetearParametroComando(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public void EjecutarLectura()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception error)
            { throw error; }

        }
        public void CerrarConexion()
        {
            if(lector != null)
                lector.Close();

            conexion.Close();   
        }

    }
}
