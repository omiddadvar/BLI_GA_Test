using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Models
{
    public  class ConfigModel
    {
        public int ListSize { get; set; }
        public Dictionary<string, int> ImportanceDegree { get; set; }

        public ConfigModel() 
        {
            ImportanceDegree = new Dictionary<string, int>();
        }
    }
}
