﻿using BoardTable;
using BoardTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
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
            Position position = new Position(0,0);
            //N
            position.SetValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
            }
            //NE
            position.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
            }
            //E
            position.SetValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
            }
            //SE
            position.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
            }
            //S
            position.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
            }
            //SW
            position.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
            }
            //W
            position.SetValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
            }
            //NW
            position.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && IsAcceptedMove(position))
            {
                match[position.Line, position.Column] = true;
            }
            return match;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
