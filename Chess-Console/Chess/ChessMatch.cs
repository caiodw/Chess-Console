using BoardTable;
using BoardTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer {  get; private set; }
        public bool Finished { get; private set; }
        public HashSet<Piece> Pieces { get; private set; }
        public HashSet<Piece> Captured { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8,8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public void ExecuteMove(Position sourcePosition, Position targetPosition)
        {
            Piece piece=Board.DropPiece(sourcePosition);
            piece.IncreaseAmountMovements();
            Piece capturedPiece = Board.DropPiece(targetPosition);
            Board.PutPiece(piece, targetPosition);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
        }
        public void MakeMove(Position source, Position target)
        {
            ExecuteMove(source, target);
            Round++;
            ChangePlayer();
        }
        public void CheckSource(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("There is no part in the chosen source position!");
            }
            else if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The piece of the chosen source is not yours!");
            }
            else if (!Board.Piece(position).IsPossibleToMove())
            {
                throw new BoardException("There are no possible movements for the chosen source piece!");
            }
        }
        public void CheckTarget(Position source,Position target)
        {
            if (!Board.Piece(source).CheckMoveFor(target))
            {
                throw new BoardException("Invalid target position!");
            }
        }
        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }
        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).toPosition());
            Pieces.Add(piece);
        }

        public HashSet<Piece> PlayablePieces(Color color)
        {
            HashSet<Piece> tempPieces = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    tempPieces.Add(piece);
                }
            }
            tempPieces.ExceptWith(CapuredPieces(color));
            return tempPieces;
        }

        public HashSet<Piece> CapuredPieces(Color color)
        {
            HashSet<Piece> tempPieces = new HashSet<Piece>();
            foreach (Piece piece in Captured)
            {
                if (piece.Color == color)
                {
                    tempPieces.Add(piece);
                }
            }
            return tempPieces;
        }

        private void PutPieces()
        {
            //White Pieces
            PutNewPiece('a', 1, new Rook(Board, Color.White));
            PutNewPiece('h', 1, new Rook(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));

            //Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('a', 1).toPosition());
            //Board.PutPiece(new Knight(Board, Color.White), new ChessPosition('b', 1).toPosition());
            //Board.PutPiece(new Bishop(Board, Color.White), new ChessPosition('c', 1).toPosition());
            //Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).toPosition());
            //Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('e', 1).toPosition());
            //Board.PutPiece(new Bishop(Board, Color.White), new ChessPosition('f', 1).toPosition());
            //Board.PutPiece(new Knight(Board, Color.White), new ChessPosition('g', 1).toPosition());
            //Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('h', 1).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('a', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('b', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('c', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('d', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('e', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('f', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('g', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('h', 2).toPosition());

            //Black Pieces
            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('d', 8, new King(Board, Color.Black));
            //Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('a', 8).toPosition());
            //Board.PutPiece(new Knight(Board, Color.Black), new ChessPosition('b', 8).toPosition());
            //Board.PutPiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8).toPosition());
            //Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPosition());
            //Board.PutPiece(new Queen(Board, Color.Black), new ChessPosition('e', 8).toPosition());
            //Board.PutPiece(new Bishop(Board, Color.Black), new ChessPosition('f', 8).toPosition());
            //Board.PutPiece(new Knight(Board, Color.Black), new ChessPosition('g', 8).toPosition());
            //Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('h', 8).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('a', 7).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('b', 7).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('c', 7).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('d', 7).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('e', 7).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('f', 7).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('g', 7).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.Black), new ChessPosition('h', 7).toPosition());
        }
    }
}
