using BLI_GA_Test.Models;
using BLI_GA_Test.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test
{
    public class UnitOfWork : IDisposable
    {
        TestEntities db = new TestEntities();
        public TestEntities Context => db;
        public void Dispose() => db.Dispose();
        public virtual void Save() => db.SaveChanges();


        public TestEntities GetDB()
        {
            if (db == null) 
                db = new TestEntities();
            return db;
        }
        //----------------Movie-----------------
        private GenericRepository<Movie> _movieRepository;
        public GenericRepository<Movie> MovieRepository
        {
            get
            {
                if (_movieRepository == null)
                {
                    _movieRepository = new GenericRepository<Movie>(db);
                }
                return _movieRepository;
            }
        }
        //----------------Genre-----------------
        private GenericRepository<Genre> _genreRepository;
        public GenericRepository<Genre> GenreRepository
        {
            get
            {
                if (_genreRepository == null)
                {
                    _genreRepository = new GenericRepository<Genre>(db);
                }
                return _genreRepository;
            }
        }
        //----------------Movie_Genre-----------------
        private GenericRepository<Movie_Genre> _movieGenreRepository;
        public GenericRepository<Movie_Genre> MovieGenreRepository
        {
            get
            {
                if (_movieGenreRepository == null)
                {
                    _movieGenreRepository = new GenericRepository<Movie_Genre>(db);
                }
                return _movieGenreRepository;
            }
        }
        //----------------Tag-----------------
        private GenericRepository<Tag> _tagRepository;
        public GenericRepository<Tag> TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new GenericRepository<Tag>(db);
                }
                return _tagRepository;
            }
        }
        //----------------Movie_Tag-----------------
        private GenericRepository<Movie_Tag> _movieTagRepository;
        public GenericRepository<Movie_Tag> MovieTagRepository
        {
            get
            {
                if (_movieTagRepository == null)
                {
                    _movieTagRepository = new GenericRepository<Movie_Tag>(db);
                }
                return _movieTagRepository;
            }
        }
        //----------------Rating-----------------
        private GenericRepository<Rating> _ratingRepository;
        public GenericRepository<Rating> RatingRepository
        {
            get
            {
                if (_ratingRepository == null)
                {
                    _ratingRepository = new GenericRepository<Rating>(db);
                }
                return _ratingRepository;
            }
        }
    }
}
