using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorCustomers
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int IsActive { get; set; }
        public string Reg_Date { get; set; }
    }
}