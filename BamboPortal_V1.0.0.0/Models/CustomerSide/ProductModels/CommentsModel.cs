using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.CustomerSide
{
    public class CommentsModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string ImagePath { get; set; }
        public string Date { get; set; }
        public List<CommentsModel> Reply { get; set; }
    }
}