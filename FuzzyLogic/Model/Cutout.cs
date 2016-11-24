using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyLogic.Model
{
    class Cutout : AbstractFuzzyfication<ChartItems.ChartItem3Degree>
    {
        public Cutout(int dokladnosc)
        {
            CreateData(dokladnosc);
        }
        public void CreateData(int dokladnosc)
        {
            int XClosed = 0;
            int XMedium = dokladnosc / 2;
            int XOpen = dokladnosc;
            int range = dokladnosc / 2;
            for (int i = 0; i <= dokladnosc; i++)
            {
                ChartItems.ChartItem3Degree result3Degree = new ChartItems.ChartItem3Degree();

                result3Degree.X = i;
                result3Degree.Min = RozmywanieTrapez(i, 0, XClosed, range);
                result3Degree.Mid = RozmywanieTriangle(i, XMedium, range);
                result3Degree.Max = RozmywanieTrapez(i, XOpen, dokladnosc, range);
                result3Degree.Text = "X=" + i + Environment.NewLine + "Min=" + result3Degree.Min + Environment.NewLine + "Mid=" + result3Degree.Mid + Environment.NewLine + "Max=" + result3Degree.Max;
                base.Add(result3Degree);
            }
        }
    }
}

