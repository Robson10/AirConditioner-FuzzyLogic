using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic.Model
{
    class Weather:ObservableCollection<ChartItems.WeatherItem>
    {
        Random rnd = new Random();
        double x;
        int tempMax;
        int tempMin;
        public Weather(int _TempMin,int _tempMax)
        {
            tempMax = _tempMax;
            tempMin = _TempMin;
            this.Add(new ChartItems.WeatherItem() { X = 0, Temp = 20, Text = "X=0" + Environment.NewLine + "Y=20" });
        }

        public void AddNext()
        {
            double before = this.ElementAt(this.Count - 1).Temp;
            do
            {
                x = rnd.NextDouble() * ((before + 2) - (before - 2)) + (before - 2);
            }
            while (x < tempMin || x > tempMax);
            this.Add(new ChartItems.WeatherItem() { X = this.Count - 1, Temp = x, Text = "X=" + (this.Count - 1) + Environment.NewLine + "Y="+x });
        }
    }
}
