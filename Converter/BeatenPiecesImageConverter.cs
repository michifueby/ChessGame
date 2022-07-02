//-----------------------------------------------------------------------
// <copyright file="BeatenPiecesImageConverter.cs" company="FH Wiener Neustadt">
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
    using Chess.Model.ChessPieces;

    /// <summary>
    /// Represents the BeatenPiecesImageConverter class.
    /// </summary>
    public class BeatenPiecesImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts beaten pieces in beaten pieces images.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The beaten pieces list.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ChessPiece> beatenPieces = (ObservableCollection<ChessPiece>)value;

            ObservableCollection<string> beatenPiecesList = new ObservableCollection<string>();
            string player = (string)parameter;

            if (player == "FirstPlayer")
            {
                for (int i = 0; i < beatenPieces.Count; i++)
                {
                    beatenPiecesList.Add($"Images/ChessPieces/{beatenPieces[i]}_White.png");
                }
            }
            else if (player == "SecondPlayer")
            {
                for (int i = 0; i < beatenPieces.Count; i++)
                {
                    beatenPiecesList.Add($"Images/ChessPieces/{beatenPieces[i]}_Black.png");
                }
            }

            return beatenPiecesList;
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