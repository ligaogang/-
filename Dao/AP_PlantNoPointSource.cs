//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class AP_PlantNoPointSource
    {
        public System.Guid Id { get; set; }
        public int SeqNo { get; set; }
        public string Code { get; set; }
        public int Flag { get; set; }
        public int Status { get; set; }
        public System.Guid CreateUser { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.Guid LastModifyUser { get; set; }
        public System.DateTime LastModifyTime { get; set; }
        public Nullable<System.Guid> Area { get; set; }
        public Nullable<double> ChemicalFertilizer { get; set; }
        public Nullable<double> Nitrogenours { get; set; }
        public Nullable<double> PhosPhticFertilizer { get; set; }
        public Nullable<double> ComplexFertilizer { get; set; }
        public Nullable<double> Vegetable { get; set; }
        public Nullable<double> SeedArea { get; set; }
        public Nullable<double> GrainOutput { get; set; }
        public Nullable<double> Rice { get; set; }
        public Nullable<double> Millet { get; set; }
        public Nullable<double> Mize { get; set; }
        public Nullable<double> Potato { get; set; }
        public Nullable<double> Sorghum { get; set; }
        public Nullable<double> Wheat { get; set; }
        public Nullable<double> Bean { get; set; }
        public Nullable<double> OilPlant { get; set; }
        public Nullable<double> Pinut { get; set; }
        public Nullable<double> Sesame { get; set; }
        public Nullable<double> SunFlower { get; set; }
        public Nullable<double> Cottom { get; set; }
        public Nullable<double> OilseedRaoe { get; set; }
        public int Year { get; set; }
    }
}