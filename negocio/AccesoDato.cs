using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccesoDato
    {
        //Attributes
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        //Getter and Setter
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        //Constructor
        public AccesoDato()
        {
            connection = new SqlConnection("server=DESKTOP-81ER52L\\SQLEXPRESS; database=POKEMON_DB; integrated security=true");
            command = new SqlCommand(); 
        }

        //Methods
        public void setearQuery(string consulta)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            command.Connection = connection;
            
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int ejecutarEscritura()
        {
            command.Connection = connection;

            try
            {
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexión()
        {
            if (reader != null)
                reader.Close();

            connection.Close();
        }
    }
}
