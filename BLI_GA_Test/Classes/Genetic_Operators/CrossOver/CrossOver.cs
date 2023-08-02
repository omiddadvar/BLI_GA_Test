using BLI_GA_Test.Classes.Utility;
using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Genetic_Operators
{
    public class CrossOver : IAppliable
    {
        private List<Individual> _parents;
        private int _parentSize;
        private ConfigModel _configs;

        public CrossOver(ref List<Individual> parents) 
        {
            _parents = parents;
            _parentSize = _parents.Count();
            _configs = Configs.GetInstance().ConfigValues;
        }
        public void Apply()
        {
            int numberOfIterations = RandomUtility.RandomNumber(1, _parentSize);
            var threads = new List<Thread>();
            for (int i = 0; i < numberOfIterations; i++)
            {
                threads.Add(new Thread(() => _crossOver_operation()));
            }
            for (int i = 0; i < numberOfIterations; i += 10)
            {
                for (int j = i; j < Math.Min(numberOfIterations, i + 10); j++)
                {
                    threads[j].Start();
                }
                for (int j = i; j < Math.Min(numberOfIterations, i + 10); j++)
                {
                    threads[j].Join();
                }
            }
        }
        private void _crossOver_operation()
        {
            Individual parent_A = _parents[RandomUtility.RandomNumber(1 , _parentSize)];
            Individual parent_B = _parents[RandomUtility.RandomNumber(1 , _parentSize)];

            int crossOverPosition = RandomUtility.RandomNumber(1, _configs.IndividualListSize);

            // Clone List
            var tmp_Movies_A = new List<ExtendedMovie>(parent_A.MovieList); 
            var tmp_Movies_B = new List<ExtendedMovie>(parent_B.MovieList);
            parent_A.MovieList.Clear();
            parent_B.MovieList.Clear();

            parent_A.MovieList = tmp_Movies_A.Take(crossOverPosition).ToList();
            parent_B.MovieList = tmp_Movies_B.Take(crossOverPosition).ToList();

            parent_A.MovieList = parent_A.MovieList
                .Union(tmp_Movies_B.Skip(crossOverPosition).ToList())
                .ToList();
            parent_B.MovieList = parent_B.MovieList
                .Union(tmp_Movies_A.Skip(crossOverPosition).ToList())
                .ToList();
        }
    }
}
