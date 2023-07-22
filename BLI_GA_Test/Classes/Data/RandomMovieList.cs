using BLI_GA_Test.Classes.Utility;
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
        private ConfigModel _configs;
        public RandomMovieList()
        {
            _configs = Configs.GetInstance().ConfigValues;
        }
        public List<ExtendedMovie> GetRandomListOfMovieItems()
        {
            try
            {
                var resultData = new List<ExtendedMovie>();
                var dataHolder = DataHolder.GetInstance();
                int MovieListCount = dataHolder.Genes.Count();

                for (int i = 0; i < _configs.IndividualListSize; i++)
                {
                    int randomNumber = RandomUtility.RandomNumber(0, MovieListCount);
                    ExtendedMovie item = dataHolder.Genes[randomNumber];
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
