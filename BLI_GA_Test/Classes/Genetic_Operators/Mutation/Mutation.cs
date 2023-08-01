using BLI_GA_Test.Classes.Data;
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
    public class Mutation : IAppliable
    {
        private List<Individual> _parents;
        private int _parentSize;
        private ConfigModel _configs;
        private DataHolder _dataHolder;

        public Mutation(ref List<Individual> parents)
        {
            _parents = parents;
            _parentSize = _parents.Count();
            _configs = Configs.GetInstance().ConfigValues;
            _dataHolder = DataHolder.GetInstance();
        }
        public void Apply()
        {
            int mutationNumbers = RandomUtility.RandomNumber(1, (int)(_parentSize * 0.1));
            var threads = new List<Thread>();
            for (int i = 0; i < mutationNumbers; i++)
            {
                threads.Add(new Thread(() => _mutation_operation()));
            }
            threads.ForEach(t => t.Start());
            threads.ForEach(t => t.Join());
            /*
            for(int i = 0; i < mutationNumbers; i++)
            {
                _mutation_operation();
            }
            */
        }
        private void _mutation_operation()
        {
            int randomParentNumber = RandomUtility.RandomNumber(0, _parentSize -1);
            Individual parent = _parents[randomParentNumber];
            int randomItemToMutate = RandomUtility.RandomNumber(0, parent.MovieList.Count - 1);

            ExtendedMovie randomGene = _getRandomGene(ref parent);
            parent.MovieList[randomItemToMutate] = randomGene;
        }
        private ExtendedMovie _getRandomGene(ref Individual individual)
        {
            var allGenes = _dataHolder.Genes;
            ExtendedMovie randomItem;
            bool notFound = true;
            do
            {
                int randomGene = RandomUtility.RandomNumber(1, allGenes.Count());
                randomItem = allGenes[randomGene];
                notFound = individual.MovieList.Contains(randomItem);
            } 
            while (notFound);

            return randomItem;
        }
    }
}
