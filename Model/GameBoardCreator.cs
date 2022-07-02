//-----------------------------------------------------------------------
// <copyright file="GameBoardCreator.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Model
{
    using System;
    using Chess.Model.ChessPieces;

    [Serializable]

    /// <summary>
    /// Represents the GameBoardCreator class.
    /// </summary>
    public class GameBoardCreator
    {
        /// <summary>
        /// Creates a new GameBoard with width and height.
        /// </summary>
        /// <param name="width">Specified the Game board width.</param>
        /// <param name="height">Specified the Game board height.</param>
        /// <param name="gameBoardName">Specified the Game board name.</param>
        /// <returns>The new game board.</returns>
        public GameBoard Create(int width, int height, string gameBoardName)
        {
            Cell[,] cells = new Cell[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0 || j == 7)
                        {
                            cells[i, j] = new Cell(true, new Rook(Player.FirstPlayer));
                        }
                        else if (j == 1 || j == 6)
                        {
                            cells[i, j] = new Cell(true, new Knight(Player.FirstPlayer));
                        }
                        else if (j == 2 || j == 5)
                        {
                            cells[i, j] = new Cell(true, new Bishop(Player.FirstPlayer));
                        }
                        else if (j == 3)
                        {
                            cells[i, j] = new Cell(true, new Queen(Player.FirstPlayer));
                        }
                        else if (j == 4)
                        {
                            cells[i, j] = new Cell(true, new King(Player.FirstPlayer));
                        }
                        else
                        {
                            cells[i, j] = new Cell(false, null);
                        }
                    }
                    else if (i == 1)
                    {
                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                        {
                            cells[i, j] = new Cell(true, new Pawn(Player.FirstPlayer));
                        }
                        else
                        {
                            cells[i, j] = new Cell(false, null);
                        }
                    }
                    else if (i == height - 1)
                    {
                        if (j == 0 || j == 7)
                        {
                            cells[i, j] = new Cell(true, new Rook(Player.SecondPlayer));
                        }
                        else if (j == 1 || j == 6)
                        {
                            cells[i, j] = new Cell(true, new Knight(Player.SecondPlayer));
                        }
                        else if (j == 2 || j == 5)
                        {
                            cells[i, j] = new Cell(true, new Bishop(Player.SecondPlayer));
                        }
                        else if (j == 3)
                        {
                            cells[i, j] = new Cell(true, new Queen(Player.SecondPlayer));
                        }
                        else if (j == 4)
                        {
                            cells[i, j] = new Cell(true, new King(Player.SecondPlayer));
                        }
                        else
                        {
                            cells[i, j] = new Cell(false, null);
                        }
                    }
                    else if (i == height - 2)
                    {
                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                        {
                            cells[i, j] = new Cell(true, new Pawn(Player.SecondPlayer));
                        }
                        else
                        {
                            cells[i, j] = new Cell(false, null);
                        }
                    }
                    else
                    {
                        cells[i, j] = new Cell(false, null);
                    }
                }
            }

            GameBoard newGameBoard = new GameBoard(width, height, gameBoardName, cells);
            return newGameBoard;
        }
    }
}