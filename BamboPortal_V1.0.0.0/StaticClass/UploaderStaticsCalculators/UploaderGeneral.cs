﻿using System;
using System.Collections.Generic;
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
            return "/AdminDesignResource/app/media/img/users/user4.jpg";
        }
        public static List<string> imageFinder(List<string> id, ImageSizeEnums imageSize = ImageSizeEnums.AllSize)
        {
            List<string> newids = new List<string>();
            for(int i = 0; i < 100; i++)
            {
                newids.Add("/AdminDesignResource/app/media/img/users/user4.jpg");
            }
            return newids;
        }

    }
}