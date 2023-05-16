using cakcuulatorNew.Interfaces;
using cakcuulatorNew.viewModel;

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cakcuulatorNew
{
  
    public partial class MainWindow : Window
    {
        public bool IsListBoxVisible { get; set; }
        private ICalculatorVM _calculatorVM;

        public MainWindow()
        {
            InitializeComponent();

            _calculatorVM = new CalculatorViewModel();
            DataContext = _calculatorVM;
        }

        private void TextBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) && e.Key != Key.Decimal)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Decimal && (textBox.Text.Contains(".") || textBox.SelectionStart == 0))
            {
                e.Handled = true;
            }
        }

        private void TextBox2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) && e.Key != Key.Decimal)
            {
                e.Handled = true;
            }
            else if (e.Key == Key.Decimal && (textBox.Text.Contains(".") || textBox.SelectionStart == 0))
            {
                e.Handled = true;
            }
        }

        
    }
}