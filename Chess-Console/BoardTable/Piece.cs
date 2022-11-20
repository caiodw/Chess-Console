using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardTable.Enums;

namespace BoardTable
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovesAmount { get; set; }
        public Board Board { get; set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            MovesAmount = 0;
        }
        public void IncreaseAmountMovements()
        {
            MovesAmount++;
        }
        public bool IsPossibleToMove()
        {
            bool[,] match = AcceptedMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (match[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CheckMoveFor(Position position)
        {
            return AcceptedMoves()[position.Line, position.Column];
        }
        public abstract bool[,] AcceptedMoves();
    }
}
