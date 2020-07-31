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

                return "/AdminDesignResource/app/media/img/users/user4.jpg";
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
                        return "/AdminDesignResource/app/media/img/users/user4.jpg";
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

    }
}