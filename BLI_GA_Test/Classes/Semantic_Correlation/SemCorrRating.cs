﻿using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLI_GA_Test.Classes.Semantic_Correlation
{
    public class SemCorrRating
    {
        private List<MovieItem> _individual;
        public SemCorrRating(List<MovieItem> individual) 
        {
            this._individual = individual;
        }
        //private void _getInitialData()
        //{
        //    var dataReader = new InitialData();
        //    _movieItems = dataReader.GetData();
        //    dataReader.Dispose();
        //}
        public double Compute_SimilarityCorrelation()
        {
            double SemanticSimilarityCorrelation = 0;
            for(int i = 0; i < _individual.Count(); i++)
            {
                for (int j = i; j < _individual.Count(); j++)
                {
                    //  SemSimI(A,B) = SemSimI(B,A) 
                    //  SemCorrRating(ind) = semSimI(A,B) + semSimI(B,C) + semSimI(A,C)
                    var SemSimI = new SemSimInd(_individual[i] , _individual[j]);
                    SemanticSimilarityCorrelation += SemSimI.Calculate_Similarity();
                }
            }
            return SemanticSimilarityCorrelation;
        }
    }
}
