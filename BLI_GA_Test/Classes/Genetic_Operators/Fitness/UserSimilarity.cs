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
        private ActiveUser _activeUser;
        private List<User> _allUsers;
        private int[] _activeUserMovies;
        private int[] _userIDs_HaveCommonMovies_WithAU;
        public UserSimilarity()
        {
            _activeUser = ActiveUser.GetInstance();
            _activeUserMovies = _activeUser.Ratings.Select(r => r.MovieId).ToArray();
            _userIDs_HaveCommonMovies_WithAU = _activeUser.Ratings
                .Where(r => _activeUserMovies.Contains(r.MovieId))
                .Select(r => r.UserId)
                .Distinct()
                .ToArray();

            _allUsers = DataHolder.GetInstance().Users;
        } 
        public List<User> Compute()
        {
            var users = _allUsers
                .Where(u => _userIDs_HaveCommonMovies_WithAU.Contains(u.Id))
                .ToList();
            foreach (var user in users)
            {
                user.similarityWithActiveUser = new SatSimU(user.Id).Compute();
            }
            return _allUsers;
        }
    }
}
