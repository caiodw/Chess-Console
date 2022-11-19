using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardTable.Enums;

namespace BoardTable
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtyMooves { get; set; }
        public Board Board { get; set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            QtyMooves = 0;
        }
    }
}
