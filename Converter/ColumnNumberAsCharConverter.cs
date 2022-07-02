//-----------------------------------------------------------------------
// <copyright file="ColumnNumberAsCharConverter.cs" company="FH Wiener Neustadt">
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
    /// Represents the ColumnNumberAsCharConverter class.
    /// </summary>
    public class ColumnNumberAsCharConverter : IValueConverter
    {
        /// <summary>
        /// Converts a column value in a letter.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The column letter list.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameBoard gameBoard = (GameBoard)value;
            ObservableCollection<char> columnCharList = new ObservableCollection<char>();

            for (char columnDescription = 'A'; columnDescription <= 'Z'; columnDescription++)
            {
                if (columnCharList.Count == gameBoard.Column)
                {
                    break;
                }

                columnCharList.Add(columnDescription);
            }

            return columnCharList;
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