using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.StaticClass
{
    public static class TitleFounder
    {
        public static string GetAdminPanelTitle(string controller, string action)
        {
            string result = $"پنل مدیریتی {ProjectProperies.PortalCutsomer} |";
            action = action.ToLower();
            controller = controller + "Controller";
            switch (controller)
            {
                case "AdminLoginAuthController":
                    switch (action)
                    {
                        case "index":
                            return result + "درگاه ورود";
                            break;
                    }
                    break;

                case "AdministratorWorkplaceController":
                    switch (action)
                    {
                        case "index":
                            return result + "داشبورد مدیریتی";
                            break;
                    }
                    break;

                case "AdministratorGeneralController":
                    switch (action)
                    {
                        case "index":
                            return result + "پروفایل";
                            break;
                    }
                    break;

                default:
                    return "No Title";
                    break;

            }
            return "No Title";
        }
    }
}