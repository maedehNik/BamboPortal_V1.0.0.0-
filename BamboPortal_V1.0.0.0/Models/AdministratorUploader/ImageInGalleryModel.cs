using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.Models.AdministratorUploader
{
    public class ImageInGalleryModel
    {
        public string ThumbnailImageSrc { get; set; }
        public string OrginalImageSrc { get; set; }
        public string ImageID { get; set; }


        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "پرکردن نام عکس اجباری میباشد")]
        public string ImageName { get; set; }
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = ".اورد کردن توضیحات عکس الزامی میباشد")]
        public string ImageDescription { get; set; }
        public string ImageLbl { get; set; }
        [MyMaxLengthAttribute(30)]
        [Required(ErrorMessage = "وارد کردن لیبل عکس اجباری میباشد!")]
        public string ImageAlt { get; set; }
        [Required(ErrorMessage = "هیچ عکسی انتخاب نشده است")]
        public List<HttpPostedFileBase> UploadedImages { get; set; }




        public string SkipImageIDS { set; get; }


    }
}