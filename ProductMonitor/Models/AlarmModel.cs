using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 报警项数据模型
    /// </summary>
    class AlarmModel
    {
        public string Num { get; set; } // 报警编号
        public string Msg { get; set; } // 报警信息
        public DateTime Time { get; set; } // 报警时间
        public int Duration { get; set; } // 报警持续时间
    }
}
