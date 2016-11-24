using System;
using FuzzyLogic.Helper;
namespace FuzzyLogic.Model
{
    class Temp : AbsCollection<ChartItem5Value>
    {
        public Temp()
        {
            Prepare();
            CreateData(LimitLeft,LimitRight);
        }
        public void Prepare()
        {
            min = StartValues.TempExpectedDefault - 20;
            midLow = StartValues.TempExpectedDefault - 10;
            mid = StartValues.TempExpectedDefault;
            midMor = StartValues.TempExpectedDefault + 10;
            max = StartValues.TempExpectedDefault + 20;
            range = 10;
            XAxisMin = (int)Math.Floor(min);
            XAxisMax = (int)Math.Ceiling(max);
            LimitLeft = (int)Math.Floor(min - range);
            LimitRight = (int)Math.Ceiling(max + range);
        }
        private void CreateData(int LimitLeft, int LimitRight)
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
                result.Text = FillText(i, result.Min, result.Low, result.Mid, result.Mor, result.Max);
                base.Add(result);
            }
        }
    }
}

