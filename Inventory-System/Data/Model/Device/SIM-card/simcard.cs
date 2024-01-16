using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Data.Model.Device.SIM_card
{
    public class simcard
    {
        public int id {  get; set; }
        public string number { get; set; }
        public string PIN { get; set; }
        public string PUK { get; set; }
        public string ICCID { get; set; }

        public simtype SIMTYPE { get; set; }

        public override string ToString()
        {
            return $"{id} - {number} - {PIN} - {PUK} - {ICCID}"; 
        }
    }
}
