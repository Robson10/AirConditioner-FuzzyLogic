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
        //pierwsza wartosc na start programu
        public Weather()
        {
            this.Add(new ChartItemWeatherItem() { X = 0, Y = 20, Text = "X=0" + Environment.NewLine + "Y=20" });
        }
        //generowanie nastepnej temp pogody +1 -1
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
        //dodanie tempNow (pomieszczenie) i tempNowWeather 
        public void AddNext(double tempNowBuildidn,int tempNowWeather)
        {
            this.Add(new ChartItemWeatherItem() { X = (this.Count - 1),XWeather=xWeather, Y = tempNowWeather,TempNow= tempNowBuildidn, Text = "Godzina=" + xWeather/4 + Environment.NewLine + "Y=" + tempNowWeather+Environment.NewLine+ "TempNow="+ tempNowBuildidn });
        }
    }
}
