using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class ProductViewDetails_ProductSOCKandSOCKVL
    {
        public string SOCKName  {  set; get; }
        public string SOCKVName { set;get; }
        public string BootstrapColor { get; set; }

        public override string ToString()
        {
            return $"{SOCKName} : {SOCKVName}";
        }

    }

    public class ProductViewDetails_ProductSOCKandSOCKVLList
    {
        public List<ProductViewDetails_ProductSOCKandSOCKVL> ProductSOCKSOCKVList { get; set; }
        public string id_MPC { get; set; }
    }

}