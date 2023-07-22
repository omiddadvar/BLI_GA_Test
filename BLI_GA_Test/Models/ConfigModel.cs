using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Models
{
    public  class ConfigModel
    {
        public int IndividualListSize { get; set; }
        public int PopulationSize { get; set; }
        public int MaxNumberOfIterations_GA { get; set; }
        public Dictionary<string, double> ImportanceDegree { get; set; }
        public Dictionary<string, double> ImportanceDegree_Fitness { get; set; }

        public ConfigModel() 
        {
            ImportanceDegree = new Dictionary<string, double>();
            ImportanceDegree_Fitness = new Dictionary<string, double>();
        }
    }
}
