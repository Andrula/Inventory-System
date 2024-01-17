using Inventory_System.Interfaces.SIMcard.IRepository;
using Inventory_System.Features;
using Inventory_System.Services.Configurations;
using Inventory_System.Services.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Inventory_System.Features.SIMType.Model;

namespace Inventory_System.Data.Repositories.SIM
{
    public class SIMTypeRepository : ISIMCardTypeRepository
    {
        private Connector connector;
        public SIMTypeRepository()
        {
            connector = new Connector(SysConfig.GetConnectionString);     
        }

        public async Task<IEnumerable<simtype>> GetAllSIMTypeAsync()
        {
            List<simtype> simtypes = new List<simtype>();

            using (SqlConnection connection = new SqlConnection(connector.ToString()))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(GetAll, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            simtypes.Add(MapToSimType(reader));
                        }
                    }
                }
            }

            return simtypes;
        }

        public async Task AddSIMTypeAsync(simtype simtype)
        {
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@TYPE",simtype.simType),
                    new SqlParameter("@ACTIVE_TO",simtype.active_to),
                    new SqlParameter("@ACTIVE_FROM", simtype.active_from)
                };

                connector.OpenConnection();
                connector.InsertUpdate(InsertSIMType, sqlParameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteIMTypeAsync(int simtypeID)
        {
            throw new NotImplementedException();
        }


        public async Task<simtype> GetIMTypeByIdAsync(int simtypeID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateIMTypeAsync(simtype simtype)
        {
            throw new NotImplementedException();
        }

        // Method that maps data from table to SIM type object
        private simtype MapToSimType(SqlDataReader reader)
        {
            return new simtype
            {
                id = Convert.ToInt32(reader["id"]),
                simType = reader["name"].ToString(),
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

        private const string InsertSIMType = @"INSERT INTO [dbo].[simtype]
  ([type]
  ,[active_from]
  ,[active_to])
  VALUES
  (@TYPE
  , @ACTIVE_FROM
  , @ACTIVE_TO)";
        #endregion
    }
}
