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
    public class AP_ArgricultureLiveController : BaseController
    {
        //
        // GET: /AP_ArgricultureLive/CaculateArgricultureLivePullution

        public ActionResult IndexAP_ArgricultureLive()
        {
            return View();
        }
        public ActionResult ArgricultureLivePullutionReport() {
            return View();
        }
        public ActionResult CaculateArgricultureLivePullution()
        {
            using (var ctx = GetDbContext())
            {
                var ArgricultureLive = ctx.Set<AP_ArgricultureLive>();
                var CoeffiectientRule = ctx.Set<AP_LiveStockBreedingCoeffecient>();
                double NofLifePullution = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.PullutionSource == DicTypeHelperr.LifePullution).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofLifePullution = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.PullutionSource == DicTypeHelperr.LifePullution).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfLifePullution = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.PullutionSource == DicTypeHelperr.LifePullution).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofBodyOutput = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.PullutionSource == DicTypeHelperr.BodyOutput).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofBodyOutput = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.PullutionSource == DicTypeHelperr.BodyOutput).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfBodyOutput = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.PullutionSource == DicTypeHelperr.BodyOutput).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();


                double RuralPopulation = ArgricultureLive.Where(c => c.RuralPopulation.HasValue).Sum(c => c.RuralPopulation.Value);

                double sumOfN = RuralPopulation * NofLifePullution + RuralPopulation * NofBodyOutput;
                double sumOfP = RuralPopulation * PofLifePullution + RuralPopulation * PofBodyOutput;
                double sumOfCod = RuralPopulation * CoOfLifePullution + RuralPopulation * CoOfBodyOutput;
                return Json(new { Result = true, Entity = new PullutionReportModel { OutPutOfCo = sumOfCod, OutPutOfN = sumOfN, OutPutOfP = sumOfP, PullutionType = (int)PullutionTypeEnum.ArgricultureLive } }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetArgricultureLive(int Year)
        {
            var ctx = GetDbContext();
            var PlantNoPointSource = ctx.Set<AP_ArgricultureLive>().ToList();
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
