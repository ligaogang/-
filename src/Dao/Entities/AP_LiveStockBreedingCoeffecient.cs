using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    //==============================================================
    //  作者：李高钢  (735450681@qq.com)
    //  时间：2018/3/3/周六 11:17:45
    //  文件名：AP_LiveStockBreedingCoeffecient
    //  版本：V1.0.1  
    //  说明： 
    //  修改者：李高钢
    //  修改说明： 
    //==============================================================
    public partial class AP_LiveStockBreedingCoeffecient
    {
       [DataMember]
       public string PullutionSourceName { get; set; }
         [DataMember]
       public string PullutionTypeName { get; set; }
    }
}
