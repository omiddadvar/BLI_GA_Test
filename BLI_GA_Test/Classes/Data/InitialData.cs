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
    public class InitialData : IData<Movie>, IDisposable
    {

        private UnitOfWork _unitOfWork;

        public InitialData()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<Movie> FetchData()
        {
            try
            {
                //var movieItems = new List<MovieItem>();
                var db = _unitOfWork.GetDB();
                var _movies = db.Movies
                    .OrderBy(m => m.MovieId)
                    //.Take(100)
                    .ToList();

                //var _movie_genre = db.Movie_Genre.ToList();
                //var _movie_tags = db.Movie_Tag.ToList();
                //foreach (var movieEntity in _movies)
                //{
                //    var tempMovieItem = new MovieItem()
                //    {
                //        MovieId = movieEntity.MovieId,
                //        Name = movieEntity.MovieName
                //    };
                //    tempMovieItem.Tags = _movie_tags
                //            .Where(mt => mt.MovieId.Equals(movieEntity.MovieId))
                //            .Select(t => t.TagId)
                //            .ToList();
                //    tempMovieItem.Genre = _movie_genre
                //            .Where(mt => mt.MovieId.Equals(movieEntity.MovieId))
                //            .Select(t => (int)t.GenreId)
                //            .ToList();

                //    movieItems.Add(tempMovieItem);
                //}
                //return movieItems;
                return _movies;
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
