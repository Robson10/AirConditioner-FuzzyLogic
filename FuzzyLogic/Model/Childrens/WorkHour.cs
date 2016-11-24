namespace FuzzyLogic.Model
{
    class WorkHour : AbsCollection<ChartItem1Value>
    {
        public WorkHour(int beginWork, int endWork)
        {
            CreateData(beginWork, endWork);
        }
        public void CreateData(int begin, int end)
        {
            if (begin < end)
            {
                for (int i = 0; i < 24; i++)
                {
                    ChartItem1Value result1Degree = new ChartItem1Value();
                    result1Degree.X = i;
                    result1Degree.Y = RozmywanieTrapez(i, begin, end-1, 0.1);
                    result1Degree.Text = "Hour=" + result1Degree.X + " IsWorking=" + result1Degree.Y;
                    base.Add(result1Degree);
                }
            }
            else
            {
                for (int i = 0; i < 24; i++)
                {
                    ChartItem1Value result1Degree = new ChartItem1Value();
                    result1Degree.X = i;
                    double a= RozmywanieTrapez(i, begin-1, 24, 0.0);
                    double b= RozmywanieTrapez(i, 0, end-1, 0.0);
                    result1Degree.Y = (a == 1) ? a : b;
                    result1Degree.Text = "Hour=" + result1Degree.X + " IsWorking=" + result1Degree.Y;
                    base.Add(result1Degree);
                }
            }
        }
        protected double RozmywanieTrapez(double x, double left, double right, double range)
        {
            double poczatek = left - range;
            double koniec = right + range;
            double maxLewy = left;
            double maxPrawy = right;

            if ((x >= poczatek) & (x <= maxLewy) & (maxLewy > 0))
                return (x - poczatek) / (maxLewy - poczatek);
            else if ((x >= maxLewy) & (x <= maxPrawy))
                return 1;
            else if ((x >= maxPrawy) & (x <= koniec))
                return (koniec - x) / (koniec - maxPrawy);
            else return 0;
        }
    }
}
