using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 机台数据模型
    /// </summary>
    internal class MachineModel
    {
        public string MachineName { get; set; } // 机台名称
        public string Status { get; set; } // 状态
        public int PlanCount { get; set; } // 计划产量
        public int FinishedCount { get; set; } // 完成产量
        public string OrderNo { get; set; } // 订单号
        public double Percent // 完成百分比
        {
            get
            {
                return FinishedCount * 100.0 / PlanCount;
            }
        }
    }
}
