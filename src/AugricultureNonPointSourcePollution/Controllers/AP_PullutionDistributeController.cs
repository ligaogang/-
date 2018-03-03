using AugricultureNonPointSourcePollution.Models;
using Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AugricultureNonPointSourcePollution.Controllers
{
    public class AP_PullutionDistributeController : BaseController
    {
        //
        // GET: /AP_PullutionDistribute/NDistribute

        public ActionResult IndexAP_PullutionDistribute()
        {
            return View();
        }
        public ActionResult NDistribute() {
            using (var ctx = GetDbContext()) {
                var SumPullution = ctx.Set<SumPullution>();
                PullutionDistribute NDistribute = new PullutionDistribute();
                NDistribute.AqualCulture = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.AqualCulture&&c.NSum.HasValue).Select(c => c.NSum.Value).FirstOrDefault();
                NDistribute.ArgricultureLive = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.NSum.HasValue).Select(c => c.NSum.Value).FirstOrDefault();
                NDistribute.LiveStockBreeding = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.LiveStockBreeding && c.NSum.HasValue).Select(c => c.NSum.Value).FirstOrDefault();
                NDistribute.PlantNoPointSource = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.NSum.HasValue).Select(c => c.NSum.Value).FirstOrDefault();
                return Json(new { Result=true,Entity=NDistribute},JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PDistribute() {
            using (var ctx = GetDbContext())
            {
                var SumPullution = ctx.Set<SumPullution>();
                PullutionDistribute NDistribute = new PullutionDistribute();
                NDistribute.AqualCulture = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.AqualCulture && c.PSum.HasValue).Select(c => c.PSum.Value).FirstOrDefault();
                NDistribute.ArgricultureLive = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.PSum.HasValue).Select(c => c.PSum.Value).FirstOrDefault();
                NDistribute.LiveStockBreeding = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.LiveStockBreeding && c.PSum.HasValue).Select(c => c.PSum.Value).FirstOrDefault();
                NDistribute.PlantNoPointSource = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PSum.HasValue).Select(c => c.PSum.Value).FirstOrDefault();
                return Json(new { Result = true, Entity = NDistribute }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CodDistribute()
        {
            using (var ctx = GetDbContext())
            {
                var SumPullution = ctx.Set<SumPullution>();
                PullutionDistribute NDistribute = new PullutionDistribute();
                NDistribute.AqualCulture = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.AqualCulture && c.CoSum.HasValue).Select(c => c.CoSum.Value).FirstOrDefault();
                NDistribute.ArgricultureLive = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.ArgricultureLive && c.CoSum.HasValue).Select(c => c.CoSum.Value).FirstOrDefault();
                NDistribute.LiveStockBreeding = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.LiveStockBreeding && c.CoSum.HasValue).Select(c => c.CoSum.Value).FirstOrDefault();
                NDistribute.PlantNoPointSource = SumPullution.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.CoSum.HasValue).Select(c => c.CoSum.Value).FirstOrDefault();
                return Json(new { Result = true, Entity = NDistribute }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
