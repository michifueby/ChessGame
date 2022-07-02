//-----------------------------------------------------------------------
// <copyright file="IMoveable.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the IMoveCalculator interface.
    /// </summary>
    public interface IMoveable
    {
        /// <summary>
        /// Moves a piece.
        /// </summary>
        /// <param name="moveCalculator">Specified the MoveCalculator.</param>
        /// <param name="gameboard">Specified the GameBoard.</param>
        /// <param name="coordinates">Specified the Coordinates.</param>
        /// <returns>The possible moves.</returns>
        List<Coordinates> Move(MoveCalculator moveCalculator, GameBoard gameboard, Coordinates coordinates);
    }
}