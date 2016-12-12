using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzyLogic.Helper;
namespace FuzzyLogic.Model
{
    class Weather:ObservableCollection<ChartItemWeatherItem>
    {
        private Random rnd = new Random();
        private int temp,before;
        public int xWeather = StartValues.UpdateTime-1;
        public Weather()
        {
            this.Add(new ChartItemWeatherItem() { X = 0, Y = 20, Text = "X=0" + Environment.NewLine + "Y=20" });
        }
        public int NextTemp()
        {
            before = this.ElementAt(this.Count - 1).Y;
            do
            {
                temp = rnd.Next(before - 1, before + 2);// * ((before + 2) - (before - 2)) + (before - 2);
            }
            while (temp < StartValues.TempMin || temp > StartValues.TempMax);
            return temp;
        }
        public void AddNext()
        {
            //before = this.ElementAt(this.Count - 1).Y;
            //do
            //{
            //    temp = rnd.Next(before - 1, before + 2);// * ((before + 2) - (before - 2)) + (before - 2);
            //}
            //while (temp < StartValues.TempMin || temp > StartValues.TempMax);
            this.Add(new ChartItemWeatherItem() { X = (this.Count - 1), Y = temp, Text = "X=" + (this.Count - 1) + Environment.NewLine + "Y=" + temp });
        }
        public void AddNext(int tempNow,int tempNowWeather)
        {
            //before = this.ElementAt(this.Count - 1).Y;
            //do
            //{
            //    temp = rnd.Next(before - 1, before + 2);// * ((before + 2) - (before - 2)) + (before - 2);
            //}
            //while (temp < StartValues.TempMin || temp > StartValues.TempMax);
            this.Add(new ChartItemWeatherItem() { X = (this.Count - 1),XWeather=xWeather, Y = tempNowWeather,TempNow=tempNow, Text = "Godzina=" + xWeather/4 + Environment.NewLine + "Y=" + tempNowWeather+Environment.NewLine+ "TempNow="+ tempNow });
            //this.Add(new ChartItemWeatherItem() { X = (this.Count - 2), Y = tempNowWeather, TempNow = tempNow, Text = "X=" + (this.Count - 1) + Environment.NewLine + "Y=" + tempNowWeather + Environment.NewLine + "TempNow=" + tempNow });
            //this.Add(new ChartItemWeatherItem() { X = (this.Count - 3), Y = tempNowWeather, TempNow = tempNow, Text = "X=" + (this.Count - 1) + Environment.NewLine + "Y=" + tempNowWeather + Environment.NewLine + "TempNow=" + tempNow });
            //this.Add(new ChartItemWeatherItem() { X = (this.Count - 4), Y = tempNowWeather, TempNow = tempNow, Text = "X=" + (this.Count - 1) + Environment.NewLine + "Y=" + tempNowWeather + Environment.NewLine + "TempNow=" + tempNow });
        }
    }
}
