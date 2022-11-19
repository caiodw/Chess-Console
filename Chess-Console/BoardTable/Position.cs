using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardTable
{
    internal class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }
        public override string ToString()
        {
            return $"{Line},{Column}";
        }

        public void SetValues(int line,int column)
        {
            Line = line;
            Column = column;
        }
    }
}
