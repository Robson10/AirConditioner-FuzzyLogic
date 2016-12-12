using System.ComponentModel;

namespace FuzzyLogic.Model
{
    class ChartItem1Value
    {
        public string Text { get; set; }
        public int X { get; set; }
        public double Y { get; set; }
    }

    class ChartItem5Value:INotifyPropertyChanged
    {
        public int X { get; set; }
        public double Min { get; set; }
        public double Low { get; set; }
        public double Mid { get; set; }
        public double Mor { get; set; }
        public double Max { get; set; }
        public double _ZbiorWnioskowania;
        public double ZbiorWnioskowania
        {
            get { return _ZbiorWnioskowania; }
            set
            {
                if (_ZbiorWnioskowania != value)
                {
                    _ZbiorWnioskowania = value;
                    OnPropertyChanged("ZbiorWnioskowania");
                }
            }
        }
        public string Text { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    class ChartItemWeatherItem
    {
        public string Text { get; set; }
        public int X { get; set; }
        public int XWeather { get; set; }
        public int Y { get; set; }
        public int TempNow { get; set; }

    }
}
