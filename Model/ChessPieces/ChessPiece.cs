//-----------------------------------------------------------------------
// <copyright file="ChessPiece.cs" company="FH Wiener Neustadt">
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
    /// Represents the Chess Piece class.
    /// </summary>
    public abstract class ChessPiece : IMoveable
    {
        /// <summary>
        /// Represents the player.
        /// </summary>
        private Player player;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPiece"/> class.
        /// </summary>
        /// <param name="player">Specified the player.</param>
        public ChessPiece(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Gets the value of the player.
        /// </summary>
        /// <value>The value of the player.</value>
        public Player Player
        {
            get
            {
                return this.player;
            }
        }

        /// <summary>
        /// Moves a chess piece.
        /// </summary>
        /// <param name="moveCalculator">Specified the MoveCalculator.</param>
        /// <param name="gameboard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the Coordinates.</param>
        /// <returns>The possible moves.</returns>
        public abstract List<Coordinates> Move(MoveCalculator moveCalculator, GameBoard gameboard, Coordinates coordinates);
    }
}
