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
  
    public enum LocalizationEnum
    {
        Ru = 0,
        En = 1
    }

    public partial class MainWindow : Window
    {
        public bool IsListBoxVisible { get; set; }
        private ICalculatorVM _calculatorVM;


        private LocalizationEnum _localizationEnum = LocalizationEnum.Ru;
        public MainWindow()
        {
            InitializeComponent();

            _calculatorVM = new CalculatorViewModel();
            DataContext = _calculatorVM;
        }


        private void localizationBut_Click(object sender, RoutedEventArgs e)
        {
            if (_localizationEnum == LocalizationEnum.En)
            {
                _localizationEnum = LocalizationEnum.Ru;
            }
            else
            {
                _localizationEnum = LocalizationEnum.En;
            }
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            if (_localizationEnum == LocalizationEnum.En)
            {
                addBut.Content = cakcuulatorNew.Properties.ResourcesEng.s_addition;
                subBut.Content = cakcuulatorNew.Properties.ResourcesEng.s_subtracting;
                mulBut.Content = cakcuulatorNew.Properties.ResourcesEng.s_multiplying;
                divBut.Content = cakcuulatorNew.Properties.ResourcesEng.s_dividing;
                historyButton5.Content = cakcuulatorNew.Properties.ResourcesEng.s_history;
                buttonLoad.Content = cakcuulatorNew.Properties.ResourcesEng.s_load;
                buttinSave.Content = cakcuulatorNew.Properties.ResourcesEng.s_save;
                firstNum.Text = cakcuulatorNew.Properties.ResourcesEng.s_firstNum;
                secondNum.Text = cakcuulatorNew.Properties.ResourcesEng.s_secondNum;
                answer.Text = cakcuulatorNew.Properties.ResourcesEng.s_answer;
                localizationBut.Content = cakcuulatorNew.Properties.ResourcesEng.s_localization;

            }
            else
            {
                addBut.Content = cakcuulatorNew.Properties.ResourcesRu.s_addition;
                subBut.Content = cakcuulatorNew.Properties.ResourcesRu.s_subtracting;
                mulBut.Content = cakcuulatorNew.Properties.ResourcesRu.s_multiplying;
                divBut.Content = cakcuulatorNew.Properties.ResourcesRu.s_dividing;
                historyButton5.Content = cakcuulatorNew.Properties.ResourcesRu.s_history;
                buttonLoad.Content = cakcuulatorNew.Properties.ResourcesRu.s_load;
                buttinSave.Content = cakcuulatorNew.Properties.ResourcesRu.s_save;
                firstNum.Text = cakcuulatorNew.Properties.ResourcesRu.s_firstNum;
                secondNum.Text = cakcuulatorNew.Properties.ResourcesRu.s_secondNum;
                answer.Text = cakcuulatorNew.Properties.ResourcesRu.s_answer;
                localizationBut.Content = cakcuulatorNew.Properties.ResourcesRu.s_localization;
            }
        }
        

    }
}