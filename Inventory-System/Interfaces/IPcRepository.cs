using Inventory_System.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Repositories
{
    public interface IPcRepository
    {
        pc GetById(int pcID);
        IEnumerable<pc> GetAll();
        void Add(pc pc);
        void Update(pc pc);
        void Delete(int pcID);
    }
}
