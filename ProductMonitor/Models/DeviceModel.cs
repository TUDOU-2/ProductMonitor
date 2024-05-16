using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 设备数据模型
    /// </summary>
    class DeviceModel
    {
        public string DeviceItem { get; set; } // 设备监控项
        public double Value { get; set; } // 值

    }
}
