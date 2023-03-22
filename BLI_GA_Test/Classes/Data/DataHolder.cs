using BLI_GA_Test.Models;
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
        private DataHolder()
        {
            _getAllMovies();
        }
        private void _getAllMovies()
        {
            var dataReader = new InitialData();
            _allMovieItems = dataReader.FetchData();
        }
    }
}
