using BLI_GA_Test.Classes;
using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Classes.Genetic_Operators;
using BLI_GA_Test.Classes.Genetic_Operators.Fitness;
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
            var bli = new BLI_Algorithm();
            bli.Run();
        }
    }
}
