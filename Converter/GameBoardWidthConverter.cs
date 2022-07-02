//-----------------------------------------------------------------------
// <copyright file="GameBoardWidthConverter.cs" company="FH Wiener Neustadt">
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
    /// Represents the GameBoardWidthConverter class.
    /// </summary>
    public class GameBoardWidthConverter : IValueConverter
    {
        /// <summary>
        /// Converts width value in a column size value.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The column size value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int columnSize = 30;

            GameBoard gameBoard = (GameBoard)value;

            if (gameBoard.Row < 11 && gameBoard.Column < 11)
            {
                columnSize = 80;
                return gameBoard.Column * columnSize;
            }

            if (gameBoard.Row < 15 && gameBoard.Column < 15)
            {
                columnSize = 60;
                return gameBoard.Column * columnSize;
            }

            if (gameBoard.Row < 19 && gameBoard.Column < 19)
            {
                columnSize = 40;
                return gameBoard.Column * columnSize;
            }

            return gameBoard.Column * columnSize;
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