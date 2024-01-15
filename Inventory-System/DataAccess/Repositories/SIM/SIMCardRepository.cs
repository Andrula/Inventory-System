using Inventory_System.Data.Model.Device.SIM_card;
using Inventory_System.Interfaces.SIMcard.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Repositories.SIM
{
    public class SIMCardRepository : ISIMCardRepository
    {
        public async Task AddInstanceAsync(simcard simcard)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteInstanceAsync(int simcardID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<simcard>> GetAllInstancesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<simcard> GetInstanceByIdAsync(int simcardID)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateInstanceAsync(simcard simcard)
        {
            throw new NotImplementedException();
        }
    }
}
