using BamboPortal_V1._0._0._0.Models.AdministratorUploader;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.nonStaticUsefulClass.ImageUploader
{
    public class ImageSizeConvertor
    {

        public ReturnedSaveImages Returned { get; set; }
        public ImageSizeConvertor(DatabaseImageUploadStructure Sizes, HttpPostedFileBase UploadedImage, string Code)
        {
            //try
            //{
            string FolderName = System.Web.HttpContext.Current.Server.MapPath($"~/UploadedImages/{Sizes.picSizeTypeName}/{PersianDateTime.Now.Year}/{PersianDateTime.Now.Month}/{PersianDateTime.Now.Day}");
            if (!Directory.Exists(FolderName))
            {
                Directory.CreateDirectory(FolderName);
            }
            Bitmap newImage = new Bitmap(Sizes.picSizeTypeWidth, Sizes.picSizeTypeHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(Image.FromStream(UploadedImage.InputStream, true, true), new Rectangle(0, 0, Sizes.picSizeTypeWidth, Sizes.picSizeTypeHeight));
            }
            string ImagePath = $"{FolderName}\\{ProjectProperies.imageSavePath}{DateTime.Now.Ticks}.JPEG";
            string imageAddress = $"/UploadedImages/{Sizes.picSizeTypeName}/{PersianDateTime.Now.Year}/{PersianDateTime.Now.Month}/{PersianDateTime.Now.Day}\\{ProjectProperies.imageSavePath}{DateTime.Now.Ticks}.JPEG";
            newImage.Save(ImagePath, ImageFormat.Jpeg);
            newImage.Dispose();
            if (File.Exists(ImagePath))
            {
                Returned = new ReturnedSaveImages()
                {
                    Status = "1",
                    UploadedImageSrc = imageAddress,
                    UploadedImageTypeID = Sizes.picSizeType ,
                    SaveCode = Code
                };
            }
            else
            {
                Returned = new ReturnedSaveImages()
                {
                    Status = "0",
                };
            }
            //}
            //catch (Exception ex)
            //{
            //PPBugReporter rep = new PPBugReporter(BugTypeFrom.ImageFileWriter);

            //    {
            //        EXOBJ = ex
            //    };
            //    Returned = new ReturnedSaveImages()
            //    {
            //        Status = "0",
            //    };
            //}

        }
    }
}