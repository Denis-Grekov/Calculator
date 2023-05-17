using cakcuulatorNew.Interfaces;
using cakcuulatorNew.Model;
using cakcuulatorNew.utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace cakcuulatorNew.viewModel
{

    class CalculatorViewModel : ICalculatorVM
    {
        public Regex _doubleRegex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        public Regex _intRegex = new Regex(@"^[-+]?[0-9]+$");

        private readonly ICalculatorModel _calculator;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

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

        public System.Windows.Input.ICommand ToggleListBoxVisibilityCommand { get; }

        private void ToggleListBoxVisibility()
        {
            IsListBoxVisible = !IsListBoxVisible;
        }

        public System.Windows.Input.ICommand VisCommand
        {
            get { return new RelayCommand(ToggleListBoxVisibility); }
        }


        public double? Result => _calculator.Result;

        public ObservableCollection<string> History => _history;

        public void Add()
        {
            if (NumFirst.HasValue && NumSecond.HasValue)
            {
                _calculator.Add();

                OnPropertyChanged(nameof(Result));

                string historyItem = $"{NumFirst} + {NumSecond} = {Result}";
                _history.Add(historyItem);
            }
        }

        public void Subtract()
        {
            if (NumFirst.HasValue && NumSecond.HasValue)
            {
                _calculator.Subtract();

                OnPropertyChanged(nameof(Result));

                string historyItem = $"{NumFirst} - {NumSecond} = {Result}";
                _history.Add(historyItem);
            }
        }

        public void Multiply()
        {
            if (NumFirst.HasValue && NumSecond.HasValue)
            {
                _calculator.Multiply();

                OnPropertyChanged(nameof(Result));

                string historyItem = $"{NumFirst} * {NumSecond} = {Result}";
                _history.Add(historyItem);
            }
        }

        public void Divide()
        {
            if (NumFirst.HasValue && NumSecond.HasValue)
            {
                _calculator.Divide();

                OnPropertyChanged(nameof(Result));

                string historyItem = $"{NumFirst} / {NumSecond} = {Result}";
                _history.Add(historyItem);
            }
        }

        public System.Windows.Input.ICommand SaveHistoryCommand => new RelayCommand(async () =>
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
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var item in History)
                    {
                        await writer.WriteLineAsync(item);
                    }
                }
            }
        });

        public System.Windows.Input.ICommand LoadHistoryCommand => new RelayCommand(async () =>
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "TXT|*.txt" };
            openFileDialog.ShowDialog();
            History.Clear();
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
                using (StreamReader reader = new StreamReader(path))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (ValidateString(line))
                        {
                            History.Add(line);
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
        });

        private Visibility _historyVisibility = Visibility.Hidden;

        public Visibility HistoryVisibility
        {
            get { return _historyVisibility; }
            set
            {
                if (_historyVisibility != value)
                {
                    _historyVisibility = value;
                    OnPropertyChanged(nameof(HistoryVisibility));
                }
            }
        }

        private bool ValidateString(string input)
        {
            bool startsWithNumber = System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d");
            bool endsWithNumber = System.Text.RegularExpressions.Regex.IsMatch(input, @"\d$");

            return startsWithNumber && endsWithNumber;
        }

        private bool _isListBoxVisible;

        public bool IsListBoxVisible
        {
            get { return _isListBoxVisible; }
            set
            {
                if (_isListBoxVisible != value)
                {
                    _isListBoxVisible = value;
                    OnPropertyChanged(nameof(IsListBoxVisible));
                }
            }
        }

        

        public BoolToVisibilityConverter Converter { get; }

        


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

