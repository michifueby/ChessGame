//-----------------------------------------------------------------------
// <copyright file="GamePieceImageConverter.cs" company="FH Wiener Neustadt">
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
    /// Represents the GamePieceImageConverter class.
    /// </summary>
    public class GamePieceImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts a game board in a game piece image list.
        /// </summary>
        /// <param name="value">Specified an object as a value.</param>
        /// <param name="targetType">Specified a targetType.</param>
        /// <param name="parameter">Specified a parameter.</param>
        /// <param name="culture">Specified a culture.</param>
        /// <returns>The game piece image list.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<string> gamePieceImagesList = new ObservableCollection<string>();

            GameBoard gameBoard = (GameBoard)value;

            for (int i = 0; i < gameBoard.Row; i++)
            {
                for (int j = 0; j < gameBoard.Column; j++)
                {
                    if (gameBoard.Cells[i, j].IsCellOccupied)
                    {
                        if (gameBoard.Cells[i, j].ChessPiece.Player == Player.FirstPlayer)
                        {
                            gamePieceImagesList.Add($"Images/ChessPieces/{gameBoard.Cells[i, j].ChessPiece}_Black.png");
                        }
                        else if (gameBoard.Cells[i, j].ChessPiece.Player == Player.SecondPlayer)
                        {
                            gamePieceImagesList.Add($"Images/ChessPieces/{gameBoard.Cells[i, j].ChessPiece}_White.png");
                        }
                    }
                    else
                    {
                        gamePieceImagesList.Add(null);
                    }
                }
            }

            return gamePieceImagesList;
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