using Inventory_System.Data.Model.Device.SIM_card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Repositories.SIM
{
    public class SIMCardRepository : ISIMCardRepository
    {
        public async Task AddAsync(simcard simcard)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int simcardID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<simcard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<simcard> GetByIdAsync(int simcardID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(simcard simcard)
        {
            throw new NotImplementedException();
        }
    }
}
