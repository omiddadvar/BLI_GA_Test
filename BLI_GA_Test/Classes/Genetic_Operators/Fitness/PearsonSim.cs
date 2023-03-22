using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Genetic_Operators.Fitness
{
    public class PearsonSim
    {
        private int _userId;
        private ActiveUser AU;
        public PearsonSim(int userId)
        {
            _userId = userId;
            AU = ActiveUser.GetInstance();
        }
        public double Compute()
        {
            List<Rating> userRating_Raw = _getUserRating();
            List<Rating> ActiveUserRating_Raw = AU.Ratings;
            int[] commonMovieIDs = _getCommonMovies(ref userRating_Raw, ref ActiveUserRating_Raw);

            double avg_User = userRating_Raw
                .Where(r => commonMovieIDs.Contains(r.MovieId))
                .Average(r => r.Rate);
            double avg_ActiveUser = ActiveUserRating_Raw
               .Where(r => commonMovieIDs.Contains(r.MovieId))
               .Average(r => r.Rate);

            List<Rating> userRating = userRating_Raw
                .Where(r => commonMovieIDs.Contains(r.MovieId)).ToList();
            userRating_Raw.Clear(); // Free-up memory
            List<Rating> ActiveUserRatings = ActiveUserRating_Raw
                .Where(r => commonMovieIDs.Contains(r.MovieId)).ToList();
            ActiveUserRating_Raw.Clear(); // Free-up memory

            double numerator = 0 , denominator1 = 0 , denominator2 = 0;
            foreach(var item in userRating)
            {
                Rating ActiveUserRating = ActiveUserRatings
                    .Where(r => r.MovieId.Equals(item.MovieId)).First();
                numerator += (item.Rate - avg_User) * (ActiveUserRating.Rate - avg_ActiveUser);
            }
            foreach (var item in userRating)
            {
                denominator1 += Math.Pow((item.Rate - avg_User) , 2) ;
            }
            denominator1 = Math.Sqrt(denominator1);
            foreach (var item in ActiveUserRatings)
            {
                denominator2 += Math.Pow((item.Rate - avg_ActiveUser), 2);
            }
            denominator2 = Math.Sqrt(denominator2);

            return numerator / (denominator1 * denominator2);
        }
        private List<Rating> _getUserRating()
        {
            return DataHolder.GetInstance().Ratings
                .Where(r => r.UserId.Equals(_userId))
                .ToList();
        }
        private int[] _getCommonMovies(ref List<Rating> userRating ,ref List<Rating> AURating)
        {
            int[] movieIds_user = userRating.Select(r => r.MovieId).ToArray();
            int[] movieIds_AU = AURating.Select(r => r.MovieId).ToArray();
            return movieIds_user.Intersect(movieIds_AU).ToArray();
        }
    }
}
