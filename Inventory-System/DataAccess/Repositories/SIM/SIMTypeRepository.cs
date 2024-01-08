using Inventory_System.Data.Model.Device.SIM_card;
using Inventory_System.Interfaces.SIMcard.IRepository;
using Inventory_System.Services;
using Inventory_System.Services.Configurations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Repositories.SIM
{
    public class SIMTypeRepository : ISIMCardTypeRepository
    {
        private Connector connector;
        public SIMTypeRepository()
        {
            try
            {
                connector = new Connector("Data Source=INTXL25010160;Initial Catalog=Polinventar;Integrated Security=True");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during Connector initialization: {ex.Message}");
            }
        }

        public async Task<IEnumerable<simtype>> GetAllSIMTypeAsync()
        {
            List<simtype> simtypes = new List<simtype>();

            try
            {
                connector.OpenConnection();

                DataTable dataTable = connector.GetData(SqlStatementGetAll);

                foreach (DataRow row in dataTable.Rows)
                {
                    simtypes.Add(MapToSimType(row));
                }
            }
            finally
            {
                connector.CloseConnection();
            }

            return simtypes;
        }

        public async Task AddSIMTypeAsync(simtype simtype)
        {
            try
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@TYPE",simtype.type),
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
        private simtype MapToSimType(DataRow row)
        {
            return new simtype
            {
                id = Convert.ToInt32(row["id"]),
                type = row["type"].ToString(),
                active_from = row.Field<DateTime>("active_from"),
                active_to = row.Field<DateTime>("active_to")
            };
        }

        #region SQL statements

        private const string SqlStatementGetAll = @"SELECT [id]
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
