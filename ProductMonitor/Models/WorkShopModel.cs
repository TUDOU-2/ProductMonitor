using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 车间数据模型
    /// </summary>
    class WorkShopModel
    {
        public string WorkShopName { get; set; } // 车间名称
        public int WorkingCount { get; set; } // 作业机台数量
        public int WaitCount { get; set; } // 待机机台数量
        public int WrongCount { get; set; } // 故障机台数量
        public int StopCount { get; set; } // 停机机台数量
        public int TotalCount // 总机台数量
        {
            get
            {
                return WorkingCount + WaitCount + WrongCount + StopCount;
            }
        }
    }
}
