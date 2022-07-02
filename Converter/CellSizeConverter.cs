//-----------------------------------------------------------------------
// <copyright file="CellSizeConverter.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Represents the CellSizeConverter class.
    /// </summary>
    public class CellSizeConverter : IValueConverter
    {
        /// <summary>
        /// Converts a height and width value in a row and column value for the grid.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The cell size value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameBoard gameBoard = (GameBoard)value;

            if (gameBoard.Row < 11 && gameBoard.Column < 11)
            {
                return 80;
            }

            if (gameBoard.Row < 15 && gameBoard.Column < 15)
            {
                return 60;
            }

            if (gameBoard.Row < 19 && gameBoard.Column < 19)
            {
                return 40;
            }

            return 30;
        }

        /// <summary>
        /// Converts a converted value back to the original value.
        /// </summary>
        /// <param name="value">Specified an object.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>Returns a value object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}