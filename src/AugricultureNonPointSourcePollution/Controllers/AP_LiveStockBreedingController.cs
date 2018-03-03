using AugricultureNonPointSourcePollution.Models;
using Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AugricultureNonPointSourcePollution.Controllers
{
    public class AP_LiveStockBreedingController : BaseController
    {
        ///AP_LiveStockBreeding/CaculateLiveStockBreedingPullution
        // GET: 

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexAP_LiveStockBreeding() {
            return View();
        }
        public ActionResult EditLiveStockBreeding() {
            return View();
        }
        /// <summary>
        /// 污染系数表
        /// </summary>
        /// <returns></returns>
        public ActionResult LiveStockBreedingCoeffecient() {
            return View();
        }
        public ActionResult LiveStockBreedingPullutionReport() {
            return View();
        }
        public ActionResult CaculateLiveStockBreedingPullution() {
            using (var ctx = GetDbContext()) {
                var LiveStockBreeding = ctx.Set<AP_LiveStockBreeding>();
                var CoeffiectientRule=ctx.Set<AP_LiveStockBreedingCoeffecient>();
                double NofBigStock=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.BigLiveStock).ToList().Select(c=>{if(c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0;}).FirstOrDefault();
                double PofBigStock=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.BigLiveStock).ToList().Select(c=>{if(c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0;}).FirstOrDefault();
                double CoOfBigStock=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.BigLiveStock).ToList().Select(c=>{if(c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0;}).FirstOrDefault();
                
                double NofPig=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.Pig).ToList().Select(c=>{if(c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0;}).FirstOrDefault();
                double PofPig=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.Pig).ToList().Select(c=>{if(c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0;}).FirstOrDefault();
                double CoOfPig=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.Pig).ToList().Select(c=>{if(c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0;}).FirstOrDefault();
                
                double NofSheep=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.sheep).ToList().Select(c=>{if(c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0;}).FirstOrDefault();
                double PofSheep=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.sheep).ToList().Select(c=>{if(c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0;}).FirstOrDefault();
                double CoOfSheep=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.sheep).ToList().Select(c=>{if(c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0;}).FirstOrDefault();
                
                double NofAnimal=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.Birds).ToList().Select(c=>{if(c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0;}).FirstOrDefault();
                double PofAnimal=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.Birds).ToList().Select(c=>{if(c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0;}).FirstOrDefault();
                double CoOfAnimal=CoeffiectientRule.Where(c=>c.PullutionType==(int)PullutionTypeEnum.LiveStockBreeding&&c.PullutionSource==DicTypeHelperr.Birds).ToList().Select(c=>{if(c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0;}).FirstOrDefault();
                
                
                double sumOfBigStock = LiveStockBreeding.Where(c => c.ALargeAnimal.HasValue).Sum(c => c.ALargeAnimal.Value);
                double sumOfPig = LiveStockBreeding.Where(c => c.Pig.HasValue).Sum(c => c.Pig.Value);
                double sumOfSheep = LiveStockBreeding.Where(c => c.sheep.HasValue).Sum(c => c.sheep.Value);
                double sumOfAnimal = LiveStockBreeding.Where(c => c.poultry.HasValue).Sum(c => c.poultry.Value);
                double sumOfN = sumOfBigStock * NofBigStock + sumOfPig * NofPig + sumOfSheep * NofSheep + sumOfAnimal * NofAnimal;
                double sumOfP = sumOfBigStock * PofBigStock + sumOfPig * PofPig + sumOfSheep * PofSheep + sumOfAnimal * PofAnimal;
                double sumOfCod = sumOfBigStock * CoOfBigStock + sumOfPig * CoOfPig + sumOfSheep * CoOfSheep + sumOfAnimal * CoOfAnimal;
                return Json(new { Result = true, Entity = new PullutionReportModel { OutPutOfCo = sumOfCod, OutPutOfN = sumOfN, OutPutOfP = sumOfP, PullutionType = (int)PullutionTypeEnum.LiveStockBreeding } },JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAP_LiveStockBreeding(int Year)
        {
            var ctx = GetDbContext();
            var LiveStockBreeding = ctx.Set<AP_LiveStockBreeding>().ToList();
            var area = ctx.Set<AP_Area>().ToList();
            var query = from a in LiveStockBreeding
                        join b in area on a.Area equals b.Id into b1
                        where a.Year == Year
                        select new
                        {
                            obj = a,
                            areaName = b1.FirstOrDefault().Name
                        };
            foreach (var c in query)
            {
                c.obj.AreaName = c.areaName;
            };
            var result = query.Select(c => c.obj).ToList();
            return Json(new { Entity = result, Result = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetById(Guid Id) {
            using (var ctx = GetDbContext()) {
                var LiveStockBreeding = ctx.Set<AP_LiveStockBreeding>();
                var Entity = LiveStockBreeding.Where(c => c.Id == Id).FirstOrDefault();
                return Json(new { Result=true,Entity=Entity},JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SaveLiveStock(string model)
        {
            using (var ctx = GetDbContext())
            {
                AP_LiveStockBreeding entity = Newtonsoft.Json.JsonConvert.DeserializeObject<AP_LiveStockBreeding>(model);
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                    ctx.Set<AP_LiveStockBreeding>().Add(entity);
                }
                else
                {
                    ctx.Entry(entity).State = EntityState.Modified;
                }
                ctx.SaveChanges();
                return Json(new { Result = true, Content = "保存成功" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteById(Guid Id){
         using (var ctx = GetDbContext()) {
                var LiveStockBreeding = ctx.Set<AP_LiveStockBreeding>();
                var Entity = LiveStockBreeding.Where(c => c.Id == Id).FirstOrDefault();
                ctx.Set<AP_LiveStockBreeding>().Remove(Entity);
                ctx.SaveChanges();
                return Json(new { Result=true,Content="删除成功"},JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetAllLiveStockRule() {
            using (var ctx = GetDbContext()) {
                var LiveStockBreedingCoeffecient = ctx.Set<AP_LiveStockBreedingCoeffecient>();
                var query = (from q in LiveStockBreedingCoeffecient
                            select q).OrderBy(c=>c.PullutionType).ThenBy(c=>c.PullutionSource).ToList();
                query.ForEach(c => {
                    c.PullutionSourceName = PollutionSouce.Where(k => k.Value == c.PullutionSource).Select(k => k.Key).FirstOrDefault();
                    c.PullutionTypeName = PollutionType.Where(k => k.Value == c.PullutionType).Select(k => k.Key).FirstOrDefault();
                });
                return Json(new {Data=query,Result=true },JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SaveOrUpdateLiveStockRule(string model) {
            using(var ctx=GetDbContext()){
            List<AP_LiveStockBreedingCoeffecient> stockRuleList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AP_LiveStockBreedingCoeffecient>>(model);
            stockRuleList.ForEach(c =>
            {
                if (c.Id == Guid.Empty)
                {
                    c.Id = Guid.NewGuid();
                    c.Status = 0;
                    c.Flag = 1;
                    c.Code = "";
                    c.PullutionSource = PollutionSouce[c.PullutionSourceName];
                    ctx.Set<AP_LiveStockBreedingCoeffecient>().Add(c);
                }
                else {
                    c.Status = 0;
                    c.Flag = 1;
                    c.Code = "";
                    c.PullutionSource = PollutionSouce[c.PullutionSourceName];
                    ctx.Entry(c).State = EntityState.Modified;
                }
            });
            ctx.SaveChanges();
            return Json(new { Result=true,Content="保存成功"},JsonRequestBehavior.AllowGet);
            }
        }
        private Dictionary<string, Guid> _pollutionSource;
        public Dictionary<string, Guid> PollutionSouce { get{
        if(_pollutionSource==null){
            _pollutionSource=new Dictionary<string,Guid>();
            _pollutionSource.Add("生活污水", DicTypeHelperr.LifePullution);
            _pollutionSource.Add("人体排泄", DicTypeHelperr.BodyOutput);
            _pollutionSource.Add("淡水鱼类", DicTypeHelperr.FreshWaterFish);
            _pollutionSource.Add("虾", DicTypeHelperr.shrimp);
            _pollutionSource.Add("河蟹", DicTypeHelperr.Crab);
            _pollutionSource.Add("贝类", DicTypeHelperr.sheep);
            _pollutionSource.Add("大牲畜", DicTypeHelperr.BigLiveStock);
            _pollutionSource.Add("猪", DicTypeHelperr.Pig);
            _pollutionSource.Add("羊", DicTypeHelperr.sheep);
            _pollutionSource.Add("禽类", DicTypeHelperr.Birds);
            _pollutionSource.Add("稻谷", DicTypeHelperr.Rice);
            _pollutionSource.Add("玉米", DicTypeHelperr.Corn);
            _pollutionSource.Add("小麦", DicTypeHelperr.Wheat);
            _pollutionSource.Add("高粱", DicTypeHelperr.sorghum);
            _pollutionSource.Add("大豆", DicTypeHelperr.Bean);
            _pollutionSource.Add("棉花", DicTypeHelperr.Cotton);
            _pollutionSource.Add("油菜", DicTypeHelperr.OilSeed);
            _pollutionSource.Add("花生", DicTypeHelperr.Pinut);
            _pollutionSource.Add("薯类", DicTypeHelperr.Potato);
            _pollutionSource.Add("氮肥", DicTypeHelperr.Nfertilizer);
            _pollutionSource.Add("磷肥", DicTypeHelperr.Pfertilizer);
            }
            return _pollutionSource;
        } }

        private Dictionary<string, int> _PollutionType;
        public Dictionary<string, int> PollutionType { get {
            if (_PollutionType == null) {
                _PollutionType = new Dictionary<string, int>();
                _PollutionType.Add("水产养殖",(int)PullutionTypeEnum.AqualCulture);
                _PollutionType.Add("池塘养殖", (int)PullutionTypeEnum.pondCulture);
                _PollutionType.Add("网箱养殖", (int)PullutionTypeEnum.NetBoxCulture);
                _PollutionType.Add("农村生活", (int)PullutionTypeEnum.ArgricultureLive);
                _PollutionType.Add("畜禽养殖", (int)PullutionTypeEnum.LiveStockBreeding);
                _PollutionType.Add("种植污染", (int)PullutionTypeEnum.PlantNoPointSource);
            }
            return _PollutionType;
        } }
    }
}
