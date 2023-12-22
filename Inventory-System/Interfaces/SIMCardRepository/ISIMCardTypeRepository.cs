using Inventory_System.Data.Model;
using Inventory_System.Data.Model.Device.SIM_card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Repositories
{
    public interface ISIMCardTypeRepository
    {
        Task<simtype> GetByIdAsync(int simtypeID);
        Task<IEnumerable<simtype>> GetAllAsync();
        Task AddAsync(simtype simtype);
        Task UpdateAsync(simtype simtype);
        Task DeleteAsync(int simtypeID);
    }
}
