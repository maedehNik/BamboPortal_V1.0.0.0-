using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class ProductListTable
    {
        public int idMPC { get; set; }
        public int id { get; set; }
        public string Productname { get; set; }
        public string ProductDescription { get; set; }
        public string PicThumnailUrl { get; set; }
        public string SubmitedDate { get; set; }
        public string AdminSubmiterName { get; set; }
        public List<Categors> AllCategorys { set; get; }
        public int ActivateStatus { get; set; }//1:Active 2:Deactive 3:Deleted
    }
    public class Categors
    {
        public string CategorColor { get; set; }
        public string CategorName { get; set; }
    }
}