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
    public class AP_PlantNoPointSourceController : BaseController
    {
        //
        // GET: /AP_PlantNoPointSource/

        public ActionResult IndexAP_PlantNoPointSource()
        {
            return View();
        }
        public ActionResult PlantNoPointSourceReport() {
            return View();
        }
        public ActionResult FetilizerReport() {
            return View();
        }
        public ActionResult CalulateFetilizerPullution() {
            using (var ctx = GetDbContext())
            {
                var LiveStockBreeding = ctx.Set<AP_PlantNoPointSource>();
                var CoeffiectientRule = ctx.Set<AP_LiveStockBreedingCoeffecient>();
                double NofPfertilizer = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Pfertilizer).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofPfertilizer = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Pfertilizer).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfPfertilizer = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Pfertilizer).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofNfertilizer = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Nfertilizer).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofNfertilizer = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Nfertilizer).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfNfertilizer = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Nfertilizer).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();



                double sumOfPhosPhticFertilizer = LiveStockBreeding.Where(c => c.PhosPhticFertilizer.HasValue).Sum(c => c.PhosPhticFertilizer.Value);
                double sumOfNitrogenours = LiveStockBreeding.Where(c => c.Nitrogenours.HasValue).Sum(c => c.Nitrogenours.Value);


                double sumOfN = sumOfPhosPhticFertilizer * NofPfertilizer  + sumOfNitrogenours * NofNfertilizer;
                double sumOfP = sumOfPhosPhticFertilizer * PofPfertilizer +   sumOfNitrogenours * NofNfertilizer;
                double sumOfCod = 0;
                return Json(new { Result = true, Entity = new PullutionReportModel { OutPutOfCo = sumOfCod, OutPutOfN = sumOfN, OutPutOfP = sumOfP, PullutionType = (int)PullutionTypeEnum.LiveStockBreeding } }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CaculatePlantNoPointSourcePullution()
        {
            using (var ctx = GetDbContext())
            {
                var LiveStockBreeding = ctx.Set<AP_PlantNoPointSource>();
                var CoeffiectientRule = ctx.Set<AP_LiveStockBreedingCoeffecient>();
                double Nofsorghum = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.sorghum).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double Pofsorghum = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.sorghum).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfsorghum = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.sorghum).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofRice = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Rice).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofRice = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Rice).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfRice = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Rice).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofCorn = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Corn).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofCorn = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Corn).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfCorn = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Corn).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofWheat = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Wheat).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofWheat = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Wheat).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfWheat = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Wheat).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofBean = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Bean).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofBean = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Bean).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfBean = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Bean).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofCotton = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Cotton).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofCotton = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Cotton).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfCotton = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Cotton).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();


                double NofOilSeed = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.OilSeed).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofOilSeed = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.OilSeed).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfOilSeed = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.OilSeed).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofPinut = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Pinut).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofPinut = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Pinut).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfPinut = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Pinut).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();

                double NofPotato = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Potato).ToList().Select(c => { if (c.NCoefficient.HasValue) return c.NCoefficient.Value; else return 0; }).FirstOrDefault();
                double PofPotato = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Potato).ToList().Select(c => { if (c.PCoefficient.HasValue) return c.PCoefficient.Value; else return 0; }).FirstOrDefault();
                double CoOfPotato = CoeffiectientRule.Where(c => c.PullutionType == (int)PullutionTypeEnum.PlantNoPointSource && c.PullutionSource == DicTypeHelperr.Potato).ToList().Select(c => { if (c.CodCoefficient.HasValue) return c.CodCoefficient.Value; else return 0; }).FirstOrDefault();


                double sumOfSorghum = LiveStockBreeding.Where(c => c.Sorghum.HasValue).Sum(c => c.Sorghum.Value);
                double sumOfRice = LiveStockBreeding.Where(c => c.Rice.HasValue).Sum(c => c.Rice.Value);
                double sumOfMize = LiveStockBreeding.Where(c => c.Mize.HasValue).Sum(c => c.Mize.Value);
                double sumOfWheat = LiveStockBreeding.Where(c => c.Wheat.HasValue).Sum(c => c.Wheat.Value);

                double sumOfBean = LiveStockBreeding.Where(c => c.Bean.HasValue).Sum(c => c.Bean.Value);
                double sumOfCottom = LiveStockBreeding.Where(c => c.Cottom.HasValue).Sum(c => c.Cottom.Value);

                double sumOfOilseedRaoe = LiveStockBreeding.Where(c => c.OilseedRaoe.HasValue).Sum(c => c.OilseedRaoe.Value);
                double sumOfPinut = LiveStockBreeding.Where(c => c.Pinut.HasValue).Sum(c => c.Pinut.Value);

                double sumOfPotato = LiveStockBreeding.Where(c => c.Potato.HasValue).Sum(c => c.Potato.Value);

                double sumOfN = sumOfSorghum * Nofsorghum + sumOfRice * NofRice + sumOfMize * NofCorn + sumOfWheat * NofWheat + sumOfBean * NofBean + sumOfCottom * NofCotton + sumOfOilseedRaoe * NofOilSeed + sumOfPinut * NofPinut + sumOfPotato*NofPotato;
                double sumOfP = sumOfSorghum * Pofsorghum + sumOfRice * PofRice + sumOfMize * PofCorn + sumOfWheat * PofWheat + sumOfBean * PofBean + sumOfCottom * PofCotton + sumOfOilseedRaoe * PofOilSeed + sumOfPinut * PofPinut + sumOfPotato * PofPotato;
                double sumOfCod = sumOfSorghum * CoOfsorghum + sumOfRice * CoOfRice + sumOfMize * CoOfCorn + sumOfWheat * CoOfWheat + sumOfBean * CoOfBean + sumOfCottom * CoOfCotton + sumOfOilseedRaoe * CoOfOilSeed + sumOfPinut * CoOfPinut + sumOfPotato * CoOfPotato;
                return Json(new { Result = true, Entity = new PullutionReportModel { OutPutOfCo = sumOfCod, OutPutOfN = sumOfN, OutPutOfP = sumOfP, PullutionType = (int)PullutionTypeEnum.LiveStockBreeding } }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetAP_PlantNoPointSourceList(int Year)
        {
            var ctx = GetDbContext();
            var PlantNoPointSource = ctx.Set<AP_PlantNoPointSource>().ToList();
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
