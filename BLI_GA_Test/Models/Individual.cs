using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Models
{
    public class Individual
    {
        public double SemCorrRating { get; set; }
        public List<ExtendedMovie> MovieList { get; set; }
        public double Fitness { get; set; }
        public double PredictSatRating { get; set; }
    }
}
