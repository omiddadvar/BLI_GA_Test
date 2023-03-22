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
        private List<MovieItem> _allMovieItems;
        public List<MovieItem> Genes => _allMovieItems;

        private List<Rating> _ratings;
        public List<Rating> Ratings => _ratings;

        private long _maxRatingID = -1;
        public long MaxRatingID => _maxRatingID;
        private DataHolder()
        {
            _getAllMovies();
            _getRatingData();
            _maxRatingID = _ratings.OrderByDescending(r => r.RatingId).First().RatingId;
        }
        private void _getAllMovies()
        {
            var dataReader = new InitialData();
            _allMovieItems = dataReader.FetchData();
        }
        private void _getRatingData()
        {
            var dataReader = new RatingData();
            _ratings = dataReader.FetchData();
        }
    }
}
