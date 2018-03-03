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
    public class AP_AqualCultureController : BaseController
    {
        //
        // GET: /AP_AqualCulture/

        public ActionResult IndexAP_AqualCulture()
        {
            return View();
        }
        public ActionResult AP_AqualCultureReport()
        {
            return View();
        }
        public ActionResult CaculateAqualCulturePullution() {
            using (var ctx = GetDbContext())
            {
                var LiveStockBreeding = ctx.Set<AP_AqualCulture>();
                var CoeffiectientRule = ctx.Set<AP_LiveStockBreedingCoeffecient>();
                double NofFreshFish = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.FreshWaterFish).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofFreshFish = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.FreshWaterFish).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfFreshFish = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.FreshWaterFish).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double Nofshrimp = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.shrimp).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double Pofshrimp = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.shrimp).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfshrimp = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.shrimp).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofCrab = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.Crab).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofCrab = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.Crab).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfCrab = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.Crab).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double Nofshell = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.shell).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double Pofshell = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.shell).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfshell = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.NetBoxCulture && c.PullutionSource == DicTypeHelperr.shell).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();


                double sumOfBigStock = LiveStockBreeding.Where(c => c.FreshWaterFish.HasValue).Sum(c => c.FreshWaterFish.Value);
                double sumOfPig = LiveStockBreeding.Where(c => c.Shrimp.HasValue).Sum(c => c.Shrimp.Value);
                double sumOfSheep = LiveStockBreeding.Where(c => c.Crab.HasValue).Sum(c => c.Crab.Value);
                double sumOfAnimal = LiveStockBreeding.Where(c => c.ShellFish.HasValue).Sum(c => c.ShellFish.Value);
                double sumOfN = sumOfBigStock * NofFreshFish + sumOfPig * Nofshrimp + sumOfSheep * NofCrab + sumOfAnimal * Nofshell;
                double sumOfP = sumOfBigStock * PofFreshFish + sumOfPig * Pofshrimp + sumOfSheep * PofCrab + sumOfAnimal * Pofshell;
                double sumOfCod = sumOfBigStock * CoOfFreshFish + sumOfPig * CoOfshrimp + sumOfSheep * CoOfCrab + sumOfAnimal * CoOfshell;
                return Json(new { Result = true, Entity = new PullutionReportModel { OutPutOfCo = sumOfCod, OutPutOfN = sumOfN, OutPutOfP = sumOfP, PullutionType = (int)PullutionTypeEnum.LiveStockBreeding } }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAP_AqualCulture(int Year)
        {
            var ctx = GetDbContext();
            var PlantNoPointSource = ctx.Set<AP_AqualCulture>().ToList();
            var area = ctx.Set<AP_Area>().ToList();
            var query = from a in PlantNoPointSource
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
    }
}
