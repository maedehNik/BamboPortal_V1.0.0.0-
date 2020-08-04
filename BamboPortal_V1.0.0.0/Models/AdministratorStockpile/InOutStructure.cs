using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorStockpile
{
    public class InOutStructure
    {
        [MyMaxLengthAttribute(12)]
        [Required(ErrorMessage = "وارد کردن  تاریخ اجباری میباشد!")]
        public string ActionDate { get; set; }
        [MyMaxLengthAttribute(6)]
        [Required(ErrorMessage = "وارد کردن  زمان اجباری میباشد!")]
        public string Time { get; set; }
        public string id_Mpc { get; set; }
        [MyMaxLengthAttribute(16)]
        [Required(ErrorMessage = "وارد کردن میزان وارده یا صادره اجباری میباشد!")]
        public string INOUTValue { get; set; }
        [MyMaxLengthAttribute(16)]
        [Required(ErrorMessage = "وارد کردن قیمت وارده یا صادره اجباری میباشد!")]
        public string INOUTPrice { get; set; }
        public string Whichone { get; set; }
        public string Shopid1 { get; set; }
        public string shopid2 { get; set; }
        public string Description { get; set; }


    }
}