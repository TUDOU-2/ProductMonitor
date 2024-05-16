using ProductMonitor.Models;
using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProductMonitor.ViewModels
{
    class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private DispatcherTimer timer; // 计时器
        private UserControl _MonitorUC; // 监控用户控件
        private string _TimeStr; // 时间字符串
        private string _DateStr; // 日期字符串
        private string _DayOfWeekStr; // 星期字符串
        private string _MachineCount = "0298"; // 机器数量
        private string _ProductCount = "1643"; // 产品数量
        private string _BadCount = "0403"; // 不良品数量
        private List<EnviromentModel> _EnviromentList; // 环境数据列表
        private List<AlarmModel> _AlarmList; // 报警数据列表
        private List<DeviceModel> _DeviceList; // 设备数据列表

        public List<DeviceModel> DeviceList
        {
            get { return _DeviceList; }
            set { _DeviceList = value; }
        }


        public List<AlarmModel> AlarmList
        {
            get { return _AlarmList; }
            set
            {
                _AlarmList = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
            }
        }


        public List<EnviromentModel> EnviromentList
        {
            get { return _EnviromentList; }
            set
            {
                _EnviromentList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
            }
        }

        public string BadCount
        {
            get { return _BadCount; }
            set
            {
                _BadCount = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
            }
        }

        public string ProductCount
        {
            get { return _ProductCount; }
            set
            {
                _ProductCount = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
            }
        }

        public string MachineCount
        {
            get { return _MachineCount; }
            set
            {
                _MachineCount = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
            }
        }

        public string TimeStr
        {
            get { return _TimeStr; }
            set
            {
                _TimeStr = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TimeStr"));
            }
        }

        public string DateStr
        {
            get { return _DateStr; }
            set
            {
                _DateStr = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DateStr"));
            }
        }

        public string DayOfWeekStr
        {
            get { return _DayOfWeekStr; }
            set
            {
                _DayOfWeekStr = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DayOfWeekStr"));
            }
        }

        public UserControl MonitorUC
        {
            get
            {
                if (_MonitorUC == null)
                {
                    _MonitorUC = new MonitorUC();
                }
                return _MonitorUC;
            }
            set
            {
                _MonitorUC = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MonitorUC"));
            }
        }

        public MainWindowVM()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            GetEnviromentData();
            GetAlarmData();
            GetDeviceData();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeStr = DateTime.Now.ToString("HH:mm");
            DateStr = DateTime.Now.ToString("yyyy/M/d");
            DayOfWeekStr = DateTime.Now.ToString("dddd");
        }
        private void GetEnviromentData() // 从数据库中获取环境数据
        {
            EnviromentList = new List<EnviromentModel>();
            EnviromentList.Add(new EnviromentModel { EnItemName = "光照(Lux)", EnItemValue = 123 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "噪音(db)", EnItemValue = 55 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "温度(℃)", EnItemValue = 80 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "湿度(%)", EnItemValue = 43 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "PM2.5(m³)", EnItemValue = 20 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "硫化氢(PPM)", EnItemValue = 15 });
            EnviromentList.Add(new EnviromentModel { EnItemName = "氮气()", EnItemValue = 18 });
        }

        private void GetAlarmData() // 从数据库中获取报警数据
        {
            AlarmList = new List<AlarmModel>();
            AlarmList.Add(new AlarmModel { Num = "01", Msg = "设备温度过高", Time = DateTime.Now, Duration = 7 });
            AlarmList.Add(new AlarmModel { Num = "02", Msg = "车间温度过高", Time = DateTime.Now, Duration = 7 });
            AlarmList.Add(new AlarmModel { Num = "03", Msg = "设备转速过快", Time = DateTime.Now, Duration = 7 });
            AlarmList.Add(new AlarmModel { Num = "04", Msg = "设备气压偏低", Time = DateTime.Now, Duration = 7 });
        }

        private void GetDeviceData() // 从数据库中获取设备数据
        {
            DeviceList = new List<DeviceModel>();
            DeviceList.Add(new DeviceModel { DeviceItem = "电能(Kw.h)", Value = 60.8 });
            DeviceList.Add(new DeviceModel { DeviceItem = "电压(V)", Value = 390 });
            DeviceList.Add(new DeviceModel { DeviceItem = "电流(A)", Value = 5 });
            DeviceList.Add(new DeviceModel { DeviceItem = "压差(kpa)", Value = 13 });
            DeviceList.Add(new DeviceModel { DeviceItem = "温度(℃)", Value = 36 });
            DeviceList.Add(new DeviceModel { DeviceItem = "振动(mm/s)", Value = 4.1 });
            DeviceList.Add(new DeviceModel { DeviceItem = "转速(r/min)", Value = 2600 });
            DeviceList.Add(new DeviceModel { DeviceItem = "气压(kpa)", Value = 0.5 });
        }
    }
}
