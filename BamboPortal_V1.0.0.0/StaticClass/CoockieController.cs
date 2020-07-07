using BamboPortal_V1._0._0._0.BamboPortalSecurity.EncDec;
using BamboPortal_V1._0._0._0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.StaticClass
{
    public static class CoockieController
    {
        public static Administrator SayMyName (string CoockieJson)
        {
            EncDec en = new EncDec();
            return JsonConvert.DeserializeObject<Administrator>(en.DecryptText(CoockieJson));
        }
        public static string SetCoockie(Administrator CoockieOBJ)
        {
            CoockieOBJ.SayMyTime = DateTime.Now;
            EncDec en = new EncDec();
            return en.EncryptText(JsonConvert.SerializeObject(CoockieOBJ));
        }
    }
}