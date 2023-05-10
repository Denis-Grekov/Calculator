using System.ComponentModel;
using cakcuulatorNew.Interfaces;
using static cakcuulatorNew.IModel;

namespace cakcuulatorNew.ViewModels
{

    public interface ICalculatorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
    class CalculatorViewModel : INotifyPropertyChanged
    {
        private readonly ICalculatorModel _calculator;

        public CalculatorViewModel()
        {
            _calculator = new CalculatorModel();
        }

        public CalculatorViewModel(ICalculatorModel calculator)
        {
            _calculator = calculator;
        }

        public double NumFirst
        {
            get => _calculator.NumFirst;
            set
            {
                _calculator.NumFirst = value;
                OnPropertyChanged(nameof(NumFirst));
            }
        }

        public double NumSecond
        {
            get => _calculator.NumSecond;
            set
            {
                _calculator.NumSecond = value;
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
