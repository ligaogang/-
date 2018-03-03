using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AugricultureNonPointSourcePollution.Models
{
    //==============================================================
    //  作者：李高钢  (735450681@qq.com)
    //  时间：2018/2/11/周日 19:52:46
    //  文件名：ParticipateTypeEnum
    //  版本：V1.0.1  
    //  说明： 
    //  修改者：李高钢
    //  修改说明： 
    //==============================================================
    public enum PullutionTypeEnum
    {
        /// <summary>
        /// 水产养殖
        /// </summary>
        AqualCulture=0x00000001,
        /// <summary>
        /// 农村生活
        /// </summary>
        ArgricultureLive=0x00000010,
        /// <summary>
        /// 畜禽养殖
        /// </summary>
        LiveStockBreeding=0x00000100,
        /// <summary>
        /// 种植污染
        /// </summary>
        PlantNoPointSource=0x00001000,
        /// <summary>
        /// 池塘养殖
        /// </summary>
        pondCulture = 0x00010000,
        /// <summary>
        /// 网箱养殖
        /// </summary>
        NetBoxCulture = 0x00100000,

    }
}