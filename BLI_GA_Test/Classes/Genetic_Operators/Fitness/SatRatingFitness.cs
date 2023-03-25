using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLI_GA_Test.Classes.Genetic_Operators.Fitness
{
    public class SatRatingFitness : IComputable<double>
    {
        private List<User> _allUsers;
        private List<User> _ratedUsers;// users Rated at least one item (movie) in our individual
        private Individual _individual;
        public SatRatingFitness(Individual individual)
        {
            _allUsers = DataHolder.GetInstance().Users_With_Similarity;
            _individual = individual;
            _ratedUsers = new List<User>();

            _findRatedUsers();
        }
        public double Compute()
        {
            double satRatingFitnessValue = 0;
            foreach(var user in _ratedUsers)
            {
                satRatingFitnessValue += user.similarityWithActiveUser;
            }
            return satRatingFitnessValue;
        }
        private void _findRatedUsers()
        {
            int[] movieIDs = _individual.MovieList.Select(m => m.MovieId).ToArray();
            foreach (User user in _allUsers)
            {
                var ratings = (from movie in movieIDs
                               join rating in user.RatedMovieItems on movie equals rating.MovieId
                               select rating)
                     .ToList();
                if (ratings.Count() > 0)
                {
                    _ratedUsers.Add(user);
                }
            }
        }
    }
}
