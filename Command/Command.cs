//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="FH Wiener Neustadt">
//     Copyright (c) FH Wiener Neustadt. All rights reserved.
// </copyright>
// <author>Michael Füby</author>
// <summary>Chess</summary>
//-----------------------------------------------------------------------

namespace Chess.Command
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Represents the Command class.
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// Represents the action.
        /// </summary>
        private Action<object> action;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="action">Specified an action.</param>
        public Command(Action<object> action)
        {
            this.action = action;
        }

        /// <summary>
        /// The CanExecuteChanged Event.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Checks if a command can be executed.
        /// </summary>
        /// <param name="parameter">Specified a parameter object.</param>
        /// <returns>Returns a boolean value.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Specified a parameter object.</param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}
