using Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AugricultureNonPointSourcePollution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        public ActionResult IndexAP_PlantNoPointSource() {
            return View();
        }
        public ActionResult IndexAP_AqualCulture() {
            return View();
        }
        public ActionResult IndexAP_LiveStockBreeding()
        {
            return View();
        }
        public ActionResult IndexAP_ArgricultureLive()
        {
            return View();
        }
        private string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public ActionResult ImportAreaData() {
            AugricultureNonPointSourcePollutionEntities2 ctx=new AugricultureNonPointSourcePollutionEntities2();
            string[] arealist = new String[] { "朝阳区", "丰台区", "  石景山区", "  海 淀 区", " 房 山 区", "  通 州 区", "  顺 义 区", "  昌 平 区", "  大 兴 区", "  门头沟区", "  怀 柔 区", "  平 谷 区", "密 云 区", "  延 庆 区" };
            foreach (var strItem in arealist)
            {
                var model= new AP_Area
                {
                    Id = Guid.NewGuid(),
                    Code = "",
                    CreateTime = DateTime.Now,
                    Flag = 1,
                    CreateUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                    LastModifyUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                    LastModifyTime = DateTime.Now,
                    ParentId = Guid.Empty,
                    Name = strItem.Replace(" ",""),
                    SeqNo = 0,
                    Status = 0,
                    Type = 3
                };
                ctx.Set<AP_Area>().Add(model);
            }
            ctx.SaveChanges();

            return Content("");
        }
        public ActionResult ImportAP_AqualCulture() {
            using (var ctx = GetDbContext()) {
                var Area=ctx.Set<AP_Area>();
                for (int Year = 2011; Year <= 2016; Year++)
                {
                    string sql = string.Format("select * from 水产养殖{0}", Year);
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    SqlDataReader Reader = comm.ExecuteReader();
                    DataRow row;
                    string tmpValue=string.Empty;
                    while (Reader.Read())
                    {
                        AP_AqualCulture entity = new AP_AqualCulture { 
                        Id=Guid.NewGuid(),
                        Flag = 1,
                         Code="",
                          CreateTime=DateTime.Now,
                        CreateUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                        LastModifyTime=Guid.Empty,
                        LastModifyUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                         SeqNo=0,
                          Status=0,
                           Year=Year,
                     
                        };
                        tmpValue=Reader.GetString(0);
                        if (!string.IsNullOrEmpty(tmpValue))
                            entity.Area = Area.Where(c => c.Name.Equals(tmpValue.Replace(" ", ""))).Select(c => c.Id).FirstOrDefault();
                        var obj=Reader.GetValue(1);
                        if (obj == DBNull.Value)
                             entity.FreshWaterFish =0;
                        else
                            entity.FreshWaterFish = Convert.ToDouble(obj);
                        obj = Reader.GetValue(2);
                        if (obj == DBNull.Value)
                            entity.Crab = 0;
                        else
                            entity.Crab = Convert.ToDouble(obj);
                        obj = Reader.GetValue(3);
                        if (obj == DBNull.Value)
                            entity.Shrimp = 0;
                        else
                            entity.Shrimp = Convert.ToDouble(obj);
                        obj = Reader.GetValue(4);
                        if (obj == DBNull.Value)
                            entity.ShellFish = 0;
                        else
                            entity.ShellFish = Convert.ToDouble(obj);
                        ctx.Set<AP_AqualCulture>().Add(entity);
                    }
                }
                ctx.SaveChanges();
            }
            return Content("success");
        }
        /// <summary>
        /// 生成农村生活数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ImportAP_ArgricutureLive()
        {
            using (var ctx = GetDbContext())
            {
                var Area = ctx.Set<AP_Area>();
              
                   
                for (int Year = 2011; Year <= 2016; Year++)
                {
                    string sql = string.Format("select * from 农村生活{0}", Year);
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                        SqlCommand comm = conn.CreateCommand();
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = sql;
                        SqlDataReader Reader = comm.ExecuteReader();
                        DataRow row;
                        string tmpValue = string.Empty;
                        while (Reader.Read())
                        {
                            AP_ArgricultureLive entity = new AP_ArgricultureLive
                            {
                                Id = Guid.NewGuid(),
                                Flag = 1,
                                Code = "",
                                CreateTime = DateTime.Now,
                                CreateUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                                LastModfyTime = DateTime.Now,
                                LastModifyUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                                SeqNo = 0,
                                Year = Year,

                            };
                            tmpValue = Reader.GetString(0);
                            if (!string.IsNullOrEmpty(tmpValue))
                                entity.Area = Area.Where(c => c.Name.Equals(tmpValue.Replace(" ", ""))).Select(c => c.Id).FirstOrDefault();
                            var obj = Reader.GetValue(1);
                            if (obj == DBNull.Value)
                                entity.RuralPopulation = 0;
                            else
                                entity.RuralPopulation = Convert.ToDouble(obj);
                            obj = Reader.GetValue(2);
                            if (obj == DBNull.Value)
                                entity.ValueOfAgricultureProduct = 0;
                            else
                                entity.ValueOfAgricultureProduct = Convert.ToDouble(obj);

                            ctx.Set<AP_ArgricultureLive>().Add(entity);
                        }
                        conn.Close();
                    }
                    ctx.SaveChanges();
                 
                return Content("success");
            }
        }
        public ActionResult ImportAP_LiveStockBreeding()
        {
            using (var ctx = GetDbContext())
            {
                var Area = ctx.Set<AP_Area>();


                for (int Year = 2011; Year <= 2016; Year++)
                {
                    string sql = string.Format("select * from 畜禽养殖{0}", Year);
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    SqlDataReader Reader = comm.ExecuteReader();
                    DataRow row;
                    string tmpValue = string.Empty;
                    while (Reader.Read())
                    {
                        AP_LiveStockBreeding entity = new AP_LiveStockBreeding
                        {
                            Id = Guid.NewGuid(),
                            Flag = 1,
                            Code = "",
                            CreatetTime = DateTime.Now,
                            CreateUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                            LastModifyTime = DateTime.Now,
                            LastModifyUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                            SeqNo = 0,
                            Year = Year,

                        };
                        tmpValue = Reader.GetString(0);
                        if (!string.IsNullOrEmpty(tmpValue))
                            entity.Area = Area.Where(c => c.Name.Equals(tmpValue.Replace(" ", ""))).Select(c => c.Id).FirstOrDefault();
                        var obj = Reader.GetValue(1);
                        if (obj == DBNull.Value)
                            entity.ALargeAnimal = 0;
                        else
                            entity.ALargeAnimal = Convert.ToDouble(obj);
                        obj = Reader.GetValue(2);
                        if (obj == DBNull.Value)
                            entity.Pig = 0;
                        else
                            entity.Pig = Convert.ToDouble(obj);
                        obj = Reader.GetValue(3);
                        if (obj == DBNull.Value)
                            entity.sheep = 0;
                        else
                            entity.sheep = Convert.ToDouble(obj);

                        obj = Reader.GetValue(4);
                        if (obj == DBNull.Value)
                            entity.poultry = 0;
                        else
                            entity.poultry = Convert.ToDouble(obj);
                        ctx.Set<AP_LiveStockBreeding>().Add(entity);
                    }
                    conn.Close();
                }
                ctx.SaveChanges();

                return Content("success");
            }
        }
        public ActionResult ImportAP_PlantNoPointSource()
        {
            using (var ctx = GetDbContext())
            {
                var Area = ctx.Set<AP_Area>();


                for (int Year = 2011; Year <= 2016; Year++)
                {
                    string sql = string.Format("select * from 种植业源{0}", Year);
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = sql;
                    SqlDataReader Reader = comm.ExecuteReader();
                    DataRow row;
                    string tmpValue = string.Empty;
                    while (Reader.Read())
                    {
                        AP_PlantNoPointSource entity = new AP_PlantNoPointSource
                        {
                            Id = Guid.NewGuid(),
                            Flag = 1,
                            Code = "",
                            CreateTime = DateTime.Now,
                            CreateUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                            LastModifyTime = DateTime.Now,
                            LastModifyUser = Guid.Parse("A50DDFBD-7B30-4BE3-A723-402198D6D7EE"),
                            SeqNo = 0,
                            Year = Year,

                        };
                        tmpValue = Reader.GetString(0);
                        if (!string.IsNullOrEmpty(tmpValue))
                            entity.Area = Area.Where(c => c.Name.Equals(tmpValue.Replace(" ", ""))).Select(c => c.Id).FirstOrDefault();
                        var obj = Reader.GetValue(1);
                        if (obj == DBNull.Value)
                            entity.ChemicalFertilizer = 0;
                        else
                            entity.ChemicalFertilizer = Convert.ToDouble(obj);
                        obj = Reader.GetValue(2);
                        if (obj == DBNull.Value)
                            entity.Nitrogenours = 0;
                        else
                            entity.Nitrogenours = Convert.ToDouble(obj);
                        obj = Reader.GetValue(3);
                        if (obj == DBNull.Value)
                            entity.PhosPhticFertilizer = 0;
                        else
                            entity.PhosPhticFertilizer = Convert.ToDouble(obj);

                        obj = Reader.GetValue(4);
                        if (obj == DBNull.Value)
                            entity.ComplexFertilizer = 0;
                        else
                            entity.ComplexFertilizer = Convert.ToDouble(obj);

                        obj = Reader.GetValue(5);
                        if (obj == DBNull.Value)
                            entity.Vegetable = 0;
                        else
                            entity.Vegetable = Convert.ToDouble(obj);

                        obj = Reader.GetValue(6);
                        if (obj == DBNull.Value)
                            entity.SeedArea = 0;
                        else
                            entity.SeedArea = Convert.ToDouble(obj);

                        obj = Reader.GetValue(7);
                        if (obj == DBNull.Value)
                            entity.GrainOutput = 0;
                        else
                            entity.GrainOutput = Convert.ToDouble(obj);

                        obj = Reader.GetValue(8);
                        if (obj == DBNull.Value)
                            entity.Rice = 0;
                        else
                            entity.Rice = Convert.ToDouble(obj);

                        obj = Reader.GetValue(9);
                        if (obj == DBNull.Value)
                            entity.Millet = 0;
                        else
                            entity.Millet = Convert.ToDouble(obj);

                        obj = Reader.GetValue(10);
                        if (obj == DBNull.Value)
                            entity.Mize = 0;
                        else
                            entity.Mize = Convert.ToDouble(obj);

                        obj = Reader.GetValue(11);
                        if (obj == DBNull.Value)
                            entity.Potato = 0;
                        else
                            entity.Potato = Convert.ToDouble(obj);

                        obj = Reader.GetValue(12);
                        if (obj == DBNull.Value)
                            entity.Sorghum = 0;
                        else
                            entity.Sorghum = Convert.ToDouble(obj);

                        obj = Reader.GetValue(13);
                        if (obj == DBNull.Value)
                            entity.Wheat = 0;
                        else
                            entity.Wheat = Convert.ToDouble(obj);

                        obj = Reader.GetValue(14);
                        if (obj == DBNull.Value)
                            entity.Bean = 0;
                        else
                            entity.Bean = Convert.ToDouble(obj);

                        obj = Reader.GetValue(15);
                        if (obj == DBNull.Value)
                            entity.OilPlant = 0;
                        else
                            entity.OilPlant = Convert.ToDouble(obj);

                        obj = Reader.GetValue(16);
                        if (obj == DBNull.Value)
                            entity.Pinut = 0;
                        else
                            entity.Pinut = Convert.ToDouble(obj);

                        obj = Reader.GetValue(17);
                        if (obj == DBNull.Value)
                            entity.Sesame = 0;
                        else
                            entity.Sesame = Convert.ToDouble(obj);

                        obj = Reader.GetValue(18);
                        if (obj == DBNull.Value)
                            entity.SunFlower = 0;
                        else
                            entity.SunFlower = Convert.ToDouble(obj);

                        obj = Reader.GetValue(19);
                        if (obj == DBNull.Value)
                            entity.Cottom = 0;
                        else
                            entity.Cottom = Convert.ToDouble(obj);

                        obj = Reader.GetValue(19);
                        if (obj == DBNull.Value)
                            entity.OilseedRaoe = 0;
                        else
                            entity.OilseedRaoe = Convert.ToDouble(obj);

                        ctx.Set<AP_PlantNoPointSource>().Add(entity);
                    }
                    conn.Close();
                }
                ctx.SaveChanges();

                return Content("success");
            }
        }
        public AugricultureNonPointSourcePollutionEntities2 GetDbContext() {
            return  new AugricultureNonPointSourcePollutionEntities2();
        }
        public ActionResult GetAP_PlantNoPointSourceList(int Year) {
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
    }
}
