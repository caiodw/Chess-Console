﻿// See https://aka.ms/new-console-template for more information
using BoardTable;
using Xadrez_Console;
using Chess;
using BoardTable.Enums;

//try
//{
//    Position p;
//    p = new Position(3, 4);
//    Board board = new Board(8, 8);
//    board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
//    board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
//    board.PutPiece(new King(board, Color.Black), new Position(2, 4));
//    Screen.PrintBoard(board);
//    Console.ReadLine();
//}
//catch (BoardException boardException)
//{
//	Console.WriteLine(boardException.Message);
//}
ChessPosition chessPosition = new ChessPosition('a', 1);
Console.WriteLine(chessPosition);
Console.WriteLine(chessPosition.toPosition());