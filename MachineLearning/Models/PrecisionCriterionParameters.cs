using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning.Models
{
    public class PrecisionCriterionParameters
    {
        public double MAE { get; set; }
        public double Recall { get; set; }
        public double Precision { get; set; }
        public double F1_Measure 
        {
            get => (2 * Precision * Recall) / (Precision + Recall);
        }
    }
}
