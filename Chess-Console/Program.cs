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
        Console.Clear();
        Screen.PrintBoard(chessMatch.Board);
        Console.WriteLine();
        Console.WriteLine($"Round: {chessMatch.Round}");
        Console.WriteLine($"Wainting for: {chessMatch.CurrentPlayer}");
        Console.WriteLine();
        Console.Write("Origin: ");
        Position origin = Screen.ReedChessPosition().toPosition();

        bool[,] acceptedMoves = chessMatch.Board.Piece(origin).AcceptedMoves();
        Console.Clear();
        Screen.PrintBoard(chessMatch.Board, acceptedMoves);
        Console.WriteLine();
        Console.Write("Destination: ");
        Position destination = Screen.ReedChessPosition().toPosition();
        chessMatch.MakeMove(origin, destination);
    }
}
catch (BoardException boardException)
{
    Console.WriteLine(boardException.Message);
}