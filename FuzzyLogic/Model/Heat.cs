using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic.Model
{
    class Heat:AbstractFuzzyfication<ChartItems.ChartItem3Degree>
    {
        public Heat() { }
        public Heat(int Min,int Max,int TempExpected,int Precision)
        {
            CreateData(Min,Max, TempExpected, Precision);
        }
        public void CreateData(int min, int max,int TempExpected,int precision)
        {
            int Range = 20;
            int off = TempExpected-Range;
            int medium = TempExpected;
            int strong = TempExpected+Range;
            
            for (int i = min; i <= max; i += precision)
            {
                ChartItems.ChartItem3Degree result3Degree = new ChartItems.ChartItem3Degree();

                result3Degree.X = i;
                result3Degree.Min = RozmywanieTrapez(i,0, off,Range);
                result3Degree.Mid = RozmywanieTriangle(i, medium, Range);
                result3Degree.Max = RozmywanieTrapez(i,  strong, max, Range);
                result3Degree.Text = "X=" + i + Environment.NewLine + "Min=" + result3Degree.Min + Environment.NewLine + "Med=" + result3Degree.Mid + Environment.NewLine + "Max=" + result3Degree.Max;

                base.Add(result3Degree);
            }
        }
    }
}
