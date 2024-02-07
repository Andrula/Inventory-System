// Generic
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

// User defined.
using Inventory_System.Data.Repositories.SIM;
using Inventory_System.Features.PC.Repository;
using Inventory_System.Features.Phone.Repository;
using Inventory_System.Features.Tablet.Repository;
using Inventory_System.Features.General.Model;
using Inventory_System.Services.Database;
using System.Data.SqlClient;
using Inventory_System.Services.Configurations;

namespace Inventory_System.Features.General.Repository
{
    public class GeneralRepository
    {

        private readonly string _connectionString;
        public GeneralRepository()
        {
            _connectionString = SysConfig.GetConnectionString;
        }

        public async Task<IEnumerable<GeneralEquipmentItem>> GetAllEquipmentAsync()
        {
            var generalList = new List<GeneralEquipmentItem>();
            // Region for long sql query variable. 
            #region SQL Query
            var query = @"SELECT 
    d.id AS DeviceID,
    CASE
        WHEN d.pc_id IS NOT NULL THEN 'PC'
        WHEN d.tablet_id IS NOT NULL THEN 'Tablet'
        WHEN d.phone_id IS NOT NULL THEN 'Phone'
        WHEN d.sim_id IS NOT NULL THEN 'SIM-Card'
        ELSE 'Unknown'
    END AS EquipmentType,
    accountinghistory.lasttimeaccounted,
    person.wrx,
    person.name AS PersonName,
    person.email,
    person.phone,
    locationname.name AS LocationName,
    project.name AS ProjectName,
    loan.active_from AS LoanActiveFrom,
    loan.active_to AS LoanActiveTo,
    status.note AS StatusNote
FROM 
    dbo.device d
LEFT JOIN dbo.pc ON d.pc_id = pc.id
LEFT JOIN dbo.tablet ON d.tablet_id = tablet.id
LEFT JOIN dbo.phone ON d.phone_id = phone.id
LEFT JOIN dbo.simcard ON d.sim_id = simcard.id
INNER JOIN dbo.status ON device_id = d.id
INNER JOIN dbo.accountinghistory ON accountinghistory_id = accountinghistory.id
INNER JOIN dbo.udlaan ON udlaan_id = udlaan.id
INNER JOIN dbo.person ON person_id = person.id
INNER JOIN dbo.project ON project_id = project.id
INNER JOIN dbo.location ON location_id = location.id
INNER JOIN dbo.locationname ON location_name_id = locationname.id
INNER JOIN dbo.loan ON loan_id = loan.id;";
            #endregion

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = new GeneralEquipmentItem
                            {
                                DeviceID = reader["DeviceID"] as int? ?? default(int),
                                EquipmentType = reader["EquipmentType"].ToString(),
                                LastTimeAccounted = reader["lasttimeaccounted"] as DateTime? ?? default(DateTime),
                                WRX = reader["wrx"].ToString(),
                                PersonName = reader["PersonName"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"].ToString(),
                                LocationName = reader["LocationName"].ToString(),
                                ProjectName = reader["ProjectName"].ToString(),
                                LoanActiveFrom = reader["LoanActiveFrom"] as DateTime? ?? default(DateTime),
                                LoanActiveTo = reader["LoanActiveTo"] as DateTime? ?? default(DateTime),
                                StatusNote = reader["StatusNote"].ToString()

                            };
                            generalList.Add(item);
                        }
                    }
                }
            }
            return generalList;
        }
    }
}
