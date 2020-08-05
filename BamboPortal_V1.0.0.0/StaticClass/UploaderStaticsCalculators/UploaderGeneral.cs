using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.StaticClass.UploaderStaticsCalculators
{
    public static class UploaderGeneral
    {
        public static string GetAddressOfResourceByID(string ResName, string TypeofRes, ImageSizeEnums imageSize = ImageSizeEnums.AllSize)
        {
            switch (TypeofRes)
            {
                case "Image":
                    switch (imageSize)
                    {
                        case ImageSizeEnums.AllSize:

                            break;

                        case ImageSizeEnums.Thumbnail:

                            break;

                        case ImageSizeEnums.OriginalSize:

                            break;
                        default:
                            break;
                    }
                    break;
                case "File":
                    break;

            }

            return "Nothing";
        }

        public static string imageFinder(string id, ImageSizeEnums imageSize = ImageSizeEnums.AllSize)
        {

            if (string.IsNullOrEmpty(id))
            {

                return "/CustomerSide_desinerResource/images/shop/imgNotFount.jpg";
            }
            else
            {
                PDBC db = new PDBC();
                db.Connect();
                using (DataTable dt = db.Select("SELECT [orgUploadAddress] FROM [v_tblProduct_Image] WHERE [PicID] = " + id))
                {
                    db.DC();
                    if (dt.Rows.Count > 0)
                    {

                        return (dt.Rows[0]["orgUploadAddress"].ToString());
                    }
                    else
                    {
                        return "/CustomerSide_desinerResource/images/shop/imgNotFount.jpg";
                    }

                }

            }
        }
        public static List<string> imageFinder(List<string> id, string id_MProduct, ImageSizeEnums imageSize = ImageSizeEnums.AllSize)
        {

            List<string> newids = new List<string>();
            PDBC db = new PDBC();
            db.Connect();

            using (DataTable dt = db.Select("SELECT [orgUploadAddress] FROM [v_tblProduct_Image] WHERE id_MProduct = " + id_MProduct))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newids.Add(dt.Rows[i]["orgUploadAddress"].ToString());
                }
            }
            db.DC();
            return newids;
        }
        public static string imageFinderfromIDMPC(string idMPC, ImageSizeEnums imageSize = ImageSizeEnums.OriginalSize)
        {

            if (string.IsNullOrEmpty(idMPC))
            {

                return "/CustomerSide_desinerResource/images/shop/imgNotFount.jpg";
            }
            else
            {
                PDBC db = new PDBC();
                db.Connect();
                using (DataTable dt1 = db.Select("SELECT [id_MProduct] FROM  [tlb_Product_MainProductConnector] WHERE [id_MPC] =" + idMPC))
                {
                    if (dt1.Rows.Count > 0)
                    {
                        using (DataTable dt = db.Select("SELECT [thumUploadAddress],[orgUploadAddress] FROM [v_tblProduct_Image] WHERE [id_MProduct] = " + dt1.Rows[0]["id_MProduct"].ToString()))
                        {
                            db.DC();
                            if (dt.Rows.Count > 0)
                            {
                                if (imageSize == ImageSizeEnums.OriginalSize)
                                {

                                    return (dt.Rows[0]["orgUploadAddress"].ToString());
                                }
                                else
                                {
                                    return (dt.Rows[0]["thumUploadAddress"].ToString());

                                }
                            }
                            else
                            {
                                return "/CustomerSide_desinerResource/images/shop/imgNotFount.jpg";
                            }

                        }
                    }
                    else
                    {
                        db.DC();
                        return "/CustomerSide_desinerResource/images/shop/imgNotFount.jpg";
                    }
                }

            }
        }


    }
}