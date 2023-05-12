using cakcuulatorNew.Interfaces;
using cakcuulatorNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cakcuulatorNew.viewModel
{

    class CalculatorViewModel : ICalculatorVM
    {
        private readonly Regex _doubleRegex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        private readonly Regex _intRegex = new Regex(@"^[-+]?[0-9]+$");
        private readonly ICalculatorModel _calculator;

        

        public CalculatorViewModel()
        {
            _calculator = new CalculatorModel();
        }

        public CalculatorViewModel(ICalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public double? NumFirst
        {
            get => _calculator.NumFirst;
            set
            {
                if (_doubleRegex.IsMatch(value.ToString()) || _intRegex.IsMatch(value.ToString()))
                {
                    _calculator.NumFirst = value;
                    OnPropertyChanged(nameof(NumFirst));
                }
                
            }
        }

        public double? NumSecond
        {
            get => _calculator.NumSecond;
            set
            {
                if (_doubleRegex.IsMatch(value.ToString()) || _intRegex.IsMatch(value.ToString()))
                {
                    _calculator.NumSecond = value;
                    OnPropertyChanged(nameof(NumSecond));
                }
            }
        }

        public double? Result => _calculator.Result;


        
        public void Add()
        {
            _calculator.Add();
            OnPropertyChanged(nameof(Result));
        }

        public void Subtract()
        {
            _calculator.Subtract();
            OnPropertyChanged(nameof(Result));
        }

        public void Multiply()
        {
            _calculator.Multiply();
            OnPropertyChanged(nameof(Result));
        }

        public void Divide()
        {

            _calculator.Divide();
            OnPropertyChanged(nameof(Result));

        }

        public System.Windows.Input.ICommand AddCommand
        {
            get { return new RelayCommand(Add); }

        }

        public System.Windows.Input.ICommand SubtractCommand
        {
            get { return new RelayCommand(Subtract); }

        }

        public System.Windows.Input.ICommand MultiplyCommand
        {
            get { return new RelayCommand(Multiply); }

        }

        public System.Windows.Input.ICommand DivideCommand
        {
            get { return new RelayCommand(Divide); }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
