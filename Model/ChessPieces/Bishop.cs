﻿//-----------------------------------------------------------------------
// <copyright file="Bishop.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Model.ChessPieces
{
    using System;
    using System.Collections.Generic;

    [Serializable]

    /// <summary>
    /// Represents the Bishop class.
    /// </summary>
    public class Bishop : ChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bishop"/> class.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        public Bishop(Player player) : base(player)
        {
        }

        /// <summary>
        /// Moves the Bishop piece.
        /// </summary>
        /// <param name="moveCalculator">Specified the MoveCalculator.</param>
        /// <param name="gameboard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the Coordinates.</param>
        /// <returns>The possible moves.</returns>
        public override List<Coordinates> Move(MoveCalculator moveCalculator, GameBoard gameboard, Coordinates coordinates)
        {
            return moveCalculator.CalculatePossibleMoves(this, gameboard, coordinates);
        }

        /// <summary>
        /// Returns a string that describe the current object.
        /// </summary>
        /// <returns>The string that represents the Bishop piece.</returns>
        public override string ToString()
        {
            return "L";
        }
    }
}
