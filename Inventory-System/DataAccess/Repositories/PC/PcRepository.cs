using Inventory_System.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Repositories.PC
{
    public class PcRepository : IPcRepository
    {
        private readonly string connectionString;

        public PcRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public pc GetById(int pcID)
        {
            throw new NotImplementedException();
        }

        public void Add(pc pc)
        {
            throw new NotImplementedException();
        }

        public void Delete(int pcID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<pc> GetAll()
        {
            throw new NotImplementedException();
        }


        public void Update(pc pc)
        {
            throw new NotImplementedException();
        }

        private const string GetByID = "@";
    }
}
