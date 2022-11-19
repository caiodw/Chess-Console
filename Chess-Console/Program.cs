// See https://aka.ms/new-console-template for more information
using BoardTable;
using Xadrez_Console;
using Chess;
using BoardTable.Enums;

try
{
    ChessMatch chessMatch = new ChessMatch();
    while (!chessMatch.Finished)
    {
        try
        {
            Console.Clear();
            Screen.PrintBoard(chessMatch.Board);
            Console.WriteLine();
            Console.WriteLine($"Round: {chessMatch.Round}");
            Console.WriteLine($"Wainting for: {chessMatch.CurrentPlayer}");
            Console.WriteLine();
            Console.Write("Source: ");
            Position source = Screen.ReedChessPosition().toPosition();
            chessMatch.CheckSource(source);
            bool[,] acceptedMoves = chessMatch.Board.Piece(source).AcceptedMoves();
            Console.Clear();
            Screen.PrintBoard(chessMatch.Board, acceptedMoves);
            Console.WriteLine();
            Console.Write("Destination: ");
            Position destination = Screen.ReedChessPosition().toPosition();
            chessMatch.MakeMove(source, destination);
        }
        catch (BoardException boardException)
        {
            Console.WriteLine(boardException.Message);
            Console.ReadLine();
        }
    }
}
catch (BoardException boardException)
{
    Console.WriteLine(boardException.Message);
}