using Inventory_System.Data.Model.Device.SIM_card;
using Inventory_System.Data.Repositories;
using Inventory_System.Interfaces.SIMcard.IRepository;
using Inventory_System.Interfaces.SIMcard.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.DataAccess.Services.SIMcard
{
    public class SIMCardTypeService : ISIMCardTypeService
    {
        private readonly ISIMCardTypeRepository _simTypeRepository;

        public SIMCardTypeService(ISIMCardTypeRepository simTypeRepository)
        {
            _simTypeRepository = simTypeRepository ?? throw new ArgumentNullException(nameof(simTypeRepository));
        }

        public async Task AddSIMTypeAsync(simtype simtype)
        {
            if (string.IsNullOrEmpty(simtype.type))
            {
                throw new ArgumentException("SIM type must have a non-empty name.");
            }

            if (simtype.active_from >= simtype.active_to)
            {
                throw new ArgumentException("Active from date must be before the active to date.");
            }
            await _simTypeRepository.AddSIMTypeAsync(simtype);
        }

        public Task DeleteSIMTypeAsync(int simtypeID)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<simtype>> GetAllSIMTypeAsync()
        {
            return await _simTypeRepository.GetAllSIMTypeAsync();
        }

        public Task<simtype> GetSIMTypeByIdAsync(int simtypeid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSIMTypeAsync(simtype dsimtype)
        {
            throw new NotImplementedException();
        }
    }
}

