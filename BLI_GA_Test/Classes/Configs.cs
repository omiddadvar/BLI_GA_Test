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
                IndividualListSize = 10,
                PopulationSize = 1000,
                ImportanceDegree = new Dictionary<string, int>
                {
                    { "Importance degree of Tag", 1 },
                    { "Importance degree of Genre", 1 }
                },
                ImportanceDegree_Fitness = new Dictionary<string, int>
                {
                    {"Importance degree of Semantic Correlation" , 1},
                    {"Importance degree of Users Similarity", 1 }
                }
            };
        }
    }
}
