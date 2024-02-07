using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Features.General.Model
{
    public class GeneralEquipmentItem
    {
        public int DeviceID { get; set; }
        public string EquipmentType { get; set; }
        public DateTime LastTimeAccounted { get; set; }
        public string PersonName { get; set; }
        public string Email {  get; set; }
        public string Phone {  get; set; }
        public DateTime LoanActiveFrom { get; set; }
        public DateTime LoanActiveTo { get; set; }
        public string LocationName { get; set; }
        public string Status { get; set; }
        public string ProjectName { get; set; }
        public string WRX { get; set; }
        public string StatusNote { get; set; }
    }
}
