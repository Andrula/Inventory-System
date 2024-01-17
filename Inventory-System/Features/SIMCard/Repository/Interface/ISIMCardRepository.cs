using Inventory_System.Features.SIMCard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Interfaces.SIMcard.IRepository
{
    public interface ISIMCardRepository
    {
        Task<simcard> GetInstanceByIdAsync(int simcardID);
        Task <IEnumerable<simcard>> GetAllInstancesAsync();
        Task AddInstanceAsync(simcard simcard);
        Task UpdateInstanceAsync(simcard simcard);
        Task DeleteInstanceAsync(int simcardID);
    }
}
