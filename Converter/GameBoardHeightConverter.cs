//-----------------------------------------------------------------------
// <copyright file="GameBoardHeightConverter.cs" company="FH Wiener Neustadt">
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
    /// Represents the GameBoardHeightConverter class.
    /// </summary>
    public class GameBoardHeightConverter : IValueConverter
    {
        /// <summary>
        /// Converts a height value in a row size value.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The column letter list.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rowSize = 30;

            GameBoard gameBoard = (GameBoard)value;

            if (gameBoard.Row < 11 && gameBoard.Column < 11)
            {
                return gameBoard.Row * 80;
            }

            if (gameBoard.Row < 15 && gameBoard.Column < 15)
            {
                return gameBoard.Row * 60;
            }

            if (gameBoard.Row < 19 && gameBoard.Column < 19)
            {
                return gameBoard.Row * 40;
            }

            return gameBoard.Row * rowSize;
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