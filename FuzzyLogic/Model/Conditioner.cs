using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic.Model
{
    class Conditioner:AbstractFuzzyfication<ChartItems.ChartItem3Degree>
    {
        public Conditioner() { }
        public Conditioner(int ConditionerMin,int Min, int Max, int tempExpected, int Precision)
        {
            CreateData(ConditionerMin,Min, Max, tempExpected, Precision);
        }
        public void CreateData(int ConditionerMin, int min, int max,int tempExpected, int precision)
        {
            int minTempConditioner = ConditionerMin;
            int Min = tempExpected;
            int medium = minTempConditioner+(int) Math.Round((tempExpected- minTempConditioner) /2.0);
            int strong = minTempConditioner;
            int Range = (int)Math.Round(medium/2.0);

            for (int i = minTempConditioner; i <= max; i += precision)
            {
                ChartItems.ChartItem3Degree result3Degree = new ChartItems.ChartItem3Degree();

                result3Degree.X = i;
                result3Degree.Min = RozmywanieTrapez(i,Min , max, Range);
                result3Degree.Mid = RozmywanieTriangle(i, medium, Range);
                result3Degree.Max = RozmywanieTrapez(i, minTempConditioner, strong, Range);
                result3Degree.Text = "X=" + i + Environment.NewLine + "Min=" + result3Degree.Min + Environment.NewLine + "Med=" + result3Degree.Mid + Environment.NewLine + "Max=" + result3Degree.Max;

                base.Add(result3Degree);
            }
        }
    }
}
