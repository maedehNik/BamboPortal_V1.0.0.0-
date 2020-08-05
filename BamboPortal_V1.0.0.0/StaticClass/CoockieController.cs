using BamboPortal_V1._0._0._0.BamboPortalSecurity.EncDec;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
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
        //====================================================End of adminside

        public static string SetCustomerAUTHCookie(tbl_Customer_Main senderobj)
        {
            senderobj.SayMyTime = DateTime.Now;
            EncDec en = new EncDec();
            return en.EncryptText(JsonConvert.SerializeObject(senderobj));
        }
        public static tbl_Customer_Main SayWhoIsHE(string CoockieJson)
        {
            EncDec en = new EncDec();
            return JsonConvert.DeserializeObject<tbl_Customer_Main>(en.DecryptText(CoockieJson));
        }
    }
}