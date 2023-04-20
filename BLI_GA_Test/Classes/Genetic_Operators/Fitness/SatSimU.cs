using BLI_GA_Test.Interfaces;
using BLI_GA_Test.Models;
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
        private User _user;
        private ActiveUser _AU;
        public SatSimU(ActiveUser AU, User user)
        {
            _user = user;
            _AU = AU;
        }
        public double Compute()
        {
            double JaccardValue = new Jaccard(_user.UserId).Compute();

            return (double) _user.PearsonValue * JaccardValue;
        }
    }
}
