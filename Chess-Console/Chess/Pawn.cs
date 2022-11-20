using BoardTable;
using BoardTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        private bool Enemy(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }
        private bool Free(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] AcceptedMoves()
        {
            bool[,] match = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    match[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(position) && Free(position) && MovesAmount == 0)
                {
                    match[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && Enemy(position))
                {
                    match[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && Enemy(position))
                {
                    match[position.Line, position.Column] = true;
                }
            }
            else
            {
                position.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    match[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(position) && Free(position) && MovesAmount == 0)
                {
                    match[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && Enemy(position))
                {
                    match[position.Line, position.Column] = true;
                }
                position.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && Enemy(position))
                {
                    match[position.Line, position.Column] = true;
                }
            }
            return match;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
