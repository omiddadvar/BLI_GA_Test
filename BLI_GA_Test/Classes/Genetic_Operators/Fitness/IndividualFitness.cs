using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Genetic_Operators.Fitness
{
    public class IndividualFitness : IComputable<double>
    {
        private Individual _individual;
        double _ImportanceDegree_Semantic,
            _ImportanceDegree_UsersSimilarity;
        public IndividualFitness(Individual individual) 
        {
            _individual = individual;
            var config = Configs.GetInstance().ConfigValues;
            _ImportanceDegree_Semantic = 
                config.ImportanceDegree_Fitness["Importance degree of Semantic Correlation"];
            _ImportanceDegree_UsersSimilarity = 
                config.ImportanceDegree_Fitness["Importance degree of Users Similarity"];
        }

        public double Compute()
        {
            double UsersSimFitnessValue = new SatRatingFitness(_individual).Compute();
            return (UsersSimFitnessValue * _ImportanceDegree_UsersSimilarity +
                _individual.SemCorrRating * _ImportanceDegree_Semantic);
        }
    }
}
