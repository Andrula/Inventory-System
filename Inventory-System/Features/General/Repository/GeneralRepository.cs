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

namespace Inventory_System.Features.General.Repository
{
    public class GeneralRepository
    {
        private PCRepository _pcRepository;
        private SIMCardRepository _simCardRepository;
        private TabletRepository _tabletRepository;
        private PhoneRepository _phoneRepository;
        public GeneralRepository(PCRepository pcRepository, SIMCardRepository simCardRepository)
        {
                
        }

        public async Task<IEnumerable<GeneralEquipmentItem>> GetAllEquipmentAsync()
        {
            var generalList = new List<GeneralEquipmentItem>();

            // Fetch PCs
            var pcs = await _pcRepository.GetAllPCsAsync();
            generalList.AddRange(pcs.Select(pc => new GeneralEquipmentItem
            {
                EquipmentType = "PC",
                // Map other properties
            }));

            // Fetch SIMCards
            var simCards = await _simCardRepository.GetAllInstancesAsync();
            generalList.AddRange(simCards.Select(simCard => new GeneralEquipmentItem
            {
                EquipmentType = "SIM Card",
                // Map other properties
            }));

            // Repeat for Tablet and Phone

            return generalList;
        }
    }
}
