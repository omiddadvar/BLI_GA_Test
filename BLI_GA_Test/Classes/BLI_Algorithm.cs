using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Classes.Genetic_Operators;
using BLI_GA_Test.Classes.Genetic_Operators.Fitness;
using BLI_GA_Test.Classes.Prediction;
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
        private ActiveUser _AU;
        private int _topBestIndNumber;

        private Individual _recommendedIndividual;
        public Individual RecommendedIndividual => _recommendedIndividual;
        public BLI_Algorithm()
        {
            _configs = Configs.GetInstance().ConfigValues;
            _dataHolder = DataHolder.GetInstance();
        }
        public void CalculateUsersSimilarity_WithAU()
        {
            _AU = ActiveUser.GetInstance();
            _dataHolder.Users_With_Similarity = new UserSimilarity(_AU).Compute();
        }
        public void Run()
        {
            _population = new PopulationGenerator().Generate();

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
            _predictBestIndividual();
            _SetRatingsValue_ForRecommended();
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
        private void _predictBestIndividual()
        {
            _AU = ActiveUser.GetInstance();
            foreach (var individual in _bestMem)
            {
                 individual.PredictSatRating = new PredictSatRatng(ref _AU, individual).Compute();
            }
            _recommendedIndividual = _bestMem.OrderByDescending(ind => ind.PredictSatRating).First();
        }
        private void _SetRatingsValue_ForRecommended()
        {
            foreach(var movie in _recommendedIndividual.MovieList)
            {
                movie.PredictedRating = _RateRound(
                        _dataHolder.TrainingRatings
                        .Where(r => r.MovieId == movie.MovieId)
                        .Average(r => r.Rate)
                    );
            }
        }
        private double _RateRound(double input)
        {
            double whole = Math.Truncate(input);
            double remainder = input - whole;
            if (remainder < 0.3)
            {
                remainder = 0;
            }
            else if (remainder < 0.8)
            {
                remainder = 0.5;
            }
            else
            {
                remainder = 1;
            }
            return whole + remainder;
        }
    }
}
