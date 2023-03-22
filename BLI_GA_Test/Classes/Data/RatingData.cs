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
                var _ratings = db.Ratings.ToList();
                return _ratings;
            }
            catch
            {
                return null;
            }
        }
    }
}
