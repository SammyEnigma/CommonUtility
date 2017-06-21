using System;
using System.Windows.Input;

namespace CommonUtility.Command
{
    interface IRelayCommand : ICommand
    {
        event EventHandler Executed;
        event EventHandler Executing;
    }
}
