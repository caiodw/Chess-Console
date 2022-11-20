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
            Screen.PrintChessMatch(chessMatch);

            Console.WriteLine();
            Console.Write("Source: ");
            Position source = Screen.ReedChessPosition().toPosition();
            chessMatch.CheckSource(source);
            bool[,] acceptedMoves = chessMatch.Board.Piece(source).AcceptedMoves();
            Console.Clear();
            Screen.PrintBoard(chessMatch.Board, acceptedMoves);
            Console.WriteLine();
            Console.Write("Target: ");
            Position target = Screen.ReedChessPosition().toPosition();
            chessMatch.CheckTarget(source, target);
            chessMatch.MakeMove(source, target);
        }
        catch (BoardException boardException)
        {
            Console.WriteLine(boardException.Message);
            Console.ReadLine();
        }
        Console.Clear();
        Screen.PrintChessMatch(chessMatch);
    }
}
catch (BoardException boardException)
{
    Console.WriteLine(boardException.Message);
}