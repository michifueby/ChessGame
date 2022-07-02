//-----------------------------------------------------------------------
// <copyright file="MoveCalculator.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    using Chess.Model.ChessPieces;

    [Serializable]

    /// <summary>
    /// Represents the MoveCalculator class.
    /// </summary>
    public class MoveCalculator
    {
        /// <summary>
        /// Calculate the possible moves from bishop.
        /// </summary>
        /// <param name="bishop">Specified the bishop piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <returns>The possible coordinates.</returns>
        public List<Coordinates> CalculatePossibleMoves(Bishop bishop, GameBoard gameBoard, Coordinates coordinates)
        {
            List<Coordinates> possibleMoves = new List<Coordinates>();

            this.CalculateDiagonalMoves(possibleMoves, bishop, gameBoard, coordinates);

            return possibleMoves;
        }

        /// <summary>
        /// Calculate the possible moves from knight.
        /// </summary>
        /// <param name="knight">Specified the knight piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <returns>The possible coordinates.</returns>
        public List<Coordinates> CalculatePossibleMoves(Knight knight, GameBoard gameBoard, Coordinates coordinates)
        {
            List<Coordinates> possibleMoves = new List<Coordinates>();

            this.CalculateUpMovesKnight(knight, gameBoard, coordinates, possibleMoves);
            this.CalculateDownMovesKnight(knight, gameBoard, coordinates, possibleMoves);
            this.CalculateRightMovesKnight(knight, gameBoard, coordinates, possibleMoves);
            this.CalculateLeftMovesKnight(knight, gameBoard, coordinates, possibleMoves);

            return possibleMoves;
        }

        /// <summary>
        /// Calculate the possible moves from king.
        /// </summary>
        /// <param name="king">Specified the king piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <returns>The possible coordinates.</returns>
        public List<Coordinates> CalculatePossibleMoves(King king, GameBoard gameBoard, Coordinates coordinates)
        {
            List<Coordinates> possibleMoves = new List<Coordinates>();

            this.CalculateUpMovesKing(king, gameBoard, possibleMoves, coordinates);
            this.CalculateDownMovesKing(king, gameBoard, coordinates, possibleMoves);
            this.CalculateSideMovesKing(king, gameBoard, coordinates, possibleMoves);

            return possibleMoves;
        }

        /// <summary>
        /// Calculate the possible moves from pawn.
        /// </summary>
        /// <param name="pawn">Specified the pawn piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <returns>The possible coordinates.</returns>
        public List<Coordinates> CalculatePossibleMoves(Pawn pawn, GameBoard gameBoard, Coordinates coordinates)
        {
            List<Coordinates> possibleMoves = new List<Coordinates>();

            if (pawn.Player == Player.FirstPlayer)
            {
                if (coordinates.XCoordinate < gameBoard.Row - 1)
                {
                    if (!gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate].IsCellOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate));
                    }
                }

                this.CalculateDownAttackMovesPawn(pawn, gameBoard, possibleMoves, coordinates);
            }
            else if (pawn.Player == Player.SecondPlayer)
            {
                if (coordinates.XCoordinate > 0 && !gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate].IsCellOccupied)
                {
                    possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate));
                }

                this.CalculateUpAttackMovesPawn(pawn, gameBoard, coordinates, possibleMoves);
            }

            return possibleMoves;
        }

        /// <summary>
        /// Calculate the possible moves from queen.
        /// </summary>
        /// <param name="queen">Specified the queen piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <returns>The possible coordinates.</returns>
        public List<Coordinates> CalculatePossibleMoves(Queen queen, GameBoard gameBoard, Coordinates coordinates)
        {
            List<Coordinates> possibleMoves = new List<Coordinates>();

            this.CalculateVerticalMoves(possibleMoves, queen, gameBoard, coordinates);
            this.CalculateHorizontalMoves(possibleMoves, queen, gameBoard, coordinates);
            this.CalculateDiagonalMoves(possibleMoves, queen, gameBoard, coordinates);

            return possibleMoves;
        }

        /// <summary>
        /// Calculate the possible moves from rook.
        /// </summary>
        /// <param name="rook">Specified the rook piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <returns>The possible coordinates.</returns>
        public List<Coordinates> CalculatePossibleMoves(Rook rook, GameBoard gameBoard, Coordinates coordinates)
        {
            List<Coordinates> possibleMoves = new List<Coordinates>();

            this.CalculateVerticalMoves(possibleMoves, rook, gameBoard, coordinates);
            this.CalculateHorizontalMoves(possibleMoves, rook, gameBoard, coordinates);

            return possibleMoves;
        }

        /// <summary>
        /// Calculate the diagonal moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        private void CalculateDiagonalMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            this.CalculateDiagonalDownLeft(possibleMoves, chessPiece, gameBoard, coordinates);
            this.CalculateDiagonalDownRight(possibleMoves, chessPiece, gameBoard, coordinates);
            this.CalculateDiagonalUpRight(possibleMoves, chessPiece, gameBoard, coordinates);
            this.CalculateDiagonalUpLeft(possibleMoves, chessPiece, gameBoard, coordinates);
        }

        /// <summary>
        /// Calculate the diagonal up left moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        private void CalculateDiagonalUpLeft(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate > 0 && coordinates.YCoordinate > 0)
            {
                for (int i = 1; i < gameBoard.Row; i++)
                {
                    if (coordinates.XCoordinate - i == -1 || coordinates.YCoordinate - i == -1)
                    {
                        break;
                    }

                    if (!gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate - i].IsCellOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - i, coordinates.YCoordinate - i));
                    }
                    else
                    {
                        if (chessPiece.Player != gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate - i].ChessPiece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate - i, coordinates.YCoordinate - i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the diagonal up right moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        private void CalculateDiagonalUpRight(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate > 0)
            {
                for (int i = 1; i < gameBoard.Row; i++)
                {
                    if (coordinates.XCoordinate - i == -1 || coordinates.YCoordinate + i == gameBoard.Column)
                    {
                        break;
                    }

                    if (!gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate + i].IsCellOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - i, coordinates.YCoordinate + i));
                    }
                    else
                    {
                        if (chessPiece.Player != gameBoard.Cells[coordinates.XCoordinate - i, coordinates.YCoordinate + i].ChessPiece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate - i, coordinates.YCoordinate + i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the diagonal down right moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        private void CalculateDiagonalDownRight(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate < gameBoard.Row - 1 && coordinates.YCoordinate < gameBoard.Column - 1)
            {
                for (int i = 1; i < gameBoard.Row; i++)
                {
                    if (coordinates.XCoordinate + i == gameBoard.Row || coordinates.YCoordinate + i == gameBoard.Column)
                    {
                        break;
                    }

                    if (!gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].IsCellOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + i, coordinates.YCoordinate + i));
                    }
                    else
                    {
                        if (chessPiece.Player != gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate + i].ChessPiece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate + i, coordinates.YCoordinate + i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the diagonal down left moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        private void CalculateDiagonalDownLeft(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate < gameBoard.Row - 1 && coordinates.YCoordinate > 0)
            {
                for (int i = 1; i < gameBoard.Row; i++)
                {
                    if (coordinates.XCoordinate + i == gameBoard.Row || coordinates.YCoordinate - i == -1)
                    {
                        break;
                    }

                    if (!gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].IsCellOccupied)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + i, coordinates.YCoordinate - i));
                    }
                    else
                    {
                        if (chessPiece.Player != gameBoard.Cells[coordinates.XCoordinate + i, coordinates.YCoordinate - i].ChessPiece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate + i, coordinates.YCoordinate - i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the up attacks moves from pawn.
        /// </summary>
        /// <param name="pawn">Specified the pawn piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        private void CalculateUpAttackMovesPawn(Pawn pawn, GameBoard gameBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.XCoordinate > 0 && coordinates.YCoordinate < gameBoard.Column - 1)
            {
                if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 1].IsCellOccupied)
                {
                    if (pawn.Player != gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 1].ChessPiece.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate + 1));
                    }
                }
            }

            if (coordinates.XCoordinate > 0 && coordinates.YCoordinate > 0)
            {
                if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 1].IsCellOccupied)
                {
                    if (pawn.Player != gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 1].ChessPiece.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the down attack moves from pawn.
        /// </summary>
        /// <param name="pawn">Specified the pawn piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        private void CalculateDownAttackMovesPawn(Pawn pawn, GameBoard gameBoard, List<Coordinates> possibleMoves, Coordinates coordinates)
        {
            if (coordinates.XCoordinate > 0 && coordinates.YCoordinate < gameBoard.Column - 1)
            {
                if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 1].IsCellOccupied)
                {
                    if (pawn.Player != gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 1].ChessPiece.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate + 1));
                    }
                }
            }

            if (coordinates.XCoordinate > 0 && coordinates.YCoordinate > 0)
            {
                if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 1].IsCellOccupied)
                {
                    if (pawn.Player != gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 1].ChessPiece.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the up moves from king.
        /// </summary>
        /// <param name="king">Specified the king piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="possibleMoves">Specified the possible moves of the king.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        private void CalculateUpMovesKing(King king, GameBoard gameBoard, List<Coordinates> possibleMoves, Coordinates coordinates)
        {
            if (coordinates.XCoordinate > 0)
            {
                if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate].IsCellOccupied)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate].ChessPiece.Player != king.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate));
                    }
                }
                else
                {
                    possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate));
                }

                if (coordinates.YCoordinate - 1 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 1].ChessPiece.Player != king.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate - 1));
                    }
                }

                if (coordinates.YCoordinate + 1 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 1].ChessPiece.Player != king.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate + 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the side moves from king.
        /// </summary>
        /// <param name="king">Specified the king piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        private void CalculateSideMovesKing(King king, GameBoard gameBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.YCoordinate < gameBoard.Column - 1)
            {
                if (gameBoard.Cells[coordinates.XCoordinate, coordinates.YCoordinate + 1].IsCellOccupied)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate, coordinates.YCoordinate + 1].ChessPiece.Player != king.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate + 1));
                    }
                }
                else
                {
                    possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate + 1));
                }
            }

            if (coordinates.YCoordinate - 1 >= 0)
            {
                if (gameBoard.Cells[coordinates.XCoordinate, coordinates.YCoordinate - 1].IsCellOccupied && (gameBoard.Cells[coordinates.XCoordinate, coordinates.YCoordinate - 1].ChessPiece.Player != king.Player))
                {
                    possibleMoves.Add(new Coordinates(coordinates.XCoordinate, coordinates.YCoordinate - 1));
                }
                else
                {
                    possibleMoves.Add(new Coordinates(coordinates.XCoordinate, coordinates.YCoordinate - 1));
                }
            }
        }

        /// <summary>
        /// Calculate the down moves from king.
        /// </summary>
        /// <param name="king">Specified the king piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates of the GameBoard.</param>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        private void CalculateDownMovesKing(King king, GameBoard gameBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.XCoordinate < gameBoard.Row - 1)
            {
                if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate].IsCellOccupied)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate].ChessPiece.Player != king.Player)
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate));
                    }
                }
                else
                {
                    possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate));
                }

                if (coordinates.YCoordinate - 1 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate - 1].IsCellOccupied && (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate - 1].ChessPiece.Player != king.Player))
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate - 1));
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate - 1));
                    }
                }

                if (coordinates.YCoordinate + 1 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate + 1].IsCellOccupied && (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate + 1].ChessPiece.Player != king.Player))
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate + 1));
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate + 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the horizontal moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        private void CalculateHorizontalMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            this.CalculateHorizontalLeftMoves(possibleMoves, chessPiece, gameBoard, coordinates);
            this.CalculateHorizontalRightMoves(possibleMoves, chessPiece, gameBoard, coordinates);
        }

        /// <summary>
        /// Calculate the vertical moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the Game Board.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        private void CalculateVerticalMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            this.CalculateVerticalDownMoves(possibleMoves, chessPiece, gameBoard, coordinates);
            this.CalculateVerticalUpMoves(possibleMoves, chessPiece, gameBoard, coordinates);
        }

        /// <summary>
        /// Calculate the vertical up moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        private void CalculateVerticalUpMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate > 0)
            {
                for (int i = coordinates.XCoordinate; i >= 0; i--)
                {
                    if (gameBoard.Cells[i, coordinates.YCoordinate].IsCellOccupied)
                    {
                        if (chessPiece.Player != gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.Player)
                        {
                            possibleMoves.Add(new Coordinates(i, coordinates.YCoordinate));
                            break;
                        }
                        else
                        {
                            if (i != coordinates.XCoordinate)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(i, coordinates.YCoordinate));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the vertical down moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        private void CalculateVerticalDownMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.XCoordinate < gameBoard.Row - 1)
            {
                for (int i = coordinates.XCoordinate + 1; i < gameBoard.Row; i++)
                {
                    if (gameBoard.Cells[i, coordinates.YCoordinate].IsCellOccupied)
                    {
                        if (chessPiece.Player != gameBoard.Cells[i, coordinates.YCoordinate].ChessPiece.Player)
                        {
                            possibleMoves.Add(new Coordinates(i, coordinates.YCoordinate));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(i, coordinates.YCoordinate));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the horizontal left moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        private void CalculateHorizontalLeftMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.YCoordinate > 0)
            {
                for (int i = coordinates.YCoordinate; i >= 0; i--)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate, i].IsCellOccupied)
                    {
                        if (chessPiece.Player != gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate, i));
                            break;
                        }
                        else
                        {
                            if (coordinates.YCoordinate != i)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate, i));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the horizontal right moves.
        /// </summary>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        /// <param name="chessPiece">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        private void CalculateHorizontalRightMoves(List<Coordinates> possibleMoves, ChessPiece chessPiece, GameBoard gameBoard, Coordinates coordinates)
        {
            if (coordinates.YCoordinate < gameBoard.Column - 1)
            {
                for (int i = coordinates.YCoordinate; i < gameBoard.Column; i++)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate, i].IsCellOccupied)
                    {
                        if (chessPiece.Player != gameBoard.Cells[coordinates.XCoordinate, i].ChessPiece.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate, i));
                            break;
                        }
                        else
                        {
                            if (coordinates.YCoordinate != i)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate, i));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the left moves of knight.
        /// </summary>
        /// <param name="knight">Specified the knight piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        private void CalculateLeftMovesKnight(Knight knight, GameBoard gameBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.XCoordinate + 1 < gameBoard.Row)
            {
                if (coordinates.YCoordinate - 2 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate - 2].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate - 2].ChessPiece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate - 2));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate - 2));
                    }
                }
            }

            if (coordinates.XCoordinate + 1 < gameBoard.Row)
            {
                if (coordinates.YCoordinate + 2 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate + 2].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate + 1, coordinates.YCoordinate + 2].ChessPiece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate + 2));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 1, coordinates.YCoordinate + 2));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the right moves of knight.
        /// </summary>
        /// <param name="knight">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        private void CalculateRightMovesKnight(Knight knight, GameBoard gameBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.XCoordinate - 1 >= 0)
            {
                if (coordinates.YCoordinate + 2 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 2].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate + 2].ChessPiece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate + 2));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate + 2));
                    }
                }
            }

            if (coordinates.XCoordinate - 1 >= 0)
            {
                if (coordinates.YCoordinate - 2 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 2].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 1, coordinates.YCoordinate - 2].ChessPiece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate - 2));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 1, coordinates.YCoordinate - 2));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the up moves of knight.
        /// </summary>
        /// <param name="knight">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        private void CalculateUpMovesKnight(Knight knight, GameBoard gameBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.XCoordinate - 2 >= 0)
            {
                if (coordinates.YCoordinate + 1 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate + 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate + 1].ChessPiece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 2, coordinates.YCoordinate + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 2, coordinates.YCoordinate + 1));
                    }
                }
            }

            if (coordinates.XCoordinate - 2 >= 0)
            {
                if (coordinates.YCoordinate - 1 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate - 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate - 2, coordinates.YCoordinate - 1].ChessPiece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 2, coordinates.YCoordinate - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate - 2, coordinates.YCoordinate - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the down moves of knight.
        /// </summary>
        /// <param name="knight">Specified the chess piece.</param>
        /// <param name="gameBoard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the coordinates.</param>
        /// <param name="possibleMoves">Specified the possible moves.</param>
        private void CalculateDownMovesKnight(Knight knight, GameBoard gameBoard, Coordinates coordinates, List<Coordinates> possibleMoves)
        {
            if (coordinates.XCoordinate + 2 < gameBoard.Row)
            {
                if (coordinates.YCoordinate - 1 >= 0)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate - 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate - 1].ChessPiece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 2, coordinates.YCoordinate - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 2, coordinates.YCoordinate - 1));
                    }
                }
            }

            if (coordinates.XCoordinate + 2 < gameBoard.Row)
            {
                if (coordinates.YCoordinate + 1 < gameBoard.Column)
                {
                    if (gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate + 1].IsCellOccupied)
                    {
                        if (gameBoard.Cells[coordinates.XCoordinate + 2, coordinates.YCoordinate + 1].ChessPiece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 2, coordinates.YCoordinate + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Coordinates(coordinates.XCoordinate + 2, coordinates.YCoordinate + 1));
                    }
                }
            }
        }
    }
}