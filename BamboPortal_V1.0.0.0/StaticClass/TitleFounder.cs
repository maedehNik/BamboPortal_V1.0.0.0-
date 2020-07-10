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
                case "AdministratorCustomersController":
                    switch (action)
                    {
                        case "index":
                            return result + " پروفایل مشتری";
                            break;
                    }
                    break;
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
                case "AdministratorProductsController":
                    switch (action)
                    {
                        case "addtype":
                            return result + "تعریف سردسته محصولات";
                            break;
                        case "maincategory":
                            return result + "تعریف گروه اصلی محصولات";
                            break;
                        case "addsubcategory":
                            return result + "تعریف گروه محصولات";
                            break;
                        case "addsubcategorykey":
                            return result + "تعریف ویژگی های گروه محصولات";
                            break;
                        case "addsubcategoryvaluesofkeys":
                            return result + "مقداردهی ویژگی های گروه محصولات";
                            break;
                        case "addmaintag":
                            return result + "تعریف پرچسب های های گروه محصولات";
                            break;

                        case "addproduct":
                            return result + "تعریف محصولات";
                            break;

                    }
                    break;

                default:
                    return result;
                    break;

            }
            return result;
        }
    }
}