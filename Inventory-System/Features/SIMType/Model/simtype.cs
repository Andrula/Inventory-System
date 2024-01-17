using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Features.SIMType.Model
{
    public class simtype
    {
        public int id { get; set; }
        public string simType { get; set; }
        public DateTime active_from { get; set; }
        public DateTime active_to { get; set; }

        public override string ToString()
        {
            return $"{simType}";
        }
    }
}
