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
        public List<Rating> Ratings { get; set; }
        private ActiveUser() 
        {
            long maxRatingId = DataHolder.GetInstance().MaxRatingID;
            Ratings = new List<Rating>()
            {
                new Rating()
                {
                    MovieId = 1005,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 3.5
                },
                new Rating()
                {
                    MovieId = 1006,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 5
                },
                new Rating()
                {
                    MovieId = 1009,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 4
                },
                new Rating()
                {
                    MovieId = 2006,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 4.5
                },
                new Rating()
                {
                    MovieId = 600,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 1.5
                },
                new Rating()
                {
                    MovieId = 4000,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 2.5
                },
                new Rating()
                {
                    MovieId = 1241,
                    RatingId = ++maxRatingId,
                    UserId = -1,
                    Rate = 3
                },
            };
        }
    }
}
