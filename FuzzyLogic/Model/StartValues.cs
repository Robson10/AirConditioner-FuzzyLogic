namespace FuzzyLogic.Model
{
    public static class StartValues
    {
        public const int TempReached = 0;
        public const int ChartPre = 2;

        //Temperatura
        public const int TempMin = 0;
        public const int TempMax = 40;
        public const int TempExpectedDefault = 20;
        
        //ogrzewanie
        public const int HeatMin = 0;//w % 0*np 100^C
        public const int HeatMax = 100;
        
        //Klimatyzacja
        public const int ConditionerMin = 0;
        public const int ConditionerMax = 100;

        //godziny pracy
        public const int WorkHoursMin = 0;
        public const int WorkHoursMax = 23;
        public const int WorkHoursDefaultBegin = 0;
        public const int WorkHoursDefaultEnd = 23;
        public const int WorkHoursIncrement = 1;

        //Powierzchnia budynku
        public const int RoomAreaMin = 10;
        public const int RoomAreaMax = 100;
        public const int RoomAreaDefault = 50;
        public const int RoomAreaListInc = 10;

        //Powierzchnia ścian
        public const int WallAreaMin = 50;
        public const int WallAreaMax = 700;
        public const int WallAreaIncrement = 10;

        //powierzchnia okien
        public const int WindowAreatMin = 0;
        public const int WindowAreaMax = RoomAreaMax;
        public const int WindowAreaDefault = 0;
        public const int WindowAreaIncrement = 2;

        //Tytuły
        public const string ChartHeatTittle  = "Ogrzewanie";
        public const string ChartTempTittle = "Temperatura";
        public const string ChartWorkHoursTittle  = "Godziny Pracy";
        public const string ChartCutoutTittle = "Praca Zaworów";
        public const string ChartConditionerTittle = "Klimatyzacja";
        public const string ChartWeatherTittle = "Pogoda";

        //czas
        public const int TimeSpeed = 0;
        public const int TimeSpeed1 = 1000;
        public const int TimeSpeed2 = 500;
        public const int TimeSpeed3 = 250;

    }
}
