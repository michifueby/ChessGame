//-----------------------------------------------------------------------
// <copyright file="GameBoardConverter.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Represents the GameBoardConverter class.
    /// </summary>
    public class GameBoardConverter : IValueConverter
    {
        /// <summary>
        /// Converts the game board row and column in a coordinates.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The coordinates list.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameBoard gameBoard = (GameBoard)value;
            ObservableCollection<string> gameBoardCoordinatesList = new ObservableCollection<string>();

            for (int i = 0; i < gameBoard.Row; i++)
            {
                for (int j = 0; j < gameBoard.Column; j++)
                {
                    gameBoardCoordinatesList.Add($"{i} {j}");
                }
            }

            return gameBoardCoordinatesList;
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