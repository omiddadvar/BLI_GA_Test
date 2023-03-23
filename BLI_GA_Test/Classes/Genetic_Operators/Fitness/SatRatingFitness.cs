using BLI_GA_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Genetic_Operators.Fitness
{
    public class SatRatingFitness : IComputable<double>
    {
        private ActiveUser _activeUser;
        private int[] _activeUserMovies;
        private int[] _userIDs_HaveCommonMovies_WithAU;
        public SatRatingFitness()
        {
            _activeUser = ActiveUser.GetInstance();
            _activeUserMovies = _activeUser.Ratings.Select(r => r.MovieId).ToArray();
            _userIDs_HaveCommonMovies_WithAU = _activeUser.Ratings
                .Where(r => _activeUserMovies.Contains(r.MovieId))
                .Select(r => r.UserId)
                .Distinct()
                .ToArray();
        }
        public double Compute()
        {
            double SatRatingFitnessValue = 0;

            foreach(int userId in _userIDs_HaveCommonMovies_WithAU)
            {
                SatRatingFitnessValue += new SatSimU(userId).Compute();
            }

            return SatRatingFitnessValue;
        }
    }
}
