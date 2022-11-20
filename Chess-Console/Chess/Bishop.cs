using BoardTable;
using BoardTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        private bool IsAcceptedMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] AcceptedMoves()
        {
            bool[,] match = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);
            //NW
            position.SetValues(Position.Line - 1, Position.Column -1);
            while (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line-1,position.Column-1);
            }
            //NE
            position.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line + 1, position.Column + 1);
            }
            //SE
            position.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line - 1, position.Column + 1);
            }
            //Left
            position.SetValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line + 1, position.Column - 1);
            }
            return match;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
