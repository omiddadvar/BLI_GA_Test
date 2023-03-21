using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Data
{
    public class InitialData : IData<MovieItem>, IDisposable
    {
        private UnitOfWork _unitOfWork;
        private List<MovieItem> _movieItems;
        public List<MovieItem> Movies => _movieItems;

        public InitialData()
        {
            _movieItems = new List<MovieItem>();
            _unitOfWork = new UnitOfWork();
        }
        public List<MovieItem> GetData()
        {
            try
            {
                var db = _unitOfWork.GetDB();
                var _movies = db.Movies1.OrderBy(m => m.MovieId).Take(100).ToList();
                var _movie_genre = db.Movie_Genre.ToList();
                var _movie_tags = db.Movie_Tag.ToList();

                foreach (var movieEntity in _movies)
                {
                    var tempMovieItem = new MovieItem()
                    {
                        MovieId = movieEntity.MovieId,
                        Name = movieEntity.MovieName
                    };
                    tempMovieItem.Tags = _movie_tags
                            .Where(mt => mt.MovieId.Equals(movieEntity.MovieId))
                            .Select(t => t.TagId)
                            .ToArray();
                    tempMovieItem.Genre = _movie_genre
                            .Where(mt => mt.MovieId.Equals(movieEntity.MovieId))
                            .Select(t => (int)t.GenreId)
                            .ToArray();

                    _movieItems.Add(tempMovieItem);
                }
                return _movieItems;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
