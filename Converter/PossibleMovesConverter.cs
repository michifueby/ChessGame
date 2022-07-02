//-----------------------------------------------------------------------
// <copyright file="PossibleMovesConverter.cs" company="FH Wiener Neustadt">
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
    /// Represents the PossibleMovesConverter class.
    /// </summary>
    public class PossibleMovesConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts the possible moves in a background color.
        /// </summary>
        /// <param name="values">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The color list of possible moves.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<SolidColorBrush> colorList = new ObservableCollection<SolidColorBrush>();
            ObservableCollection<Coordinates> possibleMoves = (ObservableCollection<Coordinates>)values[0];
            GameBoard gameBoard = (GameBoard)values[1];

            for (int i = 0; i < gameBoard.Row; i++)
            {
                for (int j = 0; j < gameBoard.Column; j++)
                {
                    for (int k = 0; k < possibleMoves.Count; k++)
                    {
                        if (possibleMoves[k].XCoordinate == i && possibleMoves[k].YCoordinate == j)
                        {
                            colorList.Add(Brushes.Green);
                            break;
                        }
                        else
                        {
                            if (k == possibleMoves.Count - 1)
                            {
                                colorList.Add(null);
                            }
                        }
                    }
                }
            }

            return colorList;
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