using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models.AdministratorUploader;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.nonStaticUsefulClass.ImageUploader
{
    public class ImageUploader
    {
        public string UploadImages(ImageInGalleryModel senderObj, List<HttpPostedFileBase> AllUploadedimages)
        {

            //File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath($"~/ErrorLogs/{FolderName}/ErrorOn({CodeGenerated}--{FromWhere})-{PersianDateTime.Now.Year}-{PersianDateTime.Now.Month}-{PersianDateTime.Now.Day}-{PersianDateTime.Now.Hour} {PersianDateTime.Now.Minute} {PersianDateTime.Now.Second}.Panda"), excep);
            PDBC db = new PDBC();
            List<ExcParameters> parss = new List<ExcParameters>();
            parss.Add(new ExcParameters()
            {
                _KEY = "@Name",
                _VALUE = senderObj.ImageName
            });
            db.Connect();
            using (DataTable dt = db.Select("SELECT Count(*)as RN FROM [tbl_ADMIN_UploaderStructure] WHERE [uploadPicName] LIKE @Name", parss))
            {
                db.DC();
                if (Convert.ToInt32(dt.Rows[0]["RN"].ToString()) > 0)
                {
                    return "-1";
                }
            }
            parss = null;
            List<DatabaseImageUploadStructure> DIUS = new List<DatabaseImageUploadStructure>();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [picSizeType] ,[picSizeTypeName] ,[picSizeTypeWidth] ,[picSizeTypeHeight] FROM [tbl_ADMIN_UploaderStructure_ImageSize]"))
            {
                db.DC();
                int ii = dt.Rows.Count;
                for (int i = 0; i < ii; i++)
                {
                    DIUS.Add(new DatabaseImageUploadStructure()
                    {
                        picSizeType = dt.Rows[i]["picSizeType"].ToString(),
                        picSizeTypeHeight = Convert.ToInt32(dt.Rows[i]["picSizeTypeHeight"].ToString()),
                        picSizeTypeWidth = Convert.ToInt32(dt.Rows[i]["picSizeTypeWidth"].ToString()),
                        picSizeTypeName = dt.Rows[i]["picSizeTypeName"].ToString()
                    });
                }
            }
            int ModelCount = DIUS.Count;
            int UploadesCount = AllUploadedimages.Count;
            ImageSizeConvertor imgSaver;
            string result = "1";
            List<ReturnedSaveImages> SavedImgs = new List<ReturnedSaveImages>();
            for (int i = 0; i < UploadesCount; i++)
            {
                string CodeSave = DateTime.Now.Ticks.ToString();
                for (int j = 0; j < ModelCount; j++)
                {
                    imgSaver = new ImageSizeConvertor(DIUS[j], AllUploadedimages[i], CodeSave);
                    if (imgSaver.Returned.Status == "0")
                    {
                        result = "0";
                        break;
                    }
                    SavedImgs.Add(imgSaver.Returned);
                }
            }
            if (result == "0")
            {
                return "Error";
            }
            else
            {
                int UploadedAndSavedImagesCount = SavedImgs.Count;
                List<ExcParameters> Allparams = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();
                db.Connect();
                string Qresult = "";
                string Aresult = "";
                for (int i = 0; i < UploadedAndSavedImagesCount; i++)
                {
                    Allparams = new List<ExcParameters>();
                    parameters = new ExcParameters()
                    {
                        _KEY = "@Descriptions",
                        _VALUE = senderObj.ImageDescription
                    };
                    Allparams.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@uploadPicName",
                        _VALUE = senderObj.ImageName
                    };
                    Allparams.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@alt",
                        _VALUE = senderObj.ImageAlt
                    };
                    Allparams.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@PicCategoryType",
                        _VALUE = Convert.ToInt32(SavedImgs[i].UploadedImageTypeID)
                    };
                    Allparams.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@UploadAddress",
                        _VALUE = SavedImgs[i].UploadedImageSrc
                    };
                    Allparams.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@savedCode",
                        _VALUE = SavedImgs[i].SaveCode
                    };
                    Allparams.Add(parameters);
                    Qresult += db.Script("INSERT INTO [tbl_ADMIN_UploaderStructure]([PicCategoryType],[ISDELETE],[alt],[uploadPicName],[Descriptions],[CreatedDate],[UploadAddress],[savedCode]) VALUES(@PicCategoryType,0,@alt,@uploadPicName,@Descriptions,GETDATE(),@UploadAddress,@savedCode)", Allparams);
                    Aresult += "1";
                }
                db.DC();
                if (Aresult == Qresult)
                {
                    return "1";
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.ImageFileWriter, Qresult);
                    return "0";
                }

            }
        }

    }
}