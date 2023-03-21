using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Data
{
    public class RandomMovieList
    {
        private const int Length_ListOfItems = 10;
        private Random _randomGenerator = new Random(DateTime.Now.Millisecond);
        private int _RandomNumber(int start, int end)
        {
            int randomNumber = _randomGenerator.Next(start, end);
            return randomNumber;
        }
        public List<MovieItem> GetRandomListOfMovieItems()
        {
            try
            {
                var resultData = new List<MovieItem>();
                var dataHolder = DataHolder.GetInstance();
                int MovieListCount = dataHolder.AllMovieItems.Count();

                for (int i = 0; i < Length_ListOfItems; i++)
                {
                    int randomNumber = _RandomNumber(0, MovieListCount);
                    MovieItem item = dataHolder.AllMovieItems[randomNumber];
                    resultData.Add(item);
                }
                return resultData;
            }
            catch
            {
                return null;
            }            
        }
    }
}
