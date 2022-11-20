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
        public bool MatchCheck { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8,8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            MatchCheck= false;
            VulnerableEnPassant = null;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMove(Position sourcePosition, Position targetPosition)
        {
            Piece piece = Board.DropPiece(sourcePosition);
            piece.IncreaseAmountMovements();
            Piece capturedPiece = Board.DropPiece(targetPosition);
            Board.PutPiece(piece, targetPosition);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            //Special move litle Castle
            if (piece is King && targetPosition.Column == sourcePosition.Column + 2)
            {
                Position rookSource = new Position(sourcePosition.Line, sourcePosition.Column + 3);
                Position rookTarget = new Position(sourcePosition.Line,sourcePosition.Column + 1);
                Piece rook = Board.DropPiece(rookSource);
                rook.IncreaseAmountMovements();
                Board.PutPiece(rook,rookTarget);
            }
            //Special move big Castle
            if (piece is King && targetPosition.Column == sourcePosition.Column - 2)
            {
                Position rookSource = new Position(sourcePosition.Line, sourcePosition.Column - 4);
                Position rookTarget = new Position(sourcePosition.Line, sourcePosition.Column - 1);
                Piece rook = Board.DropPiece(rookSource);
                rook.IncreaseAmountMovements();
                Board.PutPiece(rook, rookTarget);
            }

            //Special move En Passant
            if (piece is Pawn)
            {
                if (sourcePosition.Column != targetPosition.Column && capturedPiece == null)
                {
                    Position pawnPosition;
                    if (piece.Color == Color.White)
                    {
                        pawnPosition = new Position(targetPosition.Line + 1, targetPosition.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(targetPosition.Line-1 , targetPosition.Column);
                    }
                    capturedPiece = Board.DropPiece(pawnPosition);
                    Captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }
        public void MakeMove(Position source, Position target)
        {
            Piece capturedPiece = ExecuteMove(source, target);
            if (IsCheck(CurrentPlayer))
            {
                UndoMove(source, target, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }
            if (IsCheck(OpponentColor(CurrentPlayer)))
            {
                MatchCheck = true;
            }
            else
            {
                MatchCheck = false;
            }
            if (IsCheckmate(OpponentColor(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Round++;
                ChangePlayer();
            }
            Piece piece = Board.Piece(target);

            //Special move En Passant
            if (piece is Pawn && (target.Line == source.Line-2 || target.Line == source.Line + 2))
            {
                VulnerableEnPassant = piece;
            }
            else
            {
                VulnerableEnPassant = null;
            }
        }
        public void UndoMove(Position sourcePosition,Position targetPosition, Piece capturedPiece)
        {
            Piece piece = Board.DropPiece(targetPosition);
            piece.DecreaseAmountMovements();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, targetPosition);
                Captured.Remove(capturedPiece);
            }
            Board.PutPiece(piece, sourcePosition);

            //Special move litle Castle
            if (piece is King && targetPosition.Column == sourcePosition.Column + 2)
            {
                Position rookSource = new Position(sourcePosition.Line, sourcePosition.Column + 3);
                Position rookTarget = new Position(sourcePosition.Line, sourcePosition.Column + 1);
                Piece rook = Board.DropPiece(rookTarget);
                rook.DecreaseAmountMovements();
                Board.PutPiece(rook, rookSource);
            }
            //Special move big Castle
            if (piece is King && targetPosition.Column == sourcePosition.Column - 2)
            {
                Position rookSource = new Position(sourcePosition.Line, sourcePosition.Column - 4);
                Position rookTarget = new Position(sourcePosition.Line, sourcePosition.Column - 1);
                Piece rook = Board.DropPiece(rookTarget);
                rook.IncreaseAmountMovements();
                Board.PutPiece(rook, rookSource);
            }
            //Special move En Passant
            if (piece is Pawn)
            {
                if (sourcePosition.Column != targetPosition.Column && capturedPiece == VulnerableEnPassant)
                {
                    Piece pawn = Board.DropPiece(targetPosition);
                    Position pawnPosition;
                    if (pawn.Color == Color.White)
                    {
                        pawnPosition = new Position(3,sourcePosition.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(4, sourcePosition.Column);
                    }
                    Board.PutPiece(pawn, pawnPosition);    
                }
            }
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
        private Color OpponentColor(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        private Piece King(Color color)
        {
            foreach (Piece piece in PlayablePieces(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece king = King(color);   
            if (king == null)
            {
                throw new BoardException($"There's no king of {color} on the board!");
            }
            foreach (Piece piece in PlayablePieces(OpponentColor(color)))
            {
                bool[,] match = piece.AcceptedMoves();
                if (match[king.Position.Line,king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsCheckmate(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach (Piece piece in PlayablePieces(color))
            {
                bool[,] match = piece.AcceptedMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (match[i,j])
                        {
                            Position source = piece.Position;
                            Position target = new Position(i, j);
                            Piece  capturedPiece = ExecuteMove(source, target);
                            bool isCheck = IsCheck(color);
                            UndoMove(source, target, capturedPiece);
                            if (!isCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void PutPieces()
        {
            PutNewPiece('a', 1, new Rook(Board, Color.White));
            PutNewPiece('b', 1, new Knight(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
            PutNewPiece('e', 1, new King(Board, Color.White, this));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('g', 1, new Knight(Board, Color.White));
            PutNewPiece('h', 1, new Rook(Board, Color.White));
            PutNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('e', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('h', 2, new Pawn(Board, Color.White, this));

            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('b', 8, new Knight(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));
            PutNewPiece('e', 8, new King(Board, Color.Black, this));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('g', 8, new Knight(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black, this));

        }
    }
}
