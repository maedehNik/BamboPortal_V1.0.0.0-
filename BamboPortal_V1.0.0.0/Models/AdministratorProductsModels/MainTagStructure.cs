using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class MainTagStructure
    {
        public string TagID { get; set; }
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن  	برچسب اصلی اجباری میباشد!")]
        public string MainTagValue { get; set; }
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن توضیحات اجباری میباشد!")]
        public string MainTagDescription { get; set; }

        public int RowNumber { get; set; }
    }
}