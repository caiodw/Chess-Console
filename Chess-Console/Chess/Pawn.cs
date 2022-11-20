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
        public ChessMatch ChessMatch { get; private set; }

        public Pawn(Board board, Color color,ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
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
                //Special move En Passant
                if (Position.Line == 3)
                {
                    Position leftPosition = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(leftPosition) && Enemy(leftPosition) && Board.Piece(leftPosition) == ChessMatch.VulnerableEnPassant)
                    {
                        match[leftPosition.Line-1, leftPosition.Column] = true;
                    }
                    Position rightPosition = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(rightPosition) && Enemy(rightPosition) && Board.Piece(rightPosition) == ChessMatch.VulnerableEnPassant)
                    {
                        match[rightPosition.Line-1, rightPosition.Column] = true;
                    }
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
                //Special move En Passant
                if (Position.Line == 4)
                {
                    Position leftPosition = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(leftPosition) && Enemy(leftPosition) && Board.Piece(leftPosition) == ChessMatch.VulnerableEnPassant)
                    {
                        match[leftPosition.Line +1, leftPosition.Column] = true;
                    }
                    Position rightPosition = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(rightPosition) && Enemy(rightPosition) && Board.Piece(rightPosition) == ChessMatch.VulnerableEnPassant)
                    {
                        match[rightPosition.Line +1, rightPosition.Column] = true;
                    }
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
