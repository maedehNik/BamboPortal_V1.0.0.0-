
using BamboPortal_V1._0._0._0.Models.AdministratorCustomers;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews
{
    public class CustomerProfileModelView
    {
        public List<Id_ValueModel> OstanHa { get; set; }
        public Admin_CustomerDetail CustomerModel { get; set; }
    }
}