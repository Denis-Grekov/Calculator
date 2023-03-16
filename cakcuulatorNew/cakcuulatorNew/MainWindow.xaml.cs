using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        private List<string> _history;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                string messageBoxText = "Числа а не введено!";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            }
            else if (TextBox2.Text == "")
            {
                string messageBoxText = "Числа b не введено!";
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

        

        private void TextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tbne = sender as TextBox;
            if ((!Char.IsDigit(e.Text, 0)) && (e.Text != ","))
            {
                { e.Handled = true; }
            }
            else
                if ((e.Text == ",") && ((tbne.Text.IndexOf(",") != -1) || (tbne.Text == "")))
            { e.Handled = true; }
        }

        private void TextBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tbne = sender as TextBox;
            if ((!Char.IsDigit(e.Text, 0)) && (e.Text != ","))
            {
                { e.Handled = true; }
            }
            else
                if ((e.Text == ",") && ((tbne.Text.IndexOf(",") != -1) || (tbne.Text == "")))
            { e.Handled = true; }
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
