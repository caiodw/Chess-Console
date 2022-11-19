using BoardTable;
using BoardTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "H";
        }
    }
}
