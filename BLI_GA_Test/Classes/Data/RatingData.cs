using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Data
{
    public class RatingData : IData<Rating> , IDisposable
    {
        private UnitOfWork _unitOfWork;
        public RatingData()
        {
            _unitOfWork = new UnitOfWork();
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public List<Rating> FetchData()
        {
            try
            {
                var db = _unitOfWork.GetDB();
                var ratings = db.Ratings.ToList();
                //foreach (var rating in db.Ratings.ToList())
                //{
                //    ratings.Add(new Rating
                //    {
                //        RatingId= rating.RatingId,
                //        MovieId= rating.MovieId,
                //        UserId= rating.UserId,
                //        Rate= rating.Rate
                //    });
                //}
                return ratings;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
