using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorFactor
{
    public class MainFactorModel
    {
        public int Num { get; set; }
        public int MainFactorId { get; set; }
        public string CreateDate { get; set; }
        public string PayType { get; set; }
        public int IsEdited { get; set; }
        public int IsDeleted { get; set; }
        public string MainFactor_Code { get; set; }
        public string MainFactor_Price { get; set; }
        public int Is_Pay { get; set; }
        public string PaymentCode { get; set; }
        public string Tax { get; set; }
        public string TotalOff { get; set; }
        public List<FactorItrmModel> Items { get; set; }

    }
}