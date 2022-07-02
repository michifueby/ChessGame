//-----------------------------------------------------------------------
// <copyright file="GameBoard.cs" company="FH Wiener Neustadt">
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
    /// Represents the Game Board class.
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// Represents the cells.
        /// </summary>
        private Cell[,] cells;

        /// <summary>
        /// Represents the GameBoard Row.
        /// </summary>
        private int row;

        /// <summary>
        /// Represents the GameBoard Column.
        /// </summary>
        private int column;

        /// <summary>
        /// Represents the GameBoard name.
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the black beaten pieces.
        /// </summary>
        private List<ChessPiece> beatenBlackPieces;

        /// <summary>
        /// A list containing the chess pieces in the black graveyard.
        /// </summary>
        private List<ChessPiece> beatenWhitePieces;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard"/> class.
        /// </summary>
        /// <param name="width">Specified the width of the GameBoard.</param>
        /// <param name="height">Specified the height of the GameBoard.</param>
        /// <param name="boardName">Sets the name of the ChessBoard.</param>
        /// <param name="gameBoardCells">Specified the cells of the GameBoard.</param>
        public GameBoard(int width, int height, string boardName, Cell[,] gameBoardCells)
        {
            this.column = width;
            this.row = height;
            
            this.name = boardName;
            this.cells = gameBoardCells;

            this.beatenBlackPieces = new List<ChessPiece>();
            this.beatenWhitePieces = new List<ChessPiece>();
        }

        /// <summary>
        /// Gets the value of Cells.
        /// </summary>
        /// <value>The value of cells.</value>
        public Cell[,] Cells
        {
            get
            {
                return this.cells;
            }
        }

        /// <summary>
        /// Gets or sets the value of the GameBoard Row.
        /// </summary>
        /// <value>The value of GameBoard row.</value>
        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the GameBoard Column.
        /// </summary>
        /// <value>The value of GameBoard Column.</value>
        public int Column
        {
            get
            {
                return this.column;
            }

            set
            {
                this.column = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the GameBoard name.
        /// </summary>
        /// <value>The value of the GameBoard name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Name), "The specified value must not be null!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the beaten black pieces.
        /// </summary>
        /// <value>The value of the beaten black pieces.</value>
        public List<ChessPiece> BeatenBlackPieces
        {
            get
            {
                return this.beatenBlackPieces;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.BeatenBlackPieces), "The specified value must not be null!");
                }

                this.beatenBlackPieces = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the beaten white pieces.
        /// </summary>
        /// <value>The value of the beaten white pieces.</value>
        public List<ChessPiece> BeatenWhitePieces
        {
            get
            {
                return this.beatenWhitePieces;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.BeatenWhitePieces), "The specified value must not be null!");
                }

                this.beatenWhitePieces = value;
            }
        }
    }
}