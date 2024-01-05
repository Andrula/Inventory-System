using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Inventory_System.Services.Configurations
{
    public static class SysConfig
    {
        public static string GetConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConString"].ConnectionString; }
        }
    }
}
