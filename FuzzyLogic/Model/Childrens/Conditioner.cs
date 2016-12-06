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
        //public void CreateData(int ConditionerMin, int min, int max,int tempExpected, int precision)
        //{
        //    int minTempConditioner = ConditionerMin;
        //    int Min = tempExpected;
        //    int medium = minTempConditioner+(int) Math.Round((tempExpected- minTempConditioner) /2.0);
        //    int strong = minTempConditioner;
        //    int Range = (int)Math.Round(medium/2.0);

        //    for (int i = minTempConditioner; i <= max; i += precision)
        //    {
        //        ChartItems.ChartItem3Degree result3Degree = new ChartItems.ChartItem3Degree();

        //        result3Degree.X = i;
        //        result3Degree.Min = RozmywanieTrapez(i,Min , max, Range);
        //        result3Degree.Mid = RozmywanieTriangle(i, medium, Range);
        //        result3Degree.Max = RozmywanieTrapez(i, minTempConditioner, strong, Range);
        //        result3Degree.Text = "X=" + i + Environment.NewLine + "Min=" + result3Degree.Min + Environment.NewLine + "Med=" + result3Degree.Mid + Environment.NewLine + "Max=" + result3Degree.Max;

        //        base.Add(result3Degree);
        //    }
        //}
    }
}
