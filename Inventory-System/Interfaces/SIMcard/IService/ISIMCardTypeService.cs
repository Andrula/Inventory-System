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
        Task<IEnumerable<simtype>> GetAllInstancesAsync();
        Task<simtype> GetInstanceAsync(int simtypeid);
        void AddInstanceAsync(simtype simtype);
        void UpdateInstanceAsync(simtype dsimtype);
        void DeleteInstanceAsync(int simtypeID);
    }
}
