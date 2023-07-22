﻿using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Data
{
    public class DataHolder
    {
        private static DataHolder _instance;
        public static DataHolder GetInstance()
        {
            if(_instance == null)
                _instance = new DataHolder();
            return _instance;
        }
        private List<ExtendedMovie> _allMovies;
        public List<ExtendedMovie> Genes => _allMovies;

        private List<Rating> _ratings;
        public List<Rating> TrainingRatings { 
            get {
                int[] trainingUserIDs = TrainingUsers.Select(t => t.UserId).ToArray();
                return _ratings.Where(r => trainingUserIDs.Contains(r.UserId)).ToList();
            } 
        }
        public List<Rating> AllRatings => _ratings;

		private List<User> _users;
		public List<User> Users => _users;
		public List<User> TrainingUsers { get; set; }
        public List<User> TestUsers { get; set; }
		public List<User> Users_With_Similarity { get; set; }

		private long _maxRatingID = -1;
        public long MaxRatingID => _maxRatingID;
        private DataHolder()
        {
            _getAllMovies();
            _getRatingData();
            _getUserData();
            _maxRatingID = _ratings.OrderByDescending(r => r.RatingId).First().RatingId;
        }
        private void _getAllMovies()
        {
            var dataReader = new InitialData();
            _allMovies = dataReader.FetchData();
        }
        private void _getRatingData()
        {
            var dataReader = new RatingData();
            _ratings = dataReader.FetchData();
        }

		private void _getUserData()
		{
			var dataReader = new UserData();
			_users = dataReader.FetchData();
		}
	}
}
