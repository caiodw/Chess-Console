using BoardTable;
using BoardTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "R";
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
            //Up
            position.SetValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line--;
            }
            //Down
            position.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line++;
            }
            //Right
            position.SetValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column++;
            }
            //Left
            position.SetValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column--;
            }
            return match;
        }
    }
}
