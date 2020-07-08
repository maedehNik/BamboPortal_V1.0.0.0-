using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts
{
    public class AddMainCategorySubmiterForm
    {
        [MyMaxLengthAttribute(4)]
        [Required(ErrorMessage = "انتخاب سردسته اصلی نیاز است")]
        public string IdofSardastebandi { get; set; }
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "پر کردن نام دسته بندی اصلی الزامیست")]
        public string NameofCategory { get; set; }

        public string IDMainCategoryForEdit { get; set; }
    }
}