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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            return;

            if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                string messageBoxText = "Не введены оба числа!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }

            else if (TextBox1.Text == "")
            {
                string messageBoxText = "Числа а не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                
            }
            else if (TextBox2.Text == "")
            {
                string messageBoxText = "Числа b не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                double num1 = Convert.ToDouble(TextBox1.Text);
                double num2 = Convert.ToDouble(TextBox2.Text);
                double ans;
                ans = num1 + num2;
                
                TextBox3.Text = Convert.ToString(ans);
                _history1.Items.Add(TextBox1.Text + "+" + TextBox2.Text + "=" + TextBox3.Text);
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                string messageBoxText = "Не введены оба числа!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }

            else if (TextBox1.Text == "")
            {
                string messageBoxText = "Числа а не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            }
            else if (TextBox2.Text == "")
            {
                string messageBoxText = "Числа b не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }

            else
            {
                double num1 = Convert.ToDouble(TextBox1.Text);
                double num2 = Convert.ToDouble(TextBox2.Text);
                double ans;
                ans = num1 - num2;
                TextBox3.Text = Convert.ToString(ans);
                _history1.Items.Add(TextBox1.Text + "-" + TextBox2.Text + "=" + TextBox3.Text);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                string messageBoxText = "Не введены оба числа!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);


            }

            else if (TextBox1.Text == "")
            {
                string messageBoxText = "Числа а не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            }
            else if (TextBox2.Text == "")
            {
                string messageBoxText = "Числа b не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                double num1 = Convert.ToDouble(TextBox1.Text);
                double num2 = Convert.ToDouble(TextBox2.Text);
                double ans;
                ans = num1 * num2;
                TextBox3.Text = Convert.ToString(ans);
                _history1.Items.Add(TextBox1.Text + "*" + TextBox2.Text + "=" + TextBox3.Text);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                string messageBoxText = "Не введены оба числа!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else if (TextBox1.Text == "")
            {
                string messageBoxText = "Число а не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            }
            else if (TextBox2.Text == "")
            {
                string messageBoxText = "Число b не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                double num1 = Convert.ToDouble(TextBox1.Text);
                double num2 = Convert.ToDouble(TextBox2.Text);
                double ans;
                ans = num1 / num2;
                TextBox3.Text = Convert.ToString(ans);

                _history1.Items.Add(TextBox1.Text + "/" + TextBox2.Text + "=" + TextBox3.Text);
            }
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

        private void TextBox1_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            return;
           
        }

        private void TextBox2_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            return;
            
        }

        public static bool IsValid(string str)
        {
            double i;
            return double.TryParse(str, out i) && i >= double.MinValue && i <= double.MaxValue;
        }
        
        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private async void buttinSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "TXT|*.txt" };
            saveFileDialog.ShowDialog();
            if (string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                string messageBoxText = "Выберите файл!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < _history1.Items.Count; i++)
                        await writer.WriteLineAsync(_history1.Items[i].ToString());
                }
            }
        }

        private async void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "TXT|*.txt" };
            openFileDialog.ShowDialog();
            _history1.Items.Clear();
            string path = openFileDialog.FileName;

            if (string.IsNullOrEmpty(path))
            {
                string messageBoxText = "Выберите файл!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
            else
            {
                bool hasForeignCharacters = false;
                using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (ValidateString(line))
                        {
                            _history1.Items.Add(line);
                        }
                        else
                        {
                            hasForeignCharacters = true;
                        }
                    }
                }
                if (hasForeignCharacters)
                {
                    string messageBoxText = "Файл содержит сторонние символы!";
                    string caption = "Word Processor";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
            }
        }

        private bool ValidateString(string input)
        {
            bool startsWithNumber = System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d");
            bool endsWithNumber = System.Text.RegularExpressions.Regex.IsMatch(input, @"\d$");

            return startsWithNumber && endsWithNumber;
        }
    }



    




}
