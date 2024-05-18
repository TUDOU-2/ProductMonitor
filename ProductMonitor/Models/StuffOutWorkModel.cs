using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 缺岗数据模型
    /// </summary>
    class StuffOutWorkModel
    {
        public string StuffName { get; set; } // 员工姓名
        public string Position { get; set; } // 岗位
        public int OutWorkCount { get; set; } // 缺岗次数
        public int ShowWidt // 显示宽度
        {
            get
            {
                return OutWorkCount * 70 / 100;
            }
        }
    }
}
