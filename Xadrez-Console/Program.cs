// See https://aka.ms/new-console-template for more information
using BoardTable;
using Xadrez_Console;

Position p;
p = new Position(3, 4);

Board board = new Board(8, 8);
Screen.PrintBoard(board);
Console.ReadLine();