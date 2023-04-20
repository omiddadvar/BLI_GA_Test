using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes
{
    public class ActiveUser
    {
        private static ActiveUser instance;
        public static ActiveUser GetInstance()
        {
            if(instance == null)
                instance = new ActiveUser();
            return instance;
        }
        public List<Rating> Ratings { get;
            set;
        }
        private ActiveUser() 
        {
            long maxRatingId = DataHolder.GetInstance().MaxRatingID;
            Ratings = new List<Rating>()
            {
                new Rating()
                {
                    MovieId = 1814,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 3.5
                },
                new Rating()
                {
                    MovieId = 1754,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 5
                },
                new Rating()
                {
                    MovieId = 1676,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 4
                }
            };
        }
    }
}
