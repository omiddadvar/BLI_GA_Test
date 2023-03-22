using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Semantic_Correlation
{
    public class SemSimInd
    {
        MovieItem _movieA, _movieB;
        int F11, F10, F01;
        int importance_degree_tag = 1,
            importance_degree_genre = 1;
        public SemSimInd(MovieItem MovieA , MovieItem MovieB)
        {
            this._movieA = MovieA;
            this._movieB = MovieB;

            var ConfigValues = Configs.GetInstance().ConfigValues;
            importance_degree_tag = ConfigValues.ImportanceDegree["Importance degree of Tag"];
            importance_degree_genre = ConfigValues.ImportanceDegree["Importance degree of Genre"];
        }
        public double Calculate_Similarity()
        {
            //---sorting-----
            Array.Sort(_movieA.Tags);
            Array.Sort(_movieA.Genre);
            Array.Sort(_movieB.Tags);
            Array.Sort(_movieB.Genre);

            //---Calculation-----
            F11 = _calculate_Incommons();
            F10 = _calculate_A_Not_B();
            F01 = _calculate_B_Not_A();
            return (double) F11 / (F10 + F01 + F11);
        }
        private int _calculate_Incommons()
        {
            int inCommon_Tags = _movieA.Tags.Count() - _movieA.Tags.Except(_movieB.Tags).Count();
            int inCommon_Genre = _movieA.Genre.Count() - _movieA.Genre.Except(_movieB.Genre).Count();
            return inCommon_Tags * importance_degree_tag + inCommon_Genre * importance_degree_genre;
        }
        private int _calculate_A_Not_B()
        {
            int tags_In_A_Not_B = _movieA.Tags.Except(_movieB.Tags).Count();
            int genre_In_A_Not_B = _movieA.Genre.Except(_movieB.Genre).Count();
            return tags_In_A_Not_B * importance_degree_tag + genre_In_A_Not_B * importance_degree_genre;
        }
        private int _calculate_B_Not_A()
        {
            int tags_In_B_Not_A = _movieB.Tags.Except(_movieA.Tags).Count();
            int genre_In_B_Not_A = _movieB.Genre.Except(_movieA.Genre).Count();
            return tags_In_B_Not_A * importance_degree_tag + genre_In_B_Not_A * importance_degree_genre;
        }

    }
}
