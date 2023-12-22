using Inventory_System.Data.Model.Device.SIM_card;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Repositories.SIM
{
    public class SIMTypeRepository : ISIMCardTypeRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["InventoryDatabase"].ConnectionString;
        public async Task<IEnumerable<simtype>> GetAllAsync()
        {
            List<simtype> simtypes = new List<simtype>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(GetAll, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            simtypes.Add(MapToSimType(reader));
                        }
                    }
                }
            }

            return simtypes;
        }

        public async Task AddAsync(simtype simtype)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int simtypeID)
        {
            throw new NotImplementedException();
        }


        public async Task<simtype> GetByIdAsync(int simtypeID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(simtype simtype)
        {
            throw new NotImplementedException();
        }

        // Method that maps data from table to SIM type object
        private simtype MapToSimType(SqlDataReader reader)
        {
            return new simtype
            {
                id = Convert.ToInt32(reader["id"]),
                type = reader["name"].ToString(),
                active_from = reader.GetDateTime(reader.GetOrdinal("active_from")),
                active_to = reader.GetDateTime(reader.GetOrdinal("active_to"))
            };
        }

        #region SQL statements

        private const string GetAll = @"SELECT [id]
      ,[type]
      ,[active_from]
      ,[active_to]
  FROM [Polinventar].[dbo].[simtype]";


        #endregion
    }
}
