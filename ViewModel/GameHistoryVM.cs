//-----------------------------------------------------------------------
// <copyright file="GameHistoryVM.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using Chess.Model;

    [Serializable]

    /// <summary>
    /// Represents the GameHistoryVM class.
    /// </summary>
    public class GameHistoryVM
    {
        /// <summary>
        /// An observable collection with the GameState.
        /// </summary>
        private ObservableCollection<GameBoard> gameHistory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameHistoryVM"/> class.
        /// </summary>
        public GameHistoryVM()
        {
            this.gameHistory = new ObservableCollection<GameBoard>();
        }

        /// <summary>
        /// Gets or sets the value of gameHistory.
        /// </summary>
        /// <value>The value of gameHistory.</value>
        public ObservableCollection<GameBoard> GameHistory
        {
            get
            {
                return this.gameHistory;
            }

            set
            {
                this.gameHistory = value;
            }
        }
    }
}