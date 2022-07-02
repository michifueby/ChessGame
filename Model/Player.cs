//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Model
{
    using System;

    [Serializable]

    /// <summary>
    /// Represents the Player enum.
    /// </summary>
    public enum Player
    {
        /// <summary>
        /// The enum for the first player.
        /// </summary>
        FirstPlayer,

        /// <summary>
        /// The enum for the second player.
        /// </summary>
        SecondPlayer
    }
}