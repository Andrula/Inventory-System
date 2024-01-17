// Generic usings.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;

// User added usings.
using Inventory_System.Interfaces.SIMcard.IRepository;
using Inventory_System.Services.Database;
using Inventory_System.Features.SIMCard.Model;
using Inventory_System.Services.Configurations;
using Inventory_System.Features.SIMType.Model;

namespace Inventory_System.Data.Repositories.SIM
{
    public class SIMCardRepository : ISIMCardRepository
    {
        private Connector connector;

        public SIMCardRepository()
        {
            connector = new Connector(SysConfig.GetConnectionString);
        }
        public async Task<IEnumerable<simcard>> GetAllInstancesAsync()
        {
            List<simcard> simcards = new List<simcard>();
            using (SqlConnection connection = new SqlConnection(SysConfig.GetConnectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(GetAll, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            simcards.Add(MapToSIMCard(reader));
                        }
                    }
                }
            }

            return simcards;
        }

        private simcard MapToSIMCard(SqlDataReader reader)
        {
            return new simcard
            {
                id = Convert.ToInt32(reader["id"]),
                number = Convert.ToString(reader["number"]),
                ICCID = Convert.ToString(reader["ICCID"]),
                PIN = Convert.ToString(reader["PIN"]),
                PUK = Convert.ToString(reader["PUK"]),
                SIMTYPE = new simtype
                {
                    id = Convert.ToInt32(reader["id"]),
                    simType = Convert.ToString(reader["typename"])
                }
            };
        }

        public async Task AddInstanceAsync(simcard simcard)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteInstanceAsync(int simcardID)
        {
            throw new NotImplementedException();
        }


        public async Task<simcard> GetInstanceByIdAsync(int simcardID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateInstanceAsync(simcard simcard)
        {
            throw new NotImplementedException();
        }

        #region SQL Statements
        private const string GetAll = @"SELECT simcard.id, simcard.number, simcard.PIN, simcard.PUK, simcard.ICCID, simtype.id ,simtype.typename
                                      FROM simcard
                                      INNER JOIN simtype ON simcard.simtype_id = simtype.id;";
        #endregion
    }
}
