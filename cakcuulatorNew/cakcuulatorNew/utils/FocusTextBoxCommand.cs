using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace cakcuulatorNew.utils
{
    class FocusTextBoxCommand : ICommand
    {
        private readonly TextBox textBox;

        public FocusTextBoxCommand(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            textBox.Focus();
            textBox.Select(textBox.Text.Length, 0);
        }

        public event EventHandler CanExecuteChanged;
    }
}
