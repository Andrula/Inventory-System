using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inventory_System.Services
{
    public class Connector
    {
        private readonly SqlConnection Connection;

        public Connector(string ConString)
        {
            Connection = new SqlConnection(ConString);
        }

        public void OpenConnection()
        {
            if (Connection != null && Connection.State == System.Data.ConnectionState.Closed) 
            {
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }

        public void InsertUpdate(string SqlQuery, List<SqlParameter> parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(SqlQuery, Connection);

                command.CommandType = CommandType.Text;
                
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }
                command.ExecuteScalar();
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetData(string SqlQuery, List<SqlParameter> parameters = null)
        {
            DataTable dataTabke = new DataTable();

            try
            {
                SqlCommand command = new SqlCommand(SqlQuery, Connection);
                command.CommandType = CommandType.Text;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                {
                    da.Fill(dataTabke);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dataTabke;
        }
    }
}
