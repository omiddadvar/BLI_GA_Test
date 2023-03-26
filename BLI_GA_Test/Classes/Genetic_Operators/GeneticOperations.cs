using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLI_GA_Test.Classes.Genetic_Operators
{
    public class GeneticOperations : IAppliable
    {
        private ConfigModel _configs;
        private List<Individual> _parents, _newGeneration; 
        public GeneticOperations(ref List<Individual> population , int TopPercent) 
        {
            _configs = Configs.GetInstance().ConfigValues;
            _newGeneration = new List<Individual>();

            _parents = population
                 .OrderBy(ind => ind.Fitness)
                 .Take((int)(_configs.PopulationSize - TopPercent))
                 .ToList();
        }
        public void Apply()
        {
            _apply_CrossOver();
            _apply_Mutation();
        }
        public List<Individual> GetNewGeneration() => _newGeneration;
        private void _apply_CrossOver()
        {
            new CrossOver(ref _parents).Apply();
        }
        private void _apply_Mutation()
        {
            new Mutation(ref _parents).Apply();
        }
    }
}
