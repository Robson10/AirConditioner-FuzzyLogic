using System;
using FuzzyLogic.Helper;
namespace FuzzyLogic.Model
{
    class Heat: AbsCollection<ChartItem5Value>
    {

        public Heat()
        {
            Prepare();
            CreateData();
        }

        private void Prepare()
        {
            min = 0;
            max = 100;
            mid = (max-min)/2;
            XAxisMin = (int)Math.Floor(min);
            XAxisMax = (int)Math.Ceiling(max);
            range = max / 2;
            LimitLeft = (int)Math.Floor(min - range);
            LimitRight = (int)Math.Ceiling(max + range);
        }

        private void CreateData()
        { 
            for (int i = LimitLeft; i <= LimitRight; i += StartValues.ChartPre)
            {
                ChartItem5Value result = new ChartItem5Value();

                result.X = i;
                result.Min = RozmywanieTriangle(i, min, range);
                result.Low = RozmywanieTriangle(i, midLow, range);
                result.Mid = RozmywanieTriangle(i, mid, range);
                result.Mor = RozmywanieTriangle(i, midMor, range);
                result.Max = RozmywanieTriangle(i, max, range);
                result.Text = FillText(i, result.Min, 0, result.Mid,0, result.Max);

                base.Add(result);
            }
        }
    }
}
