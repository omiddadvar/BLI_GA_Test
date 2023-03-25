using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Genetic_Operators
{
    public class GeneticOperations
    {
        private ConfigModel _configs;
        private List<Individual> _population, _newGeneration; 
        public GeneticOperations(ref List<Individual> population , int TopPercent) 
        {
            _configs = Configs.GetInstance().ConfigValues;
            _newGeneration = new List<Individual>();

            _population = population
                 .OrderBy(ind => ind.Fitness)
                 .Take((int)(_configs.PopulationSize - TopPercent))
                 .ToList();
        }
        public GeneticOperations Apply()
        {
            _apply_CrossOver();
            _apply_Mutation();
            return this;
        }
        public List<Individual> GetNewGeneration() => _newGeneration;
        private void _apply_CrossOver()
        {

        }
        private void _apply_Mutation()
        {

        }
    }
}
