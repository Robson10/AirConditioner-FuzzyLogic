namespace FuzzyLogic.Helper
{
    public static class StartValues
    {
        public const int TempReached = 0;
        public const int ChartPre = 1;

        //hours on Chart
        public const int HoursOnChart = 48;
        //Temperatura
        public const int TempMin = 0;
        public const int TempMax = 40;
        public static int TempExpectedDefault = 20;
        
        //ogrzewanie
        public const int HeatMin = 0;//w % 0*np 100^C
        public const int HeatMax = 100;
        
        //Klimatyzacja
        public const int ConditionerMin = 0;
        public const int ConditionerMax = 100;

        //godziny pracy
        public const int WorkHoursMin = 0;
        public const int WorkHoursMax = 23;
        public const int WorkHoursDefaultBegin = 20;
        public const int WorkHoursDefaultEnd = 10;
       // public const int WorkHoursIncrement = 1;

        //Powierzchnia budynku
        public const int RoomAreaMin = 10;
        public const int RoomAreaMax = 100;
        public const int RoomAreaDefaultIndex = 0;
        public const int RoomAreaListInc = 10;

        //Powierzchnia ścian
        public const int WallHeightMin = 200;
        public const int WallHeightMax = 700;
        public const int WallHeightIncrement = 10;
        public const int WallHeightDefaultIndex = 0;
        //powierzchnia okien
        public const int WindowAreatMin = 0;
        public const int WindowAreaMax = RoomAreaMax;
        public const int WindowAreaDefaultIndex = 0;
        public const int WindowAreaIncrement = 2;

        //Tytuły
        public const string ChartHeatTittle  = "Ogrzewanie";
        public const string ChartTempTittle = "Temperatura";
        public const string ChartWorkHoursTittle  = "Godziny Pracy";
        public const string ChartConditionerTittle = "Klimatyzacja";
        public const string ChartWeatherTittle = "Pogoda";
        public const string ChartHelperTittle = "Wnioskowanie";

        //czas
        public const int TimeSpeed = 3;
        public const int TimeSpeed1 = 1000;
        public const int TimeSpeed2 = 500;
        public const int TimeSpeed3 = 250;

    }
}
