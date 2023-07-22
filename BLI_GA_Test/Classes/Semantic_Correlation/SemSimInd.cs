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
        Movie _movieA, _movieB;
        int F11, F10, F01;
        double importance_degree_tag = 1,
            importance_degree_genre = 1;
        public SemSimInd(Movie MovieA , Movie MovieB)
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
            
            //Comparison<Movie_Tag> com=new Comparison<Movie_Tag>()
            //_movieA.Movie_Tag.Sort(()
            //_movieA.Genre.Sort();
            //_movieB.Tags.Sort();
            //_movieB.Genre.Sort();

            //---Calculation-----
            F11 = _calculate_Incommons();
            F10 = _calculate_A_Not_B();
            F01 = _calculate_B_Not_A();
            return (double) F11 / (F10 + F01 + F11);
        }
        private int _calculate_Incommons()
        {
            int inCommon_Tags = _movieA.Movie_Tag.Count() - _movieA.Movie_Tag.Except(_movieB.Movie_Tag).Count();
            int inCommon_Genre = _movieA.Movie_Genre.Count() - _movieA.Movie_Genre.Except(_movieB.Movie_Genre).Count();
            return (int)(inCommon_Tags * importance_degree_tag + inCommon_Genre * importance_degree_genre);
        }
        private int _calculate_A_Not_B()
        {
            int tags_In_A_Not_B = _movieA.Movie_Tag.Except(_movieB.Movie_Tag).Count();
            int genre_In_A_Not_B = _movieA.Movie_Genre.Except(_movieB.Movie_Genre).Count();
            return (int)(tags_In_A_Not_B * importance_degree_tag + genre_In_A_Not_B * importance_degree_genre);
        }
        private int _calculate_B_Not_A()
        {
            int tags_In_B_Not_A = _movieB.Movie_Tag.Except(_movieA.Movie_Tag).Count();
            int genre_In_B_Not_A = _movieB.Movie_Genre.Except(_movieA.Movie_Genre).Count();
            return (int)(tags_In_B_Not_A * importance_degree_tag + genre_In_B_Not_A * importance_degree_genre);
        }

    }
}
