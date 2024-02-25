using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.InfiniteCraft.Business
{
    public class PairResponse
    {
        public string result { get; set; }
        public string emoji { get; set; }
        public bool isNew { get; set; }
        public string Error { get; set; }

        public PairResponse()
        {
            this.result = "Nothing";
            this.emoji = "?";
            this.isNew = false;
            this.Error = "";
        }

        public PairResponse(string _result) : this()
        {
            this.result = _result;
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(this.Error))
            {
                // No error
                return $"result: {this.result}, emoji: {this.emoji}, isNew: {this.isNew}";
            }
            return $"Error: {this.Error}, result: {this.result}, emoji: {this.emoji}, isNew: {this.isNew}";
        }
    }
}
