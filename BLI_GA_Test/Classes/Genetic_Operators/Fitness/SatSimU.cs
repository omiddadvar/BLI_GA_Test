using BLI_GA_Test.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Genetic_Operators.Fitness
{
    public class SatSimU : IComputable<double>
    {
        private int _userId;
        public SatSimU(int userId)
        {
            _userId = userId;
        }
        public double Compute()
        {
            double PearsonMeasureValue = new PearsonSim(_userId).Compute();
            double JaccardValue = new Jaccard(_userId).Compute();

            return (double) PearsonMeasureValue *  JaccardValue;
        }
    }
}
