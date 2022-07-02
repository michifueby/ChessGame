//-----------------------------------------------------------------------
// <copyright file="Coordinates.cs" company="FH Wiener Neustadt">
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
    /// Represents the Coordinates class.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Represents the x coordinate.
        /// </summary>
        private int xCoordinate;

        /// <summary>
        /// Represents the y coordinate.
        /// </summary>
        private int yCoordinate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.
        /// </summary>
        /// <param name="xCoordinate">Specified the x coordinate.</param>
        /// <param name="yCoordinate">Specified the y coordinate.</param>
        public Coordinates(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;

            this.yCoordinate = yCoordinate;
        }

        /// <summary>
        /// Gets the value of the x coordinate.
        /// </summary>
        /// <value>The value of the x coordinate.</value>
        public int XCoordinate
        {
            get
            {
                return this.xCoordinate;
            }
        }

        /// <summary>
        /// Gets the value of the y coordinate.
        /// </summary>
        /// <value>The value of the y coordinate.</value>
        public int YCoordinate
        {
            get
            {
                return this.yCoordinate;
            }
        }
    }
}