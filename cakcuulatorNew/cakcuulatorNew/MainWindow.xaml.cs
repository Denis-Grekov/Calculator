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
        private ICalculatorVM _calculatorVM;

        public MainWindow()
        {
            InitializeComponent();

            _calculatorVM = new CalculatorViewModel();
            DataContext = _calculatorVM;
            
        }

        

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            if (_history1.Visibility == Visibility.Visible) 
            {
                _history1.Visibility = Visibility.Hidden;
            }
            else
            {
                _history1.Visibility = Visibility.Visible;
            }
        }

        

        
    }



    




}
