using System;
using FuzzyLogic.Helper;
namespace FuzzyLogic.Model
{
    class Conditioner:AbsCollection<ChartItem5Value>
    {
        public Conditioner()
        {
            Prepare();
            CreateData();
        }
        //przygotowuje zakresy dla jakich beda wartosci X oraz odnosniki dla osi wykresów
        private void Prepare()
        {
            min = 0;
            max = 100;
            mid = (max - min) / 2;
            range = max / 2;
            XAxisMin = (int)Math.Floor(min);
            XAxisMax = (int)Math.Ceiling(max);
            LimitLeft = (int)Math.Floor(min - range);
            LimitRight = (int)Math.Ceiling(max + range);
        }
        //a tu wypelniamy danymi
        private void CreateData()
        {
            for (int i = LimitLeft; i <= LimitRight; i += StartValues.ChartPre)
            {
                ChartItem5Value result = new ChartItem5Value();

                result.X = i;
                result.Min = RozmywanieTriangle(i, min, range);
                result.Mid = RozmywanieTriangle(i, mid, range);
                result.Max = RozmywanieTriangle(i, max, range);
                result.Text = FillText(i, result.Min, 0, result.Mid, 0, result.Max);
                base.Add(result);
            }
        }
    }
}
