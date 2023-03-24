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
        private List<Individual> _population, _newGeneration, _rest80percent; 
        public GeneticOperations(ref List<Individual> population) 
        {
            _population = population;
            _newGeneration = new List<Individual>();
        }
        public GeneticOperations Apply()
        {
            _splitGeneration();
            _apply_CrossOver();
            _apply_Mutation();
            return this;
        }
        public List<Individual> GetNewGeneration() => _newGeneration;

        private void _splitGeneration()
        {
            int countTop20_ForNextGenenration = (int)(_population.Count() * 0.20);
            int countRest80_ForApplyingGeneticOperators = _population.Count() - countTop20_ForNextGenenration;
            _newGeneration = _population
                .Take(countTop20_ForNextGenenration)
                .ToList();
            _rest80percent = _population
                .Take(countRest80_ForApplyingGeneticOperators)
                .ToList();
        }
        private void _apply_CrossOver()
        {

        }
        private void _apply_Mutation()
        {

        }
    }
}
