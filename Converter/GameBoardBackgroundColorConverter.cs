//-----------------------------------------------------------------------
// <copyright file="GameBoardBackgroundColorConverter.cs" company="FH Wiener Neustadt">
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
    using System.Windows.Media;
    using Chess.Model;

    /// <summary>
    /// Represents the GameBoardBackgroundColorConverter class.
    /// </summary>
    public class GameBoardBackgroundColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts a column and row value in a background color.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The background color list.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameBoard gameBoard = (GameBoard)value;
            ObservableCollection<SolidColorBrush> backgroundColorBrushList = new ObservableCollection<SolidColorBrush>();

            for (int i = 0; i < gameBoard.Row; i++)
            {
                for (int j = 0; j < gameBoard.Column; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        backgroundColorBrushList.Add(Brushes.Gray);
                    }
                    else
                    {
                        backgroundColorBrushList.Add(Brushes.Black);
                    }
                }
            }

            return backgroundColorBrushList;
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