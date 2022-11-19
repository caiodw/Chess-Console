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
        Console.Write("Origin: ");
        Position origin = Screen.ReedChessPosition().toPosition();
        Console.Write("Destination: ");
        Position destination = Screen.ReedChessPosition().toPosition();
        chessMatch.ExecuteMove(origin, destination);
    }
}
catch (BoardException boardException)
{
    Console.WriteLine(boardException.Message);
}