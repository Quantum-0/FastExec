using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Exec
{
    internal class Exec
    {
        public string Name { get; set; }
        public string ExecPath { get; set; }
        public char Key { get; set; }

        public override string ToString()
        {
            return "<" + Key + "> | " + Name;
        }
    }
}
