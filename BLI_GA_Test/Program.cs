using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Classes.Semantic_Correlation;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var individual = new Individual();
            individual.MovieList = new RandomMovieList().GetRandomListOfMovieItems();
            individual.SemCorrRating = new SemCorrRating(individual.MovieList).Compute_SimilarityCorrelation();
        }
    }
}
