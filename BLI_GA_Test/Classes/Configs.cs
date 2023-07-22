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
                PopulationSize = 100,
                MaxNumberOfIterations_GA = 300,
                ImportanceDegree = new Dictionary<string, double>
                {
                    { "Importance degree of Tag", 0.5 },
                    { "Importance degree of Genre", 0.5 }
                },
                ImportanceDegree_Fitness = new Dictionary<string, double>
                {
                    {"Importance degree of Semantic Correlation" , 0.5},
                    {"Importance degree of Users Similarity", 0.5}
                }
            };
        }
    }
}
