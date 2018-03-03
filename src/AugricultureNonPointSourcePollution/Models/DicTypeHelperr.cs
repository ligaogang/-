using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AugricultureNonPointSourcePollution.Models
{
    //==============================================================
    //  作者：李高钢  (735450681@qq.com)
    //  时间：2018/3/3/周六 11:54:35
    //  文件名：DicTypeHelperr
    //  版本：V1.0.1  
    //  说明： 
    //  修改者：李高钢
    //  修改说明： 
    //==============================================================
    public static class DicTypeHelperr
    {
        /// <summary>
        /// 生活污水
        /// </summary>
        public static Guid LifePullution = Guid.Parse("29CDBE7B-2669-4AEF-A60F-4A6BD1B127F3");
        /// <summary>
        /// 人体排泄
        /// </summary>
        public static Guid BodyOutput = Guid.Parse("58887A46-ECE3-46C0-B864-8CDEC65AF695");
        /// <summary>
        /// 淡水鱼类
        /// </summary>
        public static Guid FreshWaterFish = Guid.Parse("0C1079BC-97A5-4E60-BF1A-CE2A521A785D");
        /// <summary>
        /// 虾
        /// </summary>
        public static Guid shrimp = Guid.Parse("678D01AA-1AFF-40C7-9F27-4586920D5874");
        /// <summary>
        /// 河蟹
        /// </summary>
        public static Guid Crab = Guid.Parse("B2593029-1AE9-4824-BA5E-F3B05243BA88");
        /// <summary>
        /// 贝壳
        /// </summary>
        public static Guid shell = Guid.Parse("582E4EB2-170B-4C87-9D66-79AAF6FCCD82");
        /// <summary>
        /// 大牲畜
        /// </summary>
        public static Guid BigLiveStock = Guid.Parse("7249FF6D-53AC-40EE-BA50-6127D82B1345");
        /// <summary>
        /// 猪
        /// </summary>
        public static Guid Pig = Guid.Parse("C1C7FE99-1D33-406C-8474-8EC57BFBD59F");
        /// <summary>
        /// 羊
        /// </summary>
        public static Guid sheep = Guid.Parse("5737A61A-868C-4741-871A-1D35A551054D");
        /// <summary>
        /// 禽类
        /// </summary>
        public static Guid Birds = Guid.Parse("9433999B-B5EF-4605-A230-5CD02989C08F");
        /// <summary>
        /// 稻谷
        /// </summary>
        public static Guid Rice = Guid.Parse("9433999B-B5EF-4605-A230-5CD02989C08F");
        /// <summary>
        /// 玉米
        /// </summary>
        public static Guid Corn = Guid.Parse("648401B1-D20D-45A8-9118-F2B110443B34");
        /// <summary>
        /// 小麦
        /// </summary>
        public static Guid Wheat = Guid.Parse("AD782C58-6AEA-4D12-B3F5-14205EB3CBDE");
        /// <summary>
        /// 高粱
        /// </summary>
        public static Guid sorghum = Guid.Parse("0665A4FA-1924-4218-AE2C-F7427CDB0469");
        /// <summary>
        /// 大豆
        /// </summary>
        public static Guid Bean = Guid.Parse("A544E631-FD0C-44FC-81E1-A45C32FE0740");
        /// <summary>
        /// 棉花
        /// </summary>
        public static Guid Cotton = Guid.Parse("85FC2D9E-1D81-4DAD-9404-D6E02B3AFBD3");
        /// <summary>
        /// 油菜
        /// </summary>
        public static Guid OilSeed = Guid.Parse("82C67ACA-B6E6-45DD-9B6D-476A42967F61");
        /// <summary>
        /// 花生
        /// </summary>
        public static Guid Pinut = Guid.Parse("5D508BDE-010E-46E5-8B70-017FBBB6A517");
        /// <summary>
        /// 薯类
        /// </summary>
        public static Guid Potato = Guid.Parse("DD92F897-07DB-4D97-9300-D4F3E0B9F8BE");
        /// <summary>
        /// 氮肥
        /// </summary>
        public static Guid Nfertilizer = Guid.Parse("F230E207-3EC2-4C16-9568-56FC0D492C2D");
        /// <summary>
        /// 磷肥
        /// </summary>
        public static Guid Pfertilizer = Guid.Parse("81A846BA-410E-483B-BFB4-EF7F644B482D");
    }
}