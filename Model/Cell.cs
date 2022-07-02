//-----------------------------------------------------------------------
// <copyright file="Cell.cs" company="FH Wiener Neustadt">
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
    /// Represents the Cell class.
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Represents the chess piece.
        /// </summary>
        private ChessPiece chessPiece;

        /// <summary>
        /// Represents if the Cell is occupied.
        /// </summary>
        private bool isCellOccupied;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="isCellOccupied">Sets the value of isOccupied.</param>
        /// <param name="chessPiece">Sets the value of piece.</param>
        public Cell(bool isCellOccupied, ChessPiece chessPiece)
        {
            this.isCellOccupied = isCellOccupied;
            
            this.chessPiece = chessPiece;
        }

        /// <summary>
        /// Gets or sets the value of chess piece.
        /// </summary>
        /// <value>The value of chess piece.</value>
        public ChessPiece ChessPiece
        {
            get
            {
                return this.chessPiece;
            }

            set
            {
                this.chessPiece = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the cell is active.
        /// </summary>
        /// <value>The value of isCellOccupied.</value>
        public bool IsCellOccupied
        {
            get
            {
                return this.isCellOccupied;
            }

            set
            {
                this.isCellOccupied = value;
            }
        }
    }
}