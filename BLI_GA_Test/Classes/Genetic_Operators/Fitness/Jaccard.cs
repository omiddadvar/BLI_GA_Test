using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Genetic_Operators.Fitness
{
    public class Jaccard : IComputable<double>
    {
        private int _userId;
        private ActiveUser AU;
        public Jaccard(int userId)
        {
            _userId = userId;
            AU = ActiveUser.GetInstance();
        }


        public double Compute()
        {
            List<Rating> userRating_Raw = _getUserRating();
            List<Rating> ActiveUserRating_Raw = AU.Ratings;
            int CommonMoviesCount = _getCommonMovies(ref userRating_Raw, ref ActiveUserRating_Raw).Count();
            int AllMoviesCount = _getAllMovies(ref userRating_Raw, ref ActiveUserRating_Raw).Count();
            return ((double)CommonMoviesCount) / AllMoviesCount;
        }

        private List<Rating> _getUserRating()
        {
            return DataHolder.GetInstance().Ratings
                .Where(r => r.UserId.Equals(_userId))
                .ToList();
        }

        private int[] _getCommonMovies(ref List<Rating> userRating, ref List<Rating> AURating)
        {
            int[] movieIds_user = userRating.Select(r => r.MovieId).ToArray();
            int[] movieIds_AU = AURating.Select(r => r.MovieId).ToArray();
            return movieIds_user.Intersect(movieIds_AU).ToArray();
        }

        private int[] _getAllMovies(ref List<Rating> userRating, ref List<Rating> AURating)
        {
            int[] movieIds_user = userRating.Select(r => r.MovieId).ToArray();
            int[] movieIds_AU = AURating.Select(r => r.MovieId).ToArray();
            return movieIds_user.Union(movieIds_AU).ToArray();
        }

    }
}
