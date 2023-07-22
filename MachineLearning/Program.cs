using BLI_GA_Test.Classes;
using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Models;
using MachineLearning.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var trainingProcess = new TrainingProcess();
            trainingProcess.Run();

            Console.ReadKey();
        }

    }
}
