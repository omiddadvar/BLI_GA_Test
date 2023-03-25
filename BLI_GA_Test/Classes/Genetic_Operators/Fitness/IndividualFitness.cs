using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Genetic_Operators.Fitness
{
    public class IndividualFitness
    {
        private Individual _individual;
        int _ImportanceDegree_Semantic,
            _ImportanceDegree_UsersSimilarity;
        public IndividualFitness(ref Individual individual) 
        {
            _individual = individual;
            var config = Configs.GetInstance().ConfigValues;
            _ImportanceDegree_Semantic = 
                config.ImportanceDegree_Fitness["Importance degree of Semantic Correlation"];
            _ImportanceDegree_UsersSimilarity = 
                config.ImportanceDegree_Fitness["Importance degree of Users Similarity"];
        }

        public void Compute()
        {
            double UsersSimFitnessValue = new SatRatingFitness(_individual).Compute();
            _individual.Fitness =
                UsersSimFitnessValue * _ImportanceDegree_UsersSimilarity +
                _individual.SemCorrRating * _ImportanceDegree_Semantic;
        }
    }
}
