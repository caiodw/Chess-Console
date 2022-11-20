using BoardTable;
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
        public ChessMatch ChessMatch { get; private set; }

        public King(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
        }

        private bool IsAcceptedMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        private bool TestRookToCastle(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null & piece is Rook && piece.Color == Color && piece.MovesAmount == 0;
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

            //Special moves
            //Castle
            if (MovesAmount==0 && !ChessMatch.MatchCheck)
            {
                //Litle Castle
                Position rookPosition1 = new Position(Position.Line, Position.Column + 3);
                if (TestRookToCastle(rookPosition1))
                {
                    Position position1 = new Position(Position.Line, Position.Column + 1);
                    Position position2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Piece(position1)==null && Board.Piece(position2)==null)
                    {
                        match[position.Line, position.Column + 2] = true;
                    }
                }
                //Big Castle
                Position rookPosition2 = new Position(Position.Line, Position.Column - 4);
                if (TestRookToCastle(rookPosition2))
                {
                    Position position1 = new Position(Position.Line, Position.Column - 1);
                    Position position2 = new Position(Position.Line, Position.Column - 2);
                    Position position3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(position1) == null && Board.Piece(position2) == null && Board.Piece(position3) == null)
                    {
                        match[position.Line, position.Column - 2] = true;
                    }
                }
            }

            return match;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
