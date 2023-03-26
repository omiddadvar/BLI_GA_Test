using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Classes.Genetic_Operators;
using BLI_GA_Test.Classes.Genetic_Operators.Fitness;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes
{
    public class BLI_Algorithm 
    {
        private List<Individual> _bestMem = new List<Individual>();
        private List<Individual> _population;
        private List<Individual>  _newGeneration = new List<Individual>();
        private ConfigModel _configs;
        private DataHolder _dataHolder;
        private int _topBestIndNumber;
        public BLI_Algorithm()
        {
            _configs = Configs.GetInstance().ConfigValues;
            _dataHolder = DataHolder.GetInstance();
        }
        public void Run()
        {
            _population = new PopulationGenerator().Generate();
            _dataHolder.Users_With_Similarity = new UserSimilarity().Compute();

            for (int i = 0; i < _configs.MaxNumberOfIterations_GA; i++)
            {
                _findBestMem();

                _newGeneration = _bestMem;

                var geneticOperations = new GeneticOperations(ref _population, _topBestIndNumber);
                geneticOperations.Apply();
                _newGeneration = _newGeneration.Union(geneticOperations.GetNewGeneration()).ToList();

                _population = _newGeneration;
            }
            _findBestMem();

        }
        private void _findBestMem()
        {
            foreach (var ind in _population)
            {
                ind.Fitness = new IndividualFitness(ind).Compute();
            }
            //Sort population according to Semantic-Correlation by "Tag,Genre"
            _population = _population
                .OrderByDescending(ind => ind.Fitness)
                .ToList();

            _topBestIndNumber = (int)(_configs.PopulationSize * 0.10);
            //Top 10% best individuals according to Semantic-Correlation by "Tag,Genre"
            _bestMem = _population
                .Take(_topBestIndNumber)
                .ToList();
        }
    }
}
