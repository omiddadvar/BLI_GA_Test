using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes
{
    public class Configs
    {
        public ConfigModel ConfigValues { get; set; }
        private static Configs _instance;
        public static Configs GetInstance()
        {
            if(_instance == null)
                _instance = new Configs();
            return _instance;
        }
        private Configs()
        {
            _initializeConfigData();
        }
        private void _initializeConfigData()
        {
            ConfigValues = new ConfigModel()
            {
                ListSize = 10
            };
            ConfigValues.ImportanceDegree.Add("Importance degree of Tag", 1);
            ConfigValues.ImportanceDegree.Add("Importance degree of Genre", 1);
        }
    }
}
