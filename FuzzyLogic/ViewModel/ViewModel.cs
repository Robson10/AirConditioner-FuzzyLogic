using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Threading;
using FuzzyLogic.Model;
using System.Collections.ObjectModel;
using System.Windows;
using FuzzyLogic.Helper;

namespace FuzzyLogic
{
    class ViewModel : BindableBase
    {
        #region Temp
        //ChartName
        public string ChartTempTittle { get; } = StartValues.ChartTempTittle;
        //for chart Axis
        private int _TempMin;
        public int TempMin
        {
            get { return _TempMin; }
            set { SetProperty(ref _TempMin, value); }
        }

        private int _TempMax;
        public int TempMax
        {
            get { return _TempMax; }
            set { SetProperty(ref _TempMax, value); }
        }
        //for listbox
        private ObservableCollection<int> _TempList;
        public ObservableCollection<int> TempList
        {
            get
            {
                if (_TempList == null)
                {
                    _TempList = new ObservableCollection<int>();
                    for (int i = StartValues.TempExpectedMin; i <= StartValues.TempExpectedMax; i += StartValues.ChartPre)
                    {
                        _TempList.Add(i);
                    }
                }
                return _TempList;
            }
            set { SetProperty(ref _TempList, value); }
        }

        private int _TempExpected = StartValues.TempExpectedDefault;
        public int TempExpected
        {
            get { return _TempExpected; }
            set
            {
                SetProperty(ref _TempExpected, value);
                StartValues.TempExpectedDefault = value;

                Line_Temp = new Temp();
                //Line_Conditioner = new Conditioner();
                //Line_Heat = new Heat(StartValues.HeatMin, StartValues.HeatMax, 20, StartValues.TempChartPrecision);
            }
        }
        //DataCollection
        private Temp _Line_Temp;
        public Temp Line_Temp
        {
            get
            {
                if (_Line_Temp == null)
                    _Line_Temp = new Temp();
                TempMin = _Line_Temp.XAxisMin;
                TempMax = _Line_Temp.XAxisMax;
                return _Line_Temp;
            }
            set
            {
                SetProperty(ref _Line_Temp, value);
            }
        }
        #endregion
        #region WorkHours
        public string ChartWorkHoursTittle { get; } = StartValues.ChartWorkHoursTittle;

        //ListBox
        private ObservableCollection<int> _WorkHourMinList;
        public ObservableCollection<int> WorkHourMinList
        {
            get
            {
                if (_WorkHourMinList == null)
                {
                    _WorkHourMinList = new ObservableCollection<int>();
                    for (int i = 0; i < 24; i++)
                    {
                        _WorkHourMinList.Add(i);
                    }
                }
                return _WorkHourMinList;
            }
            set { SetProperty(ref _WorkHourMinList, value); }
        }
        private ObservableCollection<int> _WorkHourMaxList;
        public ObservableCollection<int> WorkHourMaxList
        {
            get
            {
                if (_WorkHourMaxList == null)
                {
                    _WorkHourMaxList = new ObservableCollection<int>();
                    for (int i = 0; i < 24; i++)
                    {
                        _WorkHourMaxList.Add(i);
                    }
                }
                return _WorkHourMaxList;
            }
            set { SetProperty(ref _WorkHourMaxList, value); }
        }

        //ListBox Selection
        private int _SelectedWorkHourMin = StartValues.WorkHoursDefaultBegin;
        public int SelectedWorkHourMin
        {
            get { return _SelectedWorkHourMin; }
            set
            {
                SetProperty(ref _SelectedWorkHourMin, value);
                Line_WorkHours = new WorkHour(SelectedWorkHourMin, SelectedWorkHourMax);
            }
        }
        private int _SelectedWorkHourMax = StartValues.WorkHoursDefaultEnd;
        public int SelectedWorkHourMax
        {
            get { return _SelectedWorkHourMax; }
            set
            {
                SetProperty(ref _SelectedWorkHourMax, value);
                Line_WorkHours = new WorkHour(SelectedWorkHourMin, SelectedWorkHourMax);
            }
        }

        //DataCollection
        private WorkHour _Line_WorkHours;
        public WorkHour Line_WorkHours
        {
            get
            {
                if (_Line_WorkHours == null)
                    _Line_WorkHours = new WorkHour(SelectedWorkHourMin, SelectedWorkHourMax);
                return _Line_WorkHours;
            }
            set
            {
                SetProperty(ref _Line_WorkHours, value);
            }
        }
        #endregion
        #region Heat
        public string ChartHeatTittle { get; } = StartValues.ChartHeatTittle;

        private int _HeatMin;
        public int HeatMin
        {
            get { return _HeatMin; }
            set { SetProperty(ref _HeatMin, value); }
        }

        private int _HeatMax;
        public int HeatMax
        {
            get { return _HeatMax; }
            set { SetProperty(ref _HeatMax, value); }
        }
        private Heat _Line_Heat = null;
        public Heat Line_Heat
        {
            get
            {
                if (_Line_Heat == null)
                {
                    _Line_Heat = new Heat();
                    HeatMin = _Line_Heat.XAxisMin;
                    HeatMax = _Line_Heat.XAxisMax;
                }
                return _Line_Heat;
            }
            set { SetProperty(ref _Line_Heat, value); }
        }
        #endregion
        #region Conditioner
        //for chart
        public string ChartConditionerTittle { get; } = StartValues.ChartConditionerTittle;
        private int _CondirionerMin;
        public int ConditionerMin
        {
            get { return _CondirionerMin; }
            set { SetProperty(ref _CondirionerMin, value); }
        }
        private int _CondirionerMax;
        public int ConditionerMax
        {
            get { return _CondirionerMax; }
            set { SetProperty(ref _CondirionerMax, value); }
        }

        private Conditioner _Line_Conditioner;
        public Conditioner Line_Conditioner
        {
            get
            {
                if (_Line_Conditioner == null)
                { _Line_Conditioner = new Conditioner();
                    ConditionerMin = _Line_Conditioner.XAxisMin;
                    ConditionerMax = _Line_Conditioner.XAxisMax;
                }
                return _Line_Conditioner;
            }
            set
            {
                SetProperty(ref _Line_Conditioner, value);
            }
        }
        #endregion
        #region Weather
        public string ChartWeatherTittle { get; } = StartValues.ChartWeatherTittle;
        //przycinanie charta z lewej
        public int _WeatherXmin = 0;
        public int WeatherXmin { get { return _WeatherXmin; } set { SetProperty(ref _WeatherXmin, value); } }
        public int _WeatherXmax= StartValues.HoursOnChart;
        public int WeatherXmax { get { return _WeatherXmax; } set { SetProperty(ref _WeatherXmax, value); } }
        private Weather _Line_Weather;
        public Weather Line_Weather
        {
            get
            {
                if (_Line_Weather == null)
                { _Line_Weather = new Weather(); }
                return _Line_Weather;
            }
            set
            {
                SetProperty(ref _Line_Weather, value);
            }
        }
        #endregion

        #region RoomArea
        private int _SelectedRoomArea = StartValues.RoomAreaDefaultIndex;
        public int SelectedRoomArea
        {
            get { return _SelectedRoomArea; }
            set { SetProperty(ref _SelectedRoomArea, value); }
        }

        private ObservableCollection<int> _RoomAreaList;
        public ObservableCollection<int> RoomAreaList
        {
            get
            {
                if (_RoomAreaList == null)
                {
                    _RoomAreaList = new ObservableCollection<int>();
                    for (int i = StartValues.RoomAreaMin; i < StartValues.RoomAreaMax; i += StartValues.RoomAreaListInc)
                    {
                        _RoomAreaList.Add(i);
                    }
                }
                return _RoomAreaList;
            }
            set { SetProperty(ref _RoomAreaList, value); }
        }
        #endregion
        #region WindowArea
        private int _SelectedWindowArea = StartValues.WindowAreaDefaultIndex;
        public int SelectedWindowArea
        {
            get { return _SelectedWindowArea; }
            set { SetProperty(ref _SelectedWindowArea, value); }
        }
        private ObservableCollection<int> _WindowAreaList;
        public ObservableCollection<int> WindowAreaList
        {
            get
            {
                if (_WindowAreaList == null)
                {
                    _WindowAreaList = new ObservableCollection<int>();
                    for (int i = StartValues.WindowAreatMin; i < StartValues.WindowAreaMax; i += StartValues.WindowAreaIncrement)
                    {
                        _WindowAreaList.Add(i);
                    }
                }
                return _WindowAreaList;
            }
            set { SetProperty(ref _WindowAreaList, value); }
        }
        #endregion
        #region WallHeight
        private int _SelectedWallHeight = StartValues.WindowAreaDefaultIndex;
        public int SelectedWallHeight
        {
            get { return _SelectedWallHeight; }
            set { SetProperty(ref _SelectedWallHeight, value); }
        }

        private ObservableCollection<int> _WallHeightList;
        public ObservableCollection<int> WallHeightList
        {
            get
            {
                if (_WallHeightList == null)
                {
                    _WallHeightList = new ObservableCollection<int>();
                    for (int i = StartValues.WallHeightMin; i < StartValues.WallHeightMax; i += StartValues.WallHeightIncrement)
                    {
                        _WallHeightList.Add(i);
                    }
                }
                return _WallHeightList;
            }
            set { SetProperty(ref _WallHeightList, value); }
        }
        #endregion

        #region Helper
        public string ChartHelperTittle { get; } = StartValues.ChartHelperTittle;
        private int _HelperMin = 0;
        public int HelperMin
        {
            get { return _HelperMin; }
            set { SetProperty(ref _HelperMin, value); }
        }
        private int _HelperMax = 100;
        public int HelperMax
        {
            get { return _HelperMax; }
            set { SetProperty(ref _HelperMax, value); }
        }

        private int _TempHeat = 0;
        public int TempHeat
        {
            get { return _TempHeat; }
            set { SetProperty(ref _TempHeat,  value); }
        }
        private int _TempConditioner = 0;
        public int TempConditioner
        {
            get { return _TempConditioner; }
            set { SetProperty(ref _TempConditioner,  value); }
        }
        private int _TempNow = 19;
        public int TempNow
        {
            get { return _TempNow; }
            set { SetProperty(ref _TempNow, value); }
        }
        #endregion

        #region Time
        private Task TaskClock;
        public int _ClockSpeed = StartValues.TimeSpeed;

        private TimeSpan _Time = new TimeSpan(0, 0, 0, 0);
        public string Time
        {
            get { return _Time.Days.ToString() + "D " + _Time.Hours.ToString() + "H"; }
            set
            {
                var TimeNow = new TimeSpan((int)_Time.TotalHours + Convert.ToInt32(value), 0, 0);
                if (TimeNow.TotalHours >= 0)
                    SetProperty(ref _Time, TimeNow);
            }
        }

        public DelegateCommand<object> ClockAddCommand { get; private set; }
        public DelegateCommand<object> ClockSpeedCommand { get; private set; }
        #endregion
        
        SystemWnioskowania x = new SystemWnioskowania();

        //konstruktor,  dodanie command(cos ala event)
        public ViewModel()
        {
            ClockSpeedCommand = new DelegateCommand<object>(Execute_ClockSpeed);
            TaskClock = new Task(Clock_Increment_Task);
            TaskClock.Start();
        }

        //zamiana parametru z kliknietego buttonu na tryb szybkosci
        private void Execute_ClockSpeed(object speed)
        {
            _ClockSpeed = Int32.Parse(speed.ToString());
        }
        //wywoływanie metod w tasku oraz usypianie taska wg zadanego trybu
        private void Clock_Increment_Task()
        {
            while (true)
            {
                switch (_ClockSpeed)
                {
                    default:
                        Thread.Sleep(1000);
                        break;
                    case 1:
                        TaskMethodHelper(StartValues.TimeSpeed1);
                        break;
                    case 2:
                        TaskMethodHelper(StartValues.TimeSpeed2);
                        break;
                    case 3:
                        TaskMethodHelper(StartValues.TimeSpeed3);
                        break;
                }
            }
        }
        //imitacja czasu
        private void TaskMethodHelper(int sleep)
        {
            Time = "1";
            try
            {
                Application.Current.Dispatcher.Invoke((Action)(() =>
                {
                    //dodanie kolejnej temp na wykresie pogody
                    Line_Weather.AddNext();
                    //wyciągniecie godziny na podstawie wykresu pogody;
                    int z = Line_Weather[(Line_Weather.Count - 1)].X % 24;
                    //wyliczanie środkow ciezkosci dla klimy i pieca (wyniki dostepne w geterach)
                    x.Rozmywanie(Line_Heat, Line_Conditioner, Line_Temp, TempNow, Line_WorkHours, 9);

                    //wyliczanie temp pieca i klimatyzacji na podstawie środka ciezkosci
                    ObliczTempPieca(x.srodekCiezkosciOgrzewanie);
                    ObliczTempKlimy(x.srodekCiezkosciKlimatyzacja);

                    //wyliczanie zmiany temp w pomieszczeniu
                    TempUpdate(TempNow, TempHeat,TempConditioner, Line_Weather[(Line_Weather.Count - 1)].Y);
                    
                    //przesuwanie wykresu pogody
                    if (_Line_Weather.Count >= StartValues.HoursOnChart)
                    {
                        WeatherXmin ++;
                        WeatherXmax ++;
                    }
                }));
            }
            catch (System.NullReferenceException)
            { }
            Thread.Sleep(sleep);
        }
        private void ObliczTempPieca(double x)
        {
            int result = ((int)Math.Round(TempExpected + StartValues.maxTempHeat * x / 100));
            if (result > StartValues.maxTempHeat) result = StartValues.maxTempHeat;
            TempHeat = result;

        }
        private void ObliczTempKlimy(double x)
        {
            int result = ((int)Math.Round(TempExpected - StartValues.minTempConditioner * x / 100));
            if (result < StartValues.minTempConditioner) result = StartValues.minTempConditioner;
            TempConditioner = result;
        }
        public void TempUpdate(int TNow,int THeat,int TConditioner,int TWeather)
        {
            tutajwzorydziergaj
            //(cos(lnx))^4*50 temp  
            //  10          20          -   10                   
            int diff = THeat - TNow;
            if (diff > 0)
            {
                TempNow += TempHeat;
            }
            diff = TNow - TConditioner;
            if (diff > 0)
            {
                TempNow -= TempConditioner;

            }
        }

    }

}