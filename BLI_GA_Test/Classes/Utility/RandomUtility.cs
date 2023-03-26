using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Classes.Utility
{
    public class RandomUtility
    {
        private static Random _randomGenerator = new Random(DateTime.Now.Millisecond);
        public static int RandomNumber(int start, int end)
        {
            int randomNumber = _randomGenerator.Next(start, end);
            return randomNumber;
        }
    }
}
