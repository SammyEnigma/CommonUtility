using System;
using System.Windows.Input;

namespace Utility.Command
{
    interface IRelayCommand : ICommand
    {
        event EventHandler Executed;
        event EventHandler Executing;
    }
}
