using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AugricultureNonPointSourcePollution.Models
{
    //==============================================================
    //  作者：李高钢  (735450681@qq.com)
    //  时间：2018/3/3/周六 14:47:12
    //  文件名：PullutionReportModel
    //  版本：V1.0.1  
    //  说明： 
    //  修改者：李高钢  
    //  修改说明： 
    //==============================================================
    public class PullutionReportModel  
    {
        public int PullutionType { get; set; }

        public double OutPutOfN { get; set; }

        public double OutPutOfP { get; set; }

        public double OutPutOfCo { get; set; }
    }
}