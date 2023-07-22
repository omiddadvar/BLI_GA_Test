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
    public class UserSimilarity : IComputable<List<User>>
    {
        private ActiveUser _AU;
        private List<User> _allUsers;
        private List<int> _activeUserMovies;
        private List<int> _userIDs_HaveCommonMovies_WithAU;
        private List<Rating> _allRatings;
        public UserSimilarity(ActiveUser AU)
        {
            _AU = AU;
            _activeUserMovies = _AU.TrainingRatings.Select(r => r.MovieId).ToList();
            _allRatings = DataHolder.GetInstance().Ratings;
            _userIDs_HaveCommonMovies_WithAU = _allRatings
                .Where(r => _activeUserMovies.Contains(r.MovieId))
                .Select(r => r.UserId)
                .Distinct()
                .ToList();

            _allUsers = DataHolder.GetInstance().Users;
        } 
        public List<User> Compute()
        {
            _compute_pearson();
            _compute_similarity();
            return _allUsers;
        }
        private void _compute_pearson()
        {
            foreach (var user in _allUsers)
            {
                user.PearsonValue = new PearsonSim(_AU, user.UserId).Compute();
            }
        }
        private void _compute_similarity()
        {
            var users = _allUsers
                        .Where(u => _userIDs_HaveCommonMovies_WithAU.Contains(u.UserId))
                        .ToList();
            foreach (var user in users)
            {
                user.SimilarityWithActiveUser = new SatSimU(_AU, user).Compute();
            }
        }
    }
}
