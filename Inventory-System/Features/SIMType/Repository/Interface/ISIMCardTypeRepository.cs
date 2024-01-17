using Inventory_System.Features.SIMType.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Interfaces.SIMcard.IRepository
{
    public interface ISIMCardTypeRepository
    {
        Task<simtype> GetIMTypeByIdAsync(int simtypeID);
        Task<IEnumerable<simtype>> GetAllSIMTypeAsync();
        Task AddSIMTypeAsync(simtype simtype);
        Task UpdateIMTypeAsync(simtype simtype);
        Task DeleteIMTypeAsync(int simtypeID);
    }
}
