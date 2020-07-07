using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class MiniFactorModel
    {
        public int Id { get; set; }
        public int Items { get; set; }
        public long totality { get; set; }
        public int CustomerId { get; set; }

    }
}