using BLI_GA_Test.Classes.Data;
using BLI_GA_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes
{
    public class ActiveUser
    {
        private static ActiveUser instance;
        public static ActiveUser GetInstance()
        {
            if(instance == null)
                instance = new ActiveUser();
            return instance;
        }
        public int UserId { get; set; }
        public List<Rating> TrainingRatings { get; set; }
        public List<Rating> TestRatings { get; set; }
        private ActiveUser() 
        {

        }
    }
}
