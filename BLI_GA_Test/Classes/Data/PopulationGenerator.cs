using BLI_GA_Test.Classes.Semantic_Correlation;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Data
{
    public class PopulationGenerator
    {
        private ConfigModel _configs;
        public PopulationGenerator() 
        {
            _configs = Configs.GetInstance().ConfigValues;
        }
        public List<Individual> Generate()
        {
            try
            {
                var population = new List<Individual>();
                for (int i = 0; i < _configs.PopulationSize; i++)
                {
                    var individual = new Individual();
                    individual.MovieList = new RandomMovieList().GetRandomListOfMovieItems();
                    individual.SemCorrRating = new SemCorrRating(individual.MovieList).Compute_SimilarityCorrelation();

                    population.Add(individual);
                }
                return population;
            }
            catch
            {
                return null;
            }
        }
    }
}
