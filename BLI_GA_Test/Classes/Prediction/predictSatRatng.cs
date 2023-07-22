using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Prediction
{
    public class PredictSatRatng : IComputable<double>
    {
        private List<User> _allUsers;
        private List<Rating> _allRatings;
        private Individual _individual;
        private List<int> _movieIDs;
        private ActiveUser _AU;
        public PredictSatRatng(ref ActiveUser AU, Individual individual)
        {
            _individual = individual;
            _AU = AU;
            _allUsers = DataHolder.GetInstance().Users;
            _movieIDs = _individual.MovieList.Select(m => m.MovieId).ToList();
            _allRatings = DataHolder.GetInstance().TrainingRatings;
        }
        public double Compute()
        {
            double predict_AU_ind = 0;
            double avg_rating_AU = _AU.TrainingRatings.Average(r => r.Rate);
            foreach (var movieItem in _individual.MovieList)
            {
                double fraction = _compute_fraction(movieItem.MovieId);
                predict_AU_ind += avg_rating_AU + fraction;
            }
            return predict_AU_ind;
        }
        private double _compute_fraction(int movieId)
        {
            double nominator = 0 , denominator = 0;
            var userPlus = _getUserPlus();

            foreach (var user in userPlus)
            {
                double userAvgRating = user.Ratings.Average(r => r.Rate);
                Rating userItemRate = user.Ratings
                    .Where(r => r.MovieId.Equals(movieId))
                    .FirstOrDefault();
                if (userItemRate == null)
                {
                    continue;
                }

                double userRateingDiffAvg = userItemRate.Rate - userAvgRating;

                denominator += user.PearsonValue;
                nominator += user.PearsonValue * userRateingDiffAvg;
            }
            double result = 0;
            if (!denominator.Equals(0))
            {
                result = nominator / denominator;
            }
            return result;
        }
        private List<User> _getUserPlus()
        {
            var userIDs = _allRatings
                .Where(r => _movieIDs.Contains(r.MovieId))
                .Select(r => r.UserId)
                .Distinct()
                .ToArray();



            return _allUsers.Where(u => userIDs.Contains(u.UserId)).ToList();
        }
    }
}
