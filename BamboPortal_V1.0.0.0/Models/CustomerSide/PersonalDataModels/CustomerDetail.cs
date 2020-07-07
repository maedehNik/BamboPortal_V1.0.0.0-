using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Familly { get; set; }
        public string PhoneNum { get; set; }
        public string Discription { get; set; }
        public string registerDate { get; set; }
        public string Email { get; set; }
        public List<AddressModel> Addresses { get; set; }
    }
}