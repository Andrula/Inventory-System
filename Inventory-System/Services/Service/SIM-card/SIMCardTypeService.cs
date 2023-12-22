using Inventory_System.Data.Model.Device.SIM_card;
using Inventory_System.Data.Repositories;
using Inventory_System.Interfaces.SIMcard.IRepository;
using Inventory_System.Interfaces.SIMcard.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Services.Service.SIM_card
{
    public class SIMCardTypeService : ISIMCardTypeService
    {
        private readonly ISIMCardTypeRepository _simTypeRepository;

        public async Task<IEnumerable<simtype>> GetAllAsync()
        {
            return await _simTypeRepository.GetAllAsync();
        }

        public Task AddDeviceAsync(simtype simtype)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDeviceAsync(int simtypeID)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<simtype>> GetAllDevicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<simtype> GetDeviceByIdAsync(int simtypeid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDeviceAsync(simtype dsimtype)
        {
            throw new NotImplementedException();
        }
    }
}

