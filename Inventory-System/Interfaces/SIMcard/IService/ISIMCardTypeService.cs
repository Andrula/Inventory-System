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
        Task<IEnumerable<simtype>> GetAllSIMTypeAsync();
        Task<simtype> GetSIMTypeByIdAsync(int simtypeid);
        Task AddSIMTypeAsync(simtype simtype);
        Task UpdateSIMTypeAsync(simtype dsimtype);
        Task DeleteSIMTypeAsync(int simtypeID);
    }
}
