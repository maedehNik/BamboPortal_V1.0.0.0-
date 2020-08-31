using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class ReplySubmiterModel
    {
        
        public string ProId { get; set; }
        [MyMaxLengthAttribute(10)]
        [Required(ErrorMessage = "شناسه نظر مورد نیاز میباشد")]
        public string CommentId { get; set; }
        [MyMaxLengthAttribute(400)]
        [Required(ErrorMessage = "وارد کردن متن پاسخ اجباری میباشد!")]
        public string Message { get; set; }
    }
}