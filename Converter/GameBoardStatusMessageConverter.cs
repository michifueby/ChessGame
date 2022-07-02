//-----------------------------------------------------------------------
// <copyright file="GameBoardStatusMessageConverter.cs" company="FH Wiener Neustadt">
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

    /// <summary>
    /// Represents the GameBoardStatusMessageConverter class.
    /// </summary>
    public class GameBoardStatusMessageConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts a boolean in a game board status message.
        /// </summary>
        /// <param name="values">Specified the objects as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The game board status message.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isblackPlayerWon = (bool)values[0];
            bool iswhitePlayerWon = (bool)values[1];

            if (iswhitePlayerWon && isblackPlayerWon)
            {
                return "Draw!";
            }

            if (iswhitePlayerWon)
            {
                return "White Player Won!";
            }

            if (isblackPlayerWon)
            {
                return "Black Player Won!";
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts a converted value back to the original value.
        /// </summary>
        /// <param name="value">Specified an object.</param>
        /// <param name="targetTypes">Specified the targetTypes.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>Returns a value object.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}