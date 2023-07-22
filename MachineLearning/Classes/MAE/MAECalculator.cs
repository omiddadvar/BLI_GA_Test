using BLI_GA_Test.Classes;
using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.Classes.MAE
{
    internal class MAECalculator : IComputable<double>
    {
        private ActiveUser _AU;
        private Individual _individual;
        public MAECalculator(Individual individual)
        {
            _AU = ActiveUser.GetInstance();
            _individual = individual;
        }
        public double Compute()
        {
            double mae = 0;
            foreach(var ratingItem in _AU.TestRatings)
            {
                var incommonMovie = _individual.MovieList
                    .Where(m => m.MovieId.Equals(ratingItem.MovieId)).FirstOrDefault();
                
                if (incommonMovie == null)
                {
                    mae += 5;
                }
                else
                {
                    mae += Math.Abs(incommonMovie.Rating - ratingItem.Rate);
                }
            }
            mae /= _AU.TestRatings.Count();
            return mae;
        }
    }
}
