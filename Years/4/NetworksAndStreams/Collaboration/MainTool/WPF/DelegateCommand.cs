using System;
using System.Windows.Input;

namespace MainTool.WPF
{
    public class DelegateCommand : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructors

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod = null)
            : this((obj) =>
            {
                if (executeMethod == null)
                {
                    return;
                }
                executeMethod();
            },
            (obj) => canExecuteMethod == null ? true : canExecuteMethod())
        { }

        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod = null)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;

            if (this.executeMethod == null)
            {
                this.executeMethod = (obj) => { };
            }

            if (this.canExecuteMethod == null)
            {
                this.canExecuteMethod = (obj) => true;
            }
        }

        #endregion

        #region Public methods

        public bool CanExecute(object parameter)
        {
            return canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Private fields

        private readonly Action<object> executeMethod;
        private readonly Func<object, bool> canExecuteMethod;

        #endregion
    }
}