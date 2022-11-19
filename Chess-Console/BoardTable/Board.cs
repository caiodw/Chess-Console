using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardTable
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }
        public Piece Piece(int lines, int columns)
        {
            return Pieces[lines, columns];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public bool PieceExists(Position position)
        {
            CheckPosition(position);
            return Piece(position) != null;
        }

        //Add piece to board
        public void PutPiece(Piece piece,Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("There's already a piece in that position!");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
        public Piece DropPiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }
            Piece auxiliaryPiece = Piece(position);
            auxiliaryPiece.Position = null;
            Pieces[position.Line, position.Column]= null;
            return auxiliaryPiece;
        }
        //Valid Position
        public bool ValidPosition(Position position)
        {
            if (position.Line<0|| position.Line>=Lines|| position.Column<0|| position.Column>=Columns)
            {
                return false;
            }
            return true;
        }

        public void CheckPosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
