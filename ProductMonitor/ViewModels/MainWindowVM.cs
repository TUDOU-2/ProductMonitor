using ProductMonitor.Models;
using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public List<RaderModel> _RaderList; // 雷达图数据列表
        private List<StuffOutWorkModel> _StuffOutWorkList; // 员工缺岗数据列表
        private List<WorkShopModel> _WorkShopList; // 车间数据列表
        private List<MachineModel> _MachineList; // 机台数据列表

        public List<MachineModel> MachineList
        {
            get { return _MachineList; }
            set
            {
                _MachineList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineList"));
            }
        }


        public List<WorkShopModel> WorkShopList
        {
            get { return _WorkShopList; }
            set
            {
                _WorkShopList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("WorkShopList"));
            }
        }


        public List<StuffOutWorkModel> StuffOutWorkList
        {
            get { return _StuffOutWorkList; }
            set
            {
                _StuffOutWorkList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("StuffOutWorkList"));
            }
        }

        public List<RaderModel> RaderList
        {
            get { return _RaderList; }
            set
            {
                _RaderList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("RaderList"));
            }
        }

        public List<DeviceModel> DeviceList
        {
            get { return _DeviceList; }
            set
            {
                _DeviceList = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("DeviceList"));
            }
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
            GetRaderData();
            GetStuffOutWorkData();
            GetWorkShopData();
            GetMachineData();
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

        private void GetRaderData() // 从数据库中获取雷达图数据
        {
            RaderList = new List<RaderModel>();
            RaderList.Add(new RaderModel { ItemName = "排烟风机", Value = 90 });
            RaderList.Add(new RaderModel { ItemName = "客梯", Value = 30 });
            RaderList.Add(new RaderModel { ItemName = "供水机", Value = 34.89 });
            RaderList.Add(new RaderModel { ItemName = "喷淋水泵", Value = 69.59 });
            RaderList.Add(new RaderModel { ItemName = "稳压设备", Value = 20 });
        }

        private void GetStuffOutWorkData() // 从数据库中获取员工缺岗数据
        {
            StuffOutWorkList = new List<StuffOutWorkModel>();
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "张晓婷", Position = "技术员", OutWorkCount = 123 });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "李晓", Position = "操作员", OutWorkCount = 23 });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "王克俭", Position = "检验工", OutWorkCount = 134 });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "陈家栋", Position = "统计员", OutWorkCount = 143 });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "杨过", Position = "技术员", OutWorkCount = 12 });
        }

        private void GetWorkShopData() // 从数据库中获取车间数据
        {
            WorkShopList = new List<WorkShopModel>();
            WorkShopList.Add(new WorkShopModel { WorkShopName = "贴片车间", WorkingCount = 44, WaitCount = 32, WrongCount = 8, StopCount = 0 });
            WorkShopList.Add(new WorkShopModel { WorkShopName = "DIP车间", WorkingCount = 32, WaitCount = 20, WrongCount = 8, StopCount = 0 });
            WorkShopList.Add(new WorkShopModel { WorkShopName = "组装车间", WorkingCount = 56, WaitCount = 32, WrongCount = 10, StopCount = 10 });
            WorkShopList.Add(new WorkShopModel { WorkShopName = "注塑车间", WorkingCount = 80, WaitCount = 68, WrongCount = 8, StopCount = 15 });
        }

        private void GetMachineData()
        {
            MachineList = new List<MachineModel>();
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int plan = random.Next(100, 1000); // 随机产量
                int complete = random.Next(0, plan); // 随机完成量
                MachineList.Add(new MachineModel
                {
                    MachineName = $"机台{i + 1}",
                    Status = "作业中",
                    PlanCount = plan,
                    FinishedCount = complete,
                    OrderNo = "H202412345678"
                });
            }
        }
    }
}
