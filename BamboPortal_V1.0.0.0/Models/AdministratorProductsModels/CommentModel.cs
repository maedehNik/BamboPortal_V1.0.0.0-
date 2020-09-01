using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int ProId { get; set; }
        public int CusromerId { get; set; }
        public string ProTitle { get; set; }
        public string CustomerName { get; set; }
        public string Message { get; set; }
        public string CommentDate { get; set; }
        public string C_RegisterDate { get; set; }
        public string ProductCode { get; set; }
        public List<ReplyModel> Reply { get; set; }
        public string VerifyType { get; set; }
    }
}