//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess
{
    using System.Windows;
    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Represents the command arguments.
        /// </summary>
        private CommandLineArgumentsHandler commandLineArgumentsHandler;

        /// <summary>
        /// Represents the StatusMessage from command arguments.
        /// </summary>
        private string statusMessage;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.commandLineArgumentsHandler = new CommandLineArgumentsHandler();
            this.statusMessage = this.commandLineArgumentsHandler.Message;

            this.HandleStatusMessage();
        }

        /// <summary>
        /// Handle the status message from command arguments.
        /// </summary>
        private void HandleStatusMessage()
        {
            if (this.statusMessage == string.Empty)
            {
                return;
            }

            MessageBox.Show(this.statusMessage, "Chess Game", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
