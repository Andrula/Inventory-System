using Inventory_System.Data.Model.Device.SIM_card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Interfaces.SIMcard.IService
{
    public interface ISIMCardTypeService
    {
        Task<IEnumerable<simtype>> GetAllDevicesAsync();
        Task<simtype> GetDeviceByIdAsync(int simtypeid);
        Task AddDeviceAsync(simtype simtype);
        Task UpdateDeviceAsync(simtype dsimtype);
        Task DeleteDeviceAsync(int simtypeID);
    }
}
