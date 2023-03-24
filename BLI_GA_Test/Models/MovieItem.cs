using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Models
{
    public class MovieItem
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int[] Tags { get; set; }
        public int[] Genre { get; set; }
        public double similarityDegree { get; set; }
	}
}
