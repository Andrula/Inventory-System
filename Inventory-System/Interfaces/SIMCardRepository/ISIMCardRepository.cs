using Inventory_System.Data.Model;
using Inventory_System.Data.Model.Device.SIM_card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Repositories
{
    public interface ISIMCardRepository
    {
        Task<simcard> GetByIdAsync(int simcardID);
        Task <IEnumerable<simcard>> GetAllAsync();
        Task AddAsync(simcard simcard);
        Task UpdateAsync(simcard simcard);
        Task DeleteAsync(int simcardID);
    }
}
