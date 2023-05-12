using System.ComponentModel;



namespace cakcuulatorNew.Interfaces
{

    public interface ICalculatorVM : INotifyPropertyChanged
    {
        double? NumFirst { get; set; }
        double? NumSecond { get; set; }
        double? Result { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
   
}
