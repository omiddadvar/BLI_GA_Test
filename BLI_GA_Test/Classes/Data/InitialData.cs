using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Data
{
    public class InitialData : IData<ExtendedMovie>, IDisposable
    {

        private UnitOfWork _unitOfWork;

        public InitialData()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<ExtendedMovie> FetchData()
        {
            try
            {
                var db = _unitOfWork.GetDB();
                var movies = db.Movies
                    .OrderBy(m => m.MovieId)
                    .Select(m => new ExtendedMovie
                    {
                        MovieId = m.MovieId,
                        MovieName = m.MovieName
                    })
                    .ToList();

                
                return movies;
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
