using System;
using System.Windows.Input;

namespace CommonUtility.Command
{
    internal interface IRelayCommand : ICommand
    {
        event EventHandler Executed;
        event EventHandler Executing;
    }
}