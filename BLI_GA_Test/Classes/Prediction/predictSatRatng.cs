using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Prediction
{
    public class predictSatRatng
    {
        private double _predict_AU_i;
        private double _avg_rating_AU;
        private List<Individual> _individuals;
        public predictSatRatng(ref List<Individual> individuals)
        {
            _individuals = individuals;
        }
        public void Compute()
        {
            foreach(var ind in _individuals)
            {
                ind.PredictSatRating = computations(ind);
            }
        }
        private double computations(Individual individual)
        {
            return 0;
        }
    }
}
