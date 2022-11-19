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

        public ChessMatch()
        {
            Board = new Board(8,8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void ExecuteMove(Position originPosition,Position destinationPosition)
        {
            Piece piece=Board.DropPiece(originPosition);
            piece.IncreaseAmountMovements();
            Piece capturedPiece = Board.DropPiece(destinationPosition);
            Board.PutPiece(piece, destinationPosition);
        }
        public void MakeMove(Position origin,Position destination)
        {
            ExecuteMove(origin, destination);
            Round++;
            ChangePlayer();
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
        private void PutPieces()
        {
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('a', 1).toPosition());
            Board.PutPiece(new Knight(Board, Color.White), new ChessPosition('b', 1).toPosition());
            Board.PutPiece(new Bishop(Board, Color.White), new ChessPosition('c', 1).toPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).toPosition());
            Board.PutPiece(new Queen(Board, Color.White), new ChessPosition('e', 1).toPosition());
            Board.PutPiece(new Bishop(Board, Color.White), new ChessPosition('f', 1).toPosition());
            Board.PutPiece(new Knight(Board, Color.White), new ChessPosition('g', 1).toPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('h', 1).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('a', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('b', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('c', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('d', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('e', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('f', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('g', 2).toPosition());
            //Board.PutPiece(new Pawn(Board, Color.White), new ChessPosition('h', 2).toPosition());

            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('a', 8).toPosition());
            Board.PutPiece(new Knight(Board, Color.Black), new ChessPosition('b', 8).toPosition());
            Board.PutPiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8).toPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPosition());
            Board.PutPiece(new Queen(Board, Color.Black), new ChessPosition('e', 8).toPosition());
            Board.PutPiece(new Bishop(Board, Color.Black), new ChessPosition('f', 8).toPosition());
            Board.PutPiece(new Knight(Board, Color.Black), new ChessPosition('g', 8).toPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('h', 8).toPosition());
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
