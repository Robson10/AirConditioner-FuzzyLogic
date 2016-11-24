namespace FuzzyLogic.Model
{
    using System.Collections.ObjectModel;
    using FuzzyLogic.Helper;
    abstract class AbsCollection <T> : ObservableCollection<T>
    {
        protected double min, midLow, mid, midMor, max,range;

        public int LimitLeft { get;  set; }
        public int LimitRight { get; set; }
        public int XAxisMin { get; set; }
        public int XAxisMax { get; set; }
        
        protected double RozmywaniePoint(double x, double point)
        {
            if (x == point) return 1;
            else return 0;
        }
        protected double RozmywanieTriangle(double i, double srodek, double range)
        {
            double poczatek = srodek - range;
            double koniec = srodek + range;

            if ((i >= poczatek) && (i <= srodek))    return (i - poczatek) / (srodek - poczatek);
            else if ((i >= srodek) && (i <= koniec)) return (koniec - i) / (koniec - srodek);
            else                                    return 0;
        }
        public string FillText(int i, double Min, double Low, double Mid, double Mor, double Max)
        {
            return
                "X=" + i + System.Environment.NewLine +
                ((Min != 0) ? ("Min=" + Min + System.Environment.NewLine) : "") +
                ((Low != 0) ? ("Low=" + Low + System.Environment.NewLine) : "") +
                ((Mid != 0) ? ("Mid=" + Mid + System.Environment.NewLine) : "") +
                ((Mor != 0) ? ("Mor=" + Mor + System.Environment.NewLine) : "") +
                ((Max != 0) ? ("Max=" + Max+ System.Environment.NewLine) : "");
        }
        public string AddTextJoin(string allText,double join)
        {
            try { allText= allText.Remove(allText.IndexOf(System.Environment.NewLine+"Join")); }
            catch { }
            
                return allText + System.Environment.NewLine + "Join=" + join;
            
        }



    }
}
