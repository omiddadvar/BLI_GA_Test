using BLI_GA_Test.Classes;
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
            var configs = Configs.GetInstance().ConfigValues;
            var population = new PopulationGenerator().Generate();
            //Top 10% best individuals according to Semantic-Correlation by "Tag,Genre"
            var TopBestIndividuals_Correlation = population
                .OrderByDescending(ind => ind.SemCorrRating)
                .Take((int)(configs.PopulationSize * 0.10))
                .ToList();

        }
    }
}
