//-----------------------------------------------------------------------
// <copyright file="RowNumberConverter.cs" company="FH Wiener Neustadt">
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
    /// Represents the RowNumberConverter class.
    /// </summary>
    public class RowNumberConverter : IValueConverter
    {
        /// <summary>
        /// Converts a row value in a number description.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The row number list.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameBoard gameBoard = (GameBoard)value;
            ObservableCollection<string> rowNumberList = new ObservableCollection<string>();

            for (int i = gameBoard.Row; i > 0; i--)
            {
                if (i < 10)
                {
                    rowNumberList.Add($"0{i}");
                }
                else
                {
                    rowNumberList.Add($"{i}");
                }
            }

            return rowNumberList;
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