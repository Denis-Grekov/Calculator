using System.ComponentModel;
using cakcuulatorNew.Interfaces;

namespace cakcuulatorNew.ViewModels
{

    public interface ICalculatorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
    class CalculatorViewModel : INotifyPropertyChanged
    {
        private readonly ICalculatorModel _calculator;

        public CalculatorViewModel(ICalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public double NumFirst
        {
            get => _calculator.Num1;
            set
            {
                _calculator.Num1 = value;
                OnPropertyChanged(nameof(NumFirst));
            }
        }

        public double NumSecond
        {
            get => _calculator.Num2;
            set
            {
                _calculator.Num2 = value;
                OnPropertyChanged(nameof(NumSecond));
            }
        }

        public double Result => _calculator.Result;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
