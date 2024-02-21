using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.InfiniteCraft.Business
{
    public interface IFormulaRepo
    {
        bool TryAdd(string item1, string item2, string result);
    }
}
