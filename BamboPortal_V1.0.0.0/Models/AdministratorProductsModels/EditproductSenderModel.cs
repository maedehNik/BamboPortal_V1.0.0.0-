using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorProductsModels
{
    public class EditproductSenderModel
    {
        public string idMPC { get; set; }
        [Required(ErrorMessage = "انتخاب کردن دسته بندی اصلی محصول اجباری میباشد!")]
        public string MainTagsID { get; set; }
        [Required(ErrorMessage = "وارد کردن نام محصول اجباری میباشد!")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "وارد کردن توضیحات محصول اجباری میباشد!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "وارد کردن قیمت واحد محصول اجباری میباشد!")]
        public string GheymateVahed { get; set; }
        [Required(ErrorMessage = "وارد کردن تعداد واحد محصول اجباری میباشد!")]
        public string TedadeVahed { get; set; }
        [Required(ErrorMessage = "وارد کردن قیمت واحد عمده محصول اجباری میباشد!")]
        public string GheymatevahedOmde { get; set; }
        [Required(ErrorMessage = "وارد کردن تعداد واحد عمده محصول اجباری میباشد!")]
        public string TedadeVahedOmde { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public string AllImagesByID { get; set; }
        public string Idmainp { get; set; }


    }
}