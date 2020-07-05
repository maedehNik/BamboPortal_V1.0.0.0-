using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.StaticClass
{
    public class MyMaxLengthAttribute : StringLengthAttribute
    {
        public MyMaxLengthAttribute(int length) : base(length)
        {
            ErrorMessage = $"میزان کاراکتر مجاز برای ورودی حداکثر {length} کاراکتر میباشد!";
        }
    }
}