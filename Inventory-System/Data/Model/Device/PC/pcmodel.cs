using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Model.Device.PC
{
    public class pcmodel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime active_from { get; set; }
        public DateTime active_to { get; set; }
    }
}
