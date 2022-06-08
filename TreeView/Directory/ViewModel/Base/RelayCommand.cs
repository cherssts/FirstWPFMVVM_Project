

using System;
using System.Windows.Input;

namespace TreeView
{
    /// <summary>
    /// A basic Command that runs an Action
    /// </summary>
    public class RelayCommand : ICommand
    {

        #region Private Members

        /// <summary>
        /// The action to run
        /// </summary>
        private Action mAction;

        #endregion



        #region Public event
        /// <summary>
        /// The event that fired when the <see cref="CanExecute(object?)"/> value has changed
        /// </summary>
        public event EventHandler? CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion  
        /// <summary>
        /// A realy command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            return true;
        }


        /// <summary>
        /// Executes the command's Actions
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            mAction();
        }

        
    }
}
