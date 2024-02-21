using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.InfiniteCraft.Business
{
    public class FormulaRepo : IFormulaRepo
    {
        // Simple way: Store everything as strings.  No integer lookups.
        private Dictionary<string, string> Formulas { get; set; }


        public FormulaRepo()
        {
            Formulas = new Dictionary<string, string>();
        }

        public bool TryAdd(string item1, string item2, string result)
        {
            var key = GetKey(item1, item2);
            if (Formulas.ContainsKey(key))
            {
                return false;
            }

            Formulas.Add(key, result);
            return true;
        }

        private string GetKey(string item1, string item2)
        {
            return item1.CompareTo(item2) < 0 ? $"{item1}+{item2}" : $"{item2}+{item1}";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var key in Formulas.Keys.OrderBy(x => x))
            {
                sb.Append($"{key}>{Formulas[key]};");
            }

            return sb.ToString();
        }
    }
}
