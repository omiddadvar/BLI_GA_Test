using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Models
{
    public class ExtendedMovie : Movie
    {
        public ExtendedMovie() : base()
        {
            PredictedRating = -1;
        }
        public double PredictedRating { get; set; }
    }
}
