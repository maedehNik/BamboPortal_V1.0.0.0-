using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.StaticClass
{
    public static class ProjectProperies
    {
        public static string PortalCutsomer = "پارچه گالری ولوت";
        public static string PortalCustomerModelCode = "VelvetCO";
        public static string AdminLoginAuthCode = "13990417";
        public static string CustomerLoginAuthCode = "13917DD";
        public static string imageSavePath = "پارچه-گالری-ولوت-";
        public static string AuthCoockieCode()
        {
            return $"{PortalCustomerModelCode}_{AdminLoginAuthCode}";
        }
        public static string AuthCustomerCode()
        {
            return $"{PortalCustomerModelCode}_{CustomerLoginAuthCode}";

        }
    }
}