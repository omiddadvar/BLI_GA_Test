using BLI_GA_Test.Classes;
using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.Classes.Precision
{
    public class PrecisionCalculator : IComputable<double>
    {
        private ActiveUser _AU;
        private Individual _individual;
        public PrecisionCalculator(Individual individual)
        {
            _AU = ActiveUser.GetInstance();
            _individual = individual;
        }
        public double Compute()
        {
            int[] testDataMovieIDs = _AU.TestRatings.Select(r => r.MovieId).ToArray();

            int inCommonMovies = _individual.MovieList
                .Where(m => testDataMovieIDs.Contains(m.MovieId))
                .Count();

            return (double)inCommonMovies / _individual.MovieList.Count();
        }
    }
}
