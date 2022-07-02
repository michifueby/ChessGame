//-----------------------------------------------------------------------
// <copyright file="CommandLineArgumentsHandler.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Model
{
    using System;

    [Serializable]
    
    /// <summary>
    /// Represents the arguments handler class.
    /// </summary>
    public class CommandLineArgumentsHandler
    {
        /// <summary>
        /// Represents the command arguments.
        /// </summary>
        private string[] args;

        /// <summary>
        /// Represents the board size.
        /// </summary>
        private int[] size;

        /// <summary>
        /// Represents the status message of the command arguments.
        /// </summary>
        private string statusMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineArgumentsHandler"/> class.
        /// </summary>
        public CommandLineArgumentsHandler()
        {
            this.statusMessage = string.Empty;
            
            // Get Command Arguments
            this.args = Environment.GetCommandLineArgs();

            this.size = this.ProcessCommandLineArguments();
        }

        /// <summary>
        /// Gets the value of the GameBoard size.
        /// </summary>
        /// <value>The value of GameBoard size.</value>
        public int[] GameBoardSize
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        /// Gets the value of the status message.
        /// </summary>
        /// <value>The value of the status message.</value>
        public string Message
        {
            get
            {
                return this.statusMessage;
            }
        }

        /// <summary>
        /// Process the command arguments.
        /// </summary>
        /// <returns>The game size of the game board.</returns>
        private int[] ProcessCommandLineArguments()
        {
            int[] defaultSize = { 8, 8 };

            this.size = new int[2];

            if (this.args.Length <= 1)
            {
                return defaultSize;
            }
            else if (this.args.Length > 3 || this.args.Length < 3 || this.args[1] != "-size")
            {
                this.statusMessage = "Not valid command!\nEnter the size in the following format: -size WIDTHxHEIGHT\n\nThe field size was started with the default values ​​8x8";
                return defaultSize;
            }

            this.size = this.ParseCommandLineArguments(this.size, 8, 26, defaultSize);

            return this.size;
        }

        /// <summary>
        /// Parse the command arguments.
        /// </summary>
        /// <param name="size">Specified the game board size.</param>
        /// <param name="minimumSize">Specified the minimum size.</param>
        /// <param name="maximumSize">Specified the maximum size.</param>
        /// <param name="defaultSize">Specified the default size.</param>
        /// <returns>The game size of the game board.</returns>
        private int[] ParseCommandLineArguments(int[] size, int minimumSize, int maximumSize, int[] defaultSize)
        {
            string[] parsedArgs = new string[2];
            
            for (int i = 2; i < this.args.Length; i++)
            {
                parsedArgs = this.args[i].Split('x');
            }

            return this.GetNumberFromCommandLineArguments(size, parsedArgs, minimumSize, maximumSize, defaultSize);
        }

        /// <summary>
        /// Get the number from command arguments.
        /// </summary>
        /// <param name="size">Specified the game board size.</param>
        /// <param name="parsedArgs">Specified the parsed command arguments.</param>
        /// <param name="minimumSize">Specified the minimum size.</param>
        /// <param name="maximumSize">Specified the maximum size.</param>
        /// <param name="defaultSize">Specified the default size.</param>
        /// <returns>The game size of the game board.</returns>
        private int[] GetNumberFromCommandLineArguments(int[] size, string[] parsedArgs, int minimumSize, int maximumSize, int[] defaultSize)
        {
            for (int i = 0; i < parsedArgs.Length; i++)
            {
                bool isSizeValid = int.TryParse(parsedArgs[i], out int intSize);

                if (!isSizeValid)
                {
                    this.statusMessage = "Please only enter whole numbers for the field size!\n\nThe field size was started with the default values ​​8x8";
                    return defaultSize;
                }
                else if (intSize < minimumSize || intSize > maximumSize)
                {
                    this.statusMessage = $"Please only enter whole numbers between {minimumSize} and {maximumSize}\n\nThe field size was started with the default values ​​8x8!";
                    return defaultSize;
                }

                size[i] = intSize;
            }

            return size;
        }
    }
}
