// See https://aka.ms/new-console-template for more information
using BoardTable;
using Xadrez_Console;

Position p;
p = new Position(3, 4);

Board board = new Board(8, 8);
board.PutPiece("", new Position(0, 0));
board.PutPiece("", new Position(1, 3));
board.PutPiece("", new Position(2, 4));
Screen.PrintBoard(board);
Console.ReadLine();