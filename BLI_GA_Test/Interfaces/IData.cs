using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLI_GA_Test.Interfaces
{
    public interface IData<T>
    {
        List<T> GetData();
    }
}
