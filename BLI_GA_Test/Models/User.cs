using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Models
{
	public class User
	{
        public int Id { get; set; }
        public List<Rating> RatedMovieItems { get; set; }
        public double SimilarityWithActiveUser { get; set; } = 0;
        public double PearsonValue { get; set; } = 0;
	}
}
