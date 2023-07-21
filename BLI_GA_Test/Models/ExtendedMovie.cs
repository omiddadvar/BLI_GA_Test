using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Models
{
    internal class ExtendedMovie : Movie
    {
        public ExtendedMovie() : base()
        {
            Rating = -1;
        }
        public double Rating { get; set; }
    }
}
