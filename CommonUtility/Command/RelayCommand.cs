using System;
using System.Diagnostics;
using System.Windows.Input;

namespace CommonUtility.Command
{
    public class RelayCommand : IRelayCommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute)
        {
            _action = execute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : this(execute)
        {
            this._canExecute = canExecute;
        }

        protected RelayCommand()
        {
        }

        #region IRelayCommand Members

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public event EventHandler Executed;

        public event EventHandler Executing;

        [DebuggerStepThrough]
        public virtual bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            OnExecuting();

            InvokeAction(parameter);

            OnExecuted();
        }

        protected virtual void InvokeAction(object parameter)
        {
            _action();
        }

        protected void OnExecuted()
        {
            Executed?.Invoke(this, null);
        }

        protected void OnExecuting()
        {
            Executing?.Invoke(this, null);
        }

        #endregion IRelayCommand Members
    }

    /// <summary>
    ///     A command whose sole purpose is to
    ///     relay its functionality to other
    ///     objects by invoking delegates. The
    ///     default return value for the CanExecute
    ///     method is 'true'.
    /// </summary>
    public class RelayCommand<T> : RelayCommand
    {
        private readonly Action<T> _action;
        private readonly Func<T, bool> _canExecute;

        /// <summary>
        ///     Creates a new command that can always execute.
        /// </summary>
        /// <param name="action">The execution logic.</param>
        public RelayCommand(Action<T> action)
            : this(action, null)
        {
        }

        /// <summary>
        ///     Creates a new command.
        /// </summary>
        /// <param name="action">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> action, Func<T, bool> canExecute)
        {
            this._action = action;
            this._canExecute = canExecute;
        }

        protected RelayCommand()
        {
        }

        /// <summary>
        ///     Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        ///     true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">
        ///     Data used by the command.  If the command does not require data to be passed, this object can
        ///     be set to null.
        /// </param>
        public override bool CanExecute(object parameter)
        {
            return _canExecute == null
                   || _canExecute((T) parameter);
        }

        protected override void InvokeAction(object parameter)
        {
            _action((T) parameter);
        }
    }
}