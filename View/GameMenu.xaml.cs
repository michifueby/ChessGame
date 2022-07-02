//-----------------------------------------------------------------------
// <copyright file="GameMenu.xaml.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.View
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows;
    using System.Windows.Controls;
    using Chess.ViewModel;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for GameMenu.
    /// </summary>
    public partial class GameMenu : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameMenu"/> class.
        /// </summary>
        public GameMenu()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The On Save Game Button click callback.
        /// </summary>
        /// <param name="sender">Specified the sender of the event.</param>
        /// <param name="e">Specified the routed event args.</param>
        private void OnSaveGameButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            GameStateVM currentGameState = (GameStateVM)DataContext;
            GameHistoryVM gameHistory = new GameHistoryVM();
            gameHistory.GameHistory = currentGameState.GameHistory;

            saveFileDialog.Filter = "Chess Game Files | *.chessFile";
            saveFileDialog.DefaultExt = ".chessFile";
            saveFileDialog.FileName = "GameState-" + DateTime.Now.ToShortDateString();

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        
                        formatter.Serialize(fileStream, gameHistory);
                        fileStream.Seek(0, SeekOrigin.Begin);
                        fileStream.Close();
                        
                        MessageBox.Show("The game state has been successfully saved!", "Chess Game", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error while saving the Game file!", "Chess Game", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// The On Load GameButton click callback.
        /// </summary>
        /// <param name="sender">Specified the sender of the event.</param>
        /// <param name="e">Specified the routed event args.</param>
        private void OnLoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Chess Game Files | *.chessFile";

            GameHistoryVM loadedGameState;
            
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (FileStream fileStream = File.OpenRead(openFileDialog.FileName))
                    {
                        IFormatter formatter = new BinaryFormatter();

                        loadedGameState = (GameHistoryVM)formatter.Deserialize(fileStream);

                        MessageBox.Show("The game state has been loaded successfully!", "Chess Game", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("The game state could not be loaded!", "Chess Game", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                GameStateVM gameState = (GameStateVM)DataContext;
                gameState.GameHistory = loadedGameState.GameHistory;
                this.DataContext = gameState;
            }
        }
    }
}
