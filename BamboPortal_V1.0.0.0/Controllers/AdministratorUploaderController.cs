using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorUploader;
using BamboPortal_V1._0._0._0.ModelViews.AdministratorUploader;
using BamboPortal_V1._0._0._0.nonStaticUsefulClass.ImageUploader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorUploaderController : Controller
    {
        // GET: AdministratorUploader
        public ActionResult Gallery()
        {
            ImageGalleryModelView model = new ImageGalleryModelView();
            model.imgs = new List<ImageGalleryModel>();
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [thumUploadAddress],[CreatedDate],[Descriptions],[uploadPicName],[alt],[ISDELETE],[PicCategoryType],[PicID],[orgPicID],[orgUploadAddress]  FROM [imageView]"))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.imgs.Add(new ImageGalleryModel()
                    {
                        alt = dt.Rows[i]["alt"].ToString(),
                        CreatedDate= dt.Rows[i]["CreatedDate"].ToString(),
                        Descriptions = dt.Rows[i]["Descriptions"].ToString(),
                        ISDELETE = dt.Rows[i]["ISDELETE"].ToString(),
                        orgPicID = dt.Rows[i]["orgPicID"].ToString(),
                        orgUploadAddress = dt.Rows[i]["orgUploadAddress"].ToString(),
                        PicCategoryType = dt.Rows[i]["PicCategoryType"].ToString(),
                        PicID = dt.Rows[i]["PicID"].ToString(),
                        thumUploadAddress = dt.Rows[i]["thumUploadAddress"].ToString(),
                        uploadPicName = dt.Rows[i]["uploadPicName"].ToString()

                    });
                }
            }
            return View(model);
        }
        public ActionResult Uploader_Image()
        {
            return View();
        }
        public ActionResult GalleryModal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadImages(ImageInGalleryModel SenderObj)
        {
            if (ModelState.IsValid)
            {
                List<string> Skips;
                if (!string.IsNullOrEmpty(SenderObj.SkipImageIDS))
                {

                    Skips = SenderObj.SkipImageIDS.Trim(',').Split(',').ToList();
                }
                else
                {
                    Skips = new List<string>();
                }
                int SkipimagesCount = Skips.Count;
                int imagescount = SenderObj.UploadedImages.Count;
                List<HttpPostedFileBase> newss = new List<HttpPostedFileBase>();
                for (int i = 0; i < imagescount; i++)
                {
                    bool Skipper = false;
                    for (int j = 0; j < SkipimagesCount; j++)
                    {
                        if (i.ToString() == Skips[j])
                            Skipper = true;
                    }
                    if (Skipper)
                        continue;
                    newss.Add(SenderObj.UploadedImages[i]);
                }
                Skips = null;
                if (newss.Count > 0)
                {
                    ImageUploader uploadAll = new ImageUploader();
                    string res = uploadAll.UploadImages(new ImageInGalleryModel()
                    {
                        ImageName = SenderObj.ImageName,
                        ImageDescription = SenderObj.ImageDescription,
                        ImageAlt = SenderObj.ImageAlt
                    }, newss);
                    if (res == "1")
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "SX10100Upload",
                            Errormessage = "تمامی عکس ها با موفقیت بارگزاری شده اند!",
                            Errortype = "Success"
                        };
                        TempData["returnData"] = ModelSender;
                        return RedirectToAction("UploaderPAge", "AdministratorUploader");
                    }
                    else if (res == "-1")
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX10200Upload",
                            Errormessage = "قبلا عکسی با این نام ذخیره شده است!",
                            Errortype = "Error"
                        };
                        TempData["returnData"] = ModelSender;
                        return RedirectToAction("UploaderPAge", "AdministratorUploader");
                    }
                    else
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX1020Upload",
                            Errormessage = "عدم توانایی در بارگزاری فایل ها با پشتیبانی در تماس باشید!",
                            Errortype = "Error"
                        };
                        TempData["returnData"] = ModelSender;
                        return RedirectToAction("UploaderPAge", "AdministratorUploader");
                    }
                }
                else
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX1020Upload",
                        Errormessage = "هیچ عکسی یافت نشد !",
                        Errortype = "Error"
                    };
                    TempData["returnData"] = ModelSender;
                    return RedirectToAction("UploaderPAge", "AdministratorUploader");
                }
            }
            else
            {
                List<ModelErrorReporter> allErrors = new List<ModelErrorReporter>();
                //foreach (ModelError error in ModelState.Values.)
                var AllValues = ModelState.Values.ToList();
                var AllKeys = ModelState.Keys.ToList();
                int errorsCount = AllValues.Count;
                for (int i = 0; i < errorsCount; i++)
                {
                    if (AllValues[i].Errors.Count > 0)
                    {
                        ModelErrorReporter er = new ModelErrorReporter()
                        {
                            IdOfProperty = AllKeys[i],
                            ErrorMessage = AllValues[i].Errors[0].ErrorMessage
                        };
                        allErrors.Add(er);
                    }
                }
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم رعایت استاندارد ها!",
                    Errortype = "ErrorWithList",
                    AllErrors = allErrors
                };
                TempData["returnData"] = ModelSender;
                return RedirectToAction("UploaderPAge", "AdministratorUploader");
            }
        }

        public ActionResult UploaderPAge()
        {
            ErrorReporterModel er = new ErrorReporterModel()
            {
                ErrorID = "0"
            };
            if (TempData["returnData"] != null)
            {
                er = (ErrorReporterModel)TempData["returnData"];
            }
            return View(er);
        }

    }
}