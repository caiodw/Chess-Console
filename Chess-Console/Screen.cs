using BoardTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardTable.Enums;
using Chess;

namespace Xadrez_Console
{
    internal class Screen
    {
        public static void PrintChessMatch(ChessMatch chessMatch)
        {
            Screen.PrintBoard(chessMatch.Board);
            Console.WriteLine();
            PrintCapturedPieces(chessMatch);
            Console.WriteLine();
            Console.WriteLine($"Round: {chessMatch.Round}");
            if (!chessMatch.Finished)
            {
                Console.WriteLine($"Wainting for: {chessMatch.CurrentPlayer}");
                if (chessMatch.MatchCheck)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE");
                Console.WriteLine($"Winner: {chessMatch.CurrentPlayer}");
            }
        }
        public static void PrintCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintSet(chessMatch.CapuredPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor tempConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(chessMatch.CapuredPieces(Color.Black));
            Console.ForegroundColor = tempConsoleColor;
            Console.WriteLine();
        }
        public static void PrintSet(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach (Piece piece in pieces)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintBoard(Board board, bool[,] acceptedMoves)
        {
            ConsoleColor originalBackgroundColor = Console.BackgroundColor;
            ConsoleColor changedBackgroundColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (acceptedMoves[i,j])
                    {
                        Console.BackgroundColor = changedBackgroundColor;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackgroundColor;
                }
                Console.BackgroundColor = originalBackgroundColor;
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }
        }
        public static ChessPosition ReedChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column,line);
        }
    }
}
