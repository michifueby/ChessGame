//-----------------------------------------------------------------------
// <copyright file="GameWinnerCalculator.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess
{
    using Chess.Model;

    /// <summary>
    /// Represents the GameWinnerCalculator class.
    /// </summary>
    public class GameWinnerCalculator
    { 
        /// <summary>
        /// Represents if king is in check.
        /// </summary>
        private bool isKingInCheck;

        /// <summary>
        /// Calculate if the king in check.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <returns>The value indicating is king in check.</returns>
        public bool CalculateIsKingInCheck(Player player, GameBoard gameBoard)
        {
            for (int i = 0; i < gameBoard.Row; i++)
            {
                for (int j = 0; j < gameBoard.Column; j++)
                {
                    if (gameBoard.Cells[i, j].IsCellOccupied)
                    {
                        if (gameBoard.Cells[i, j].ChessPiece.ToString() == "K" && (gameBoard.Cells[i, j].ChessPiece.Player == player))
                        {
                            Coordinates coordinates = new Coordinates(i, j);
                            this.isKingInCheck = this.CheckIsKingInCheck(player, gameBoard, coordinates);
                            return this.isKingInCheck;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check if king is in check.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king in check.</returns>
        private bool CheckIsKingInCheck(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            this.isKingInCheck = this.CheckHorizontalLeftCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckHorizontalRightCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckVerticalUpCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckVerticalDownCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckDiagonalCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckCellsKnight(player, gameBoard, coordinates);

            return this.isKingInCheck;
        }

        /// <summary>
        /// Check the cells of knight piece.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king in check.</returns>
        private bool CheckCellsKnight(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            this.isKingInCheck = this.CheckLeftCellsKnight(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckRightCellsKnight(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckUpCellsKnight(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckDownCellsKnight(player, gameBoard, coordinates);

            return this.isKingInCheck;
        }

        /// <summary>
        /// Check the up cells of knight.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckUpCellsKnight(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate - 2 >= 0)
            {
                if (coordinates.YCoordinate + 1 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate + 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate + 1].ChessPiece.Player != player && gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate + 1].ChessPiece.ToString() == "S")
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.XCoordinate - 2 >= 0)
            {
                if (coordinates.YCoordinate - 1 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate - 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate - 1].ChessPiece.Player != player && gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate - 1].ChessPiece.ToString() == "S")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the right cells of knight.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckRightCellsKnight(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate - 1 >= 0)
            {
                if (coordinates.YCoordinate + 2 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 2].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 2].ChessPiece.Player != player && gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 2].ChessPiece.ToString() == "S")
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.XCoordinate - 1 >= 0)
            {
                if (coordinates.YCoordinate - 2 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 2].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 2].ChessPiece.Player != player && gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 2].ChessPiece.ToString() == "S")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the left cells of knight.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckLeftCellsKnight(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate + 1 < gameBoard.Row)
            {
                if (coordinates.YCoordinate + 2 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate + 2].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate + 2].ChessPiece.Player != player && gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate + 2].ChessPiece.ToString() == "S")
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.XCoordinate + 1 < gameBoard.Row)
            {
                if (coordinates.YCoordinate - 2 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate - 2].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate - 2].ChessPiece.Player != player && gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate - 2].ChessPiece.ToString() == "S")
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the down cells of knight.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckDownCellsKnight(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate + 2 < gameBoard.Row)
            {
                if (coordinates.YCoordinate + 1 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate + 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate + 1].ChessPiece.Player != player && gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate + 1].ChessPiece.ToString() == "S")
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.XCoordinate + 2 < gameBoard.Row)
            {
                if (coordinates.YCoordinate - 1 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate - 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate - 1].ChessPiece.Player != player)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the diagonal cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckDiagonalCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            this.isKingInCheck = this.CheckDiagonalUpLeftCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckDiagonalUpRightCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckDiagonalDownRightCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            this.isKingInCheck = this.CheckDiagonalDownLeftCells(player, gameBoard, coordinates);

            if (this.isKingInCheck)
            {
                return this.isKingInCheck;
            }

            return false;
        }

        /// <summary>
        /// Check the diagonal down left cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckDiagonalDownLeftCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate < gameBoard.Row - 1 && coordinates.YCoordinate > 0)
            {
                for (int i = 1; i < gameBoard.Row; i++)
                {
                    if (coordinates.XCoordinate + i == gameBoard.Row || coordinates.YCoordinate - i == -1)
                    {
                        return false;
                    }

                    if (gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].IsCellOccupied)
                    {
                        if (player != gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].ChessPiece.Player)
                        {
                            if (player != gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].ChessPiece.Player)
                            {
                                if (player == Player.FirstPlayer && (gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].ChessPiece.ToString() == "B") && i == 1)
                                {
                                    return true;
                                }

                                if (gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].ChessPiece.ToString() == "K" && i == 1)
                                {
                                    return true;
                                }

                                if (gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].ChessPiece.ToString() == "D" || gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].ChessPiece.ToString() == "L")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the diagonal down right cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckDiagonalDownRightCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate < gameBoard.Row - 1 && coordinates.YCoordinate < gameBoard.Column - 1)
            {
                for (int i = 1; i < gameBoard.Row; i++)
                {
                    if (coordinates.XCoordinate + i == gameBoard.Row || coordinates.YCoordinate + i == gameBoard.Column)
                    {
                        return false;
                    }

                    if (gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].IsCellOccupied)
                    {
                        if (player != gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].ChessPiece.Player)
                        {
                            if (player != gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].ChessPiece.Player)
                            {
                                if (player == Player.FirstPlayer && (gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].ChessPiece.ToString() == "B") && i == 1)
                                {
                                    return true;
                                }

                                if (gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].ChessPiece.ToString() == "K" && i == 1)
                                {
                                    return true;
                                }

                                if (gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].ChessPiece.ToString() == "D" || gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].ChessPiece.ToString() == "L")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the diagonal up right cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckDiagonalUpRightCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate > 0)
            {
                for (int i = 1; i < gameBoard.Row; i++)
                {
                    if (coordinates.XCoordinate - i == -1 || coordinates.YCoordinate + i == gameBoard.Column)
                    {
                        break;
                    }

                    if (gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate + i].IsCellOccupied)
                    {
                        if (player != gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate + i].ChessPiece.Player)
                        {
                            if (player == Player.SecondPlayer && (gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate + i].ChessPiece.ToString() == "B") && i == 1)
                            {
                                return true;
                            }

                            if (gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate + i].ChessPiece.ToString() == "K" && i == 1)
                            {
                                return true;
                            }

                            if (gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate + i].ChessPiece.ToString() == "D" || gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate + i].ChessPiece.ToString() == "L")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the diagonal up left cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckDiagonalUpLeftCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate > 0 && coordinates.YCoordinate > 0)
            {
                for (int i = 1; i < gameBoard.Row; i++)
                {
                    if (coordinates.XCoordinate - i == -1 || coordinates.YCoordinate - i == -1)
                    {
                        return false;
                    }

                    if (gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate - i].IsCellOccupied)
                    {
                        if (player != gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate - i].ChessPiece.Player)
                        {
                            if (player == Player.SecondPlayer && (gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate - i].ChessPiece.ToString() == "B") && i == 1)
                            {
                                return true;
                            }

                            if (gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate - i].ChessPiece.ToString() == "K" && i == 1)
                            {
                                return true;
                            }

                            if (gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate - i].ChessPiece.ToString() == "D" || gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate - i].ChessPiece.ToString() == "S")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the vertical down cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckVerticalDownCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate < gameBoard.Row - 1)
            {
                for (int i = coordinates.XCoordinate + 1; i < gameBoard.Row; i++)
                {
                    if (gameBoard.Cells[i, coordinates.YCoordinate].IsCellOccupied)
                    {
                        if (player != gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.Player)
                        {
                            if (gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.ToString() == "K" && i == coordinates.XCoordinate + 1)
                            {
                                return true;
                            }

                            if (gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.ToString() == "D" || gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.ToString() == "T")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i != coordinates.XCoordinate)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the vertical up cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckVerticalUpCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate > 0)
            {
                for (int i = coordinates.XCoordinate; i >= 0; i--)
                {
                    if (gameBoard.Cells[i, coordinates.YCoordinate].IsCellOccupied)
                    {
                        if (player != gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.Player)
                        {
                            if (gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.ToString() == "K" && i == coordinates.XCoordinate - 1)
                            {
                                return true;
                            }

                            if (gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.ToString() == "D" || gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.ToString() == "T")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i != coordinates.XCoordinate)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the horizontal right cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckHorizontalRightCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.YCoordinate < gameBoard.Column - 1)
            {
                for (int i = coordinates.YCoordinate; i < gameBoard.Column; i++)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate, i].IsCellOccupied)
                    {
                        if (player != gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.Player)
                        {
                            if (gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.ToString() == "K" && i == coordinates.YCoordinate + 1)
                            {
                                return true;
                            }

                            if (gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.ToString() == "D" || gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.ToString() == "T")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (coordinates.YCoordinate != i)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check the horizontal left cells.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        /// <param name="gameBoard">Specified the game board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <returns>The value indicating if king is in check.</returns>
        private bool CheckHorizontalLeftCells(Player player, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.YCoordinate > 0)
            {
                for (int i = coordinates.YCoordinate; i >= 0; i--)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate, i].IsCellOccupied)
                    {
                        if (player != gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.Player)
                        {
                            if (gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.ToString() == "K" && i == coordinates.YCoordinate - 1)
                            {
                                return true;
                            }

                            if (gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.ToString() == "D" || gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.ToString() == "T")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (coordinates.YCoordinate != i)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}