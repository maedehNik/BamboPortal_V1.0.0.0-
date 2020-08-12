using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorBlogModels;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.AdministratorBlog;
using BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdminstratorBlogController : AdminRulesController
    {
        private string NoImage = "/CustomerSide_desinerResource/images/shop/imgNotFount.jpg";
        // GET: AdminstratorBlog
        public ActionResult NewPost()
        {
            ///////connect to dataBase
            PDBC db = new PDBC();
            db.Connect();
            DataTable cat = db.Select("SELECT [Id],[name]FROM [tbl_BLOG_Categories] where Is_Deleted=0 AND Is_Disabled=0");
            DataTable Gro = db.Select("SELECT [G_Id],[name] FROM [tbl_BLOG_Groups] where Is_Deleted=0 AND Is_Disabled=0");
            db.DC();
            ///////disconnect to dataBase

            ///fill Models
            var Cats = new List<Id_ValueModel>();
            for (int i = 0; i < cat.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(cat.Rows[i]["Id"]),
                    Value = cat.Rows[i]["name"].ToString()
                };
                Cats.Add(model);
            }


            var Groups = new List<Id_ValueModel>();
            for (int i = 0; i < Gro.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(Gro.Rows[i]["G_Id"]),
                    Value = Gro.Rows[i]["name"].ToString()
                };
                Groups.Add(model);
            }


            var Model = new BlogNewPostModelView()
            {
                Groups = Groups,
                Categories = Cats,
                AddPostModel = new PostModel() { typeID = "0" }
            };
            ///fill Models End
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPost(BlogNewPostModelView senderObjs)
        {
            PostModel senderObj = senderObjs.AddPostModel;
            PDBC db = new PDBC();
            if (ModelState.IsValid)
            {
                if (senderObj != null)
                {
                    uint id = 0;
                    if (UInt32.TryParse(senderObj.typeID, out id))
                    {
                        try
                        {
                            if (senderObj.typeID == "0")
                            {

                                List<ExcParameters> parss = new List<ExcParameters>();
                                ExcParameters par = new ExcParameters()
                                {
                                    _KEY = "@Title",
                                    _VALUE = senderObj.Title
                                };
                                parss.Add(par);

                                par = new ExcParameters()
                                {
                                    _KEY = "@Text_min",
                                    _VALUE = senderObj.Text_min
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@Text",
                                    _VALUE = senderObj.Text
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@weight",
                                    _VALUE = senderObj.Weight
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@GroupId",
                                    _VALUE = senderObj.GroupId
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@Cat_Id",
                                    _VALUE = senderObj.CatId
                                };
                                parss.Add(par);
                                int imp = 0;
                                if (senderObj.IsImportant)
                                {
                                    imp = 1;
                                }

                                par = new ExcParameters()
                                {
                                    _KEY = "@IsImportant",
                                    _VALUE = imp
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@WrittenBy_AdminId",
                                    _VALUE = 1
                                };
                                parss.Add(par);
                                db.Connect();
                                string InsertedID = db.Script("INSERT INTO  [tbl_BLOG_Post] ([Title],[Text_min],[Text],[WrittenBy_AdminId],[Date],[weight],[IsImportant],[Is_Deleted],[Is_Disabled],[Cat_Id],[GroupId]) output inserted.Id VALUES(@Title,@Text_min,@Text,@WrittenBy_AdminId,GETDate(),@weight,@IsImportant,0,0,@Cat_Id,@GroupId)", parss).ToString();
                                  
                                    if (InsertedID != "0")
                                    {
                                   

                                    var tags = senderObj.Tags.Split(',');
                                    for (int i = 0; i < tags.Length; i++)
                                    {
                                        parss = new List<ExcParameters>();
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@PostID",
                                            _VALUE = InsertedID
                                        };
                                        parss.Add(par);

                                        par = new ExcParameters()
                                        {
                                            _KEY = "@TagID",
                                            _VALUE = tags[i]
                                        };
                                        parss.Add(par);

                                        db.Script("INSERT INTO [tbl_BLOG_TagConnector]([Post_Id],[Tag_Id])VALUES(@PostID,@TagID)",parss);

                                    }

                                    var Pics = senderObj.Pics.Split(',');
                                    for (int i = 0; i < tags.Length; i++)
                                    {
                                        parss = new List<ExcParameters>();
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@PostId",
                                            _VALUE = InsertedID
                                        };
                                        parss.Add(par);

                                        par = new ExcParameters()
                                        {
                                            _KEY = "@PicId",
                                            _VALUE = Pics[i]
                                        };
                                        parss.Add(par);

                                        db.Script("INSERT INTO [tbl_BLOG_Pic_Connector]([PostId],[PicId])VALUES(@PostId,@PicId)",parss);

                                    }
                                    db.DC();
                                    var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "SX105",
                                            Errormessage = $"اطلاعات با موفقیت ثبت شد!",
                                            Errortype = "Success"
                                        };
                                        return Json(ModelSender);
                                    }
                                    else
                                    {
                                    db.DC();
                                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, InsertedID);
                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "EX114",
                                            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                                            Errortype = "Error"
                                        };
                                        return Json(ModelSender);
                                    }
                            }
                            else
                            {
                                List<ExcParameters> parss = new List<ExcParameters>();
                                ExcParameters par = new ExcParameters()
                                {
                                    _KEY = "@Title",
                                    _VALUE = senderObj.Title
                                };
                                parss.Add(par);

                                par = new ExcParameters()
                                {
                                    _KEY = "@Text_min",
                                    _VALUE = senderObj.Text_min
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@Text",
                                    _VALUE = senderObj.Text
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@weight",
                                    _VALUE = senderObj.Weight
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@GroupId",
                                    _VALUE = senderObj.GroupId
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@Cat_Id",
                                    _VALUE = senderObj.CatId
                                };
                                parss.Add(par);
                                int imp = 0;
                                if (senderObj.IsImportant)
                                {
                                    imp = 1;
                                }

                                par = new ExcParameters()
                                {
                                    _KEY = "@IsImportant",
                                    _VALUE = imp
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@Id",
                                    _VALUE = senderObj.typeID
                                };
                                parss.Add(par);
                                db.Connect();
                                string result = db.Script("UPDATE [tbl_BLOG_Post] SET [Title] = @Title ,[Text_min] = @Text_min ,[Text] = @Text,[weight] = @weight,[IsImportant] = @IsImportant ,[Cat_Id] = @Cat_Id ,[GroupId] = @GroupId WHERE Id=@Id)", parss).ToString();
                              
                                ////////////////////////////////update tags
                                parss = new List<ExcParameters>();
                                par = new ExcParameters()
                                {
                                    _KEY = "@PostId",
                                    _VALUE = senderObj.typeID
                                };
                                parss.Add(par);
                                db.Script("DELETE FROM [tbl_BLOG_TagConnector]WHERE Post_Id=@PostId", parss);

                                var tags = senderObj.Tags.Split(',');
                                    for (int i = 0; i < tags.Length; i++)
                                    {
                                        parss = new List<ExcParameters>();
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@PostID",
                                            _VALUE = senderObj.typeID
                                        };
                                        parss.Add(par);

                                        par = new ExcParameters()
                                        {
                                            _KEY = "@TagID",
                                            _VALUE = tags[i]
                                        };
                                        parss.Add(par);

                                        db.Script("INSERT INTO [tbl_BLOG_TagConnector]([Post_Id],[Tag_Id])VALUES(@PostID,@TagID)", parss);

                                    }


                                ////////////////////////////////update pictures
                                parss = new List<ExcParameters>();
                                par = new ExcParameters()
                                {
                                    _KEY = "@PostId",
                                    _VALUE = senderObj.typeID
                                };
                                parss.Add(par);
                                db.Script("DELETE FROM [tbl_BLOG_Pic_Connector]WHERE PostId=@PostId", parss);

                                var Pics = senderObj.Pics.Split(',');
                                    for (int i = 0; i < tags.Length; i++)
                                    {
                                        parss = new List<ExcParameters>();
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@PostId",
                                            _VALUE = senderObj.typeID
                                        };
                                        parss.Add(par);

                                        par = new ExcParameters()
                                        {
                                            _KEY = "@PicId",
                                            _VALUE = Pics[i]
                                        };
                                        parss.Add(par);

                                        db.Script("INSERT INTO [tbl_BLOG_Pic_Connector]([PostId],[PicId])VALUES(@PostId,@PicId)", parss);

                                    }
                                db.DC();
                                if (result=="1") { 
                                var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "SX104",
                                            Errormessage = $"اطلاعات با موفقیت تغییر یافت!",
                                            Errortype = "Success"
                                        };
                                        return Json(ModelSender);
                                    }
                                    else
                                    {
                                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "EX114",
                                            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                                            Errortype = "Error"
                                        };
                                        return Json(ModelSender);
                                    }
                            }
                        }
                        catch (Exception ex)
                        {
                            PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj) Cannot Cast to UINT}")
                            {
                                EXOBJ = ex
                            };
                            var ModelSender = new ErrorReporterModel
                            {
                                ErrorID = "EX113",
                                Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                                Errortype = "Error"
                            };
                            return Json(ModelSender);
                        }



                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj) Cannot Cast to UINT}");
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX111",
                            Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }

                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj)  (senderObj == null)");
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX111",
                        Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
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
                            IdOfProperty = AllKeys[i].Replace("addtypeField.", "addtypeField_"),
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
                return Json(ModelSender);
            }


        }

        public ActionResult PostTable()
        {
            ///////connect to dataBase
            PDBC db = new PDBC();
            db.Connect();
            DataTable dt = db.Select("SELECT [Id],[Title],[Text_min],[Date],[Is_Deleted],[Is_Disabled],[Pic] FROM [v_BlogPostList] ORDER BY([Date])DESC");
            db.DC();
            ///////disconnect to dataBase

            ///fill Models
            var Model = new List<PostTableModel>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new PostTableModel()
                {
                    PostId = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Title = dt.Rows[i]["Title"].ToString(),
                    Text_Min = dt.Rows[i]["Text_min"].ToString(),
                    PicPath = dt.Rows[i]["Pic"].ToString(),
                    LatEditDate = DateConvert.DateReturner(dt.Rows[i]["Date"].ToString(), "Ago"),
                    SeenNumber = "0",
                    Deleted = Convert.ToInt32(dt.Rows[i]["Is_Deleted"]),
                    Disabled = Convert.ToInt32(dt.Rows[i]["Is_Disabled"])
                };
                if (string.IsNullOrEmpty(model.PicPath))
                {
                    model.PicPath = NoImage;
                }
                Model.Add(model);


            }
            ///fill Models End
            return View(Model);
        }


        [HttpGet]
        public ActionResult Add_Blog_Group()
        {
            ///////connect to dataBase
            PDBC db = new PDBC();
            db.Connect();
            DataTable Gro = db.Select("SELECT [G_Id],[name],[Is_Disabled],[Is_Deleted],[GpToken] FROM [tbl_BLOG_Groups]");
            db.DC();
            ///////disconnect to dataBase

            ///fill Models
            var Groups = new List<BlodGroupListModel>();
            for (int i = 0; i < Gro.Rows.Count; i++)
            {
                var model = new BlodGroupListModel()
                {
                    Num = i + 1,
                    GroupId = Convert.ToInt32(Gro.Rows[i]["G_Id"]),
                    GroupName = Gro.Rows[i]["name"].ToString(),
                    GroupToken = Gro.Rows[i]["GpToken"].ToString(),
                    Disabled = Convert.ToInt32(Gro.Rows[i]["Is_Disabled"]),
                    IsDeleted = Convert.ToInt32(Gro.Rows[i]["Is_Deleted"])
                };
                Groups.Add(model);
            }

            var add = new AddBlogGroupModel()
            {
                typeID = "0"

            };


            var Model = new BlogAddGroupModelView()
            {
                GroupList = Groups,
                AddModel = add
            };
            ///fill Models End
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Blog_Group(BlogAddGroupModelView senderObjs)
        {
            AddBlogGroupModel senderObj = senderObjs.AddModel;
            PDBC db = new PDBC();
            if (ModelState.IsValid)
            {
                if (senderObj != null)
                {
                    uint id = 0;
                    if (UInt32.TryParse(senderObj.typeID, out id))
                    {
                        try
                        {
                            if (senderObj.typeID == "0")
                            {

                                List<ExcParameters> parss = new List<ExcParameters>();
                                ExcParameters par = new ExcParameters()
                                {
                                    _KEY = "@name",
                                    _VALUE = senderObj.GName
                                };
                                parss.Add(par);

                                par = new ExcParameters()
                                {
                                    _KEY = "@Token",
                                    _VALUE = senderObj.GToken
                                };
                                parss.Add(par);
                                db.Connect();
                                if (db.Select("SELECT COUNT(*) FROM [tbl_BLOG_Groups]WHERE [GpToken]=@Token", parss).Rows[0][0].ToString() == "0")
                                {
                                    string result = db.Script("INSERT INTO [tbl_BLOG_Groups]([name],[Is_Disabled],[Is_Deleted],[GpToken]) VALUES(@name,0,0,@Token)", parss);
                                    db.DC();
                                    if (result == "1")
                                    {
                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "SX105",
                                            Errormessage = $"اطلاعات با موفقیت ثبت شد!",
                                            Errortype = "Success"
                                        };
                                        return Json(ModelSender);
                                    }
                                    else
                                    {
                                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "EX114",
                                            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                                            Errortype = "Error"
                                        };
                                        return Json(ModelSender);
                                    }

                                }
                                else
                                {
                                    db.DC();
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX118",
                                        Errormessage = $"توکن تکراری!",
                                        Errortype = "Error"
                                    };
                                    return Json(ModelSender);
                                }
                            }
                            else
                            {
                                List<ExcParameters> parss = new List<ExcParameters>();
                                ExcParameters par = new ExcParameters()
                                {
                                    _KEY = "@name",
                                    _VALUE = senderObj.GName
                                };
                                parss.Add(par);

                                par = new ExcParameters()
                                {
                                    _KEY = "@Token",
                                    _VALUE = senderObj.GToken
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@id_PT",
                                    _VALUE = senderObj.typeID
                                };
                                parss.Add(par);
                                db.Connect();
                                if (db.Select("SELECT COUNT(*) FROM [tbl_BLOG_Groups]WHERE [GpToken]=@Token AND G_Id!=@id_PT", parss).Rows[0][0].ToString() == "0")
                                {
                                    string result = db.Script("UPDATE [tbl_BLOG_Groups] SET [name] =@name  ,[GpToken] =@Token  WHERE G_Id= @id_PT", parss);
                                    db.DC();
                                    if (result == "1")
                                    {
                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "SX104",
                                            Errormessage = $"اطلاعات با موفقیت تغییر یافت!",
                                            Errortype = "Success"
                                        };
                                        return Json(ModelSender);
                                    }
                                    else
                                    {
                                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "EX114",
                                            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                                            Errortype = "Error"
                                        };
                                        return Json(ModelSender);
                                    }
                                }
                                else
                                {
                                    db.DC();
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX118",
                                        Errormessage = $"توکن تکراری!",
                                        Errortype = "Error"
                                    };
                                    return Json(ModelSender);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj) Cannot Cast to UINT}")
                            {
                                EXOBJ = ex
                            };
                            var ModelSender = new ErrorReporterModel
                            {
                                ErrorID = "EX113",
                                Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                                Errortype = "Error"
                            };
                            return Json(ModelSender);
                        }



                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj) Cannot Cast to UINT}");
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX111",
                            Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }

                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj)  (senderObj == null)");
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX111",
                        Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
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
                            IdOfProperty = AllKeys[i].Replace("addtypeField.", "addtypeField_"),
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
                return Json(ModelSender);
            }


        }

        [HttpGet]
        public ActionResult Add_Blog_Category()
        {
            ///////connect to dataBase
            PDBC db = new PDBC();
            db.Connect();
            DataTable cat = db.Select("SELECT [Id],[name],[Is_Disabled],[Is_Deleted]FROM [tbl_BLOG_Categories]");
            db.DC();
            ///////disconnect to dataBase

            ///fill Models
            var Cats = new List<BlogCategoryListModel>();
            for (int i = 0; i < cat.Rows.Count; i++)
            {
                var model = new BlogCategoryListModel()
                {
                    Num = i + 1,
                    CatId = Convert.ToInt32(cat.Rows[i]["Id"]),
                    CatName = cat.Rows[i]["name"].ToString(),
                    Disabled = Convert.ToInt32(cat.Rows[i]["Is_Disabled"]),
                    IsDeleted = Convert.ToInt32(cat.Rows[i]["Is_Deleted"])
                };
                Cats.Add(model);
            }
            var add = new AddBlogCatModel()
            {
                typeID = "0",
                AddCat = ""
            };



            var Model = new BlogAddCategoryModelView()
            {
                CatList = Cats,
                AddCat = add

            };
            ///fill Models End
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Blog_Category(BlogAddCategoryModelView senderObjs)
        {
            AddBlogCatModel senderObj = senderObjs.AddCat;
            PDBC db = new PDBC();
            if (ModelState.IsValid)
            {
                if (senderObj != null)
                {
                    uint id = 0;
                    if (UInt32.TryParse(senderObj.typeID, out id))
                    {
                        try
                        {
                            if (senderObj.typeID == "0")
                            {
                                List<ExcParameters> parss = new List<ExcParameters>();
                                ExcParameters par = new ExcParameters()
                                {
                                    _KEY = "@name",
                                    _VALUE = senderObj.AddCat
                                };
                                parss.Add(par);
                                db.Connect();
                                string result = db.Script("INSERT INTO [tbl_BLOG_Categories]([name],[Is_Disabled],[Is_Deleted])VALUES(@name,0,0)", parss);
                                db.DC();
                                if (result == "1")
                                {
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "SX105",
                                        Errormessage = $"اطلاعات با موفقیت ثبت شد!",
                                        Errortype = "Success"
                                    };
                                    return Json(ModelSender);
                                }
                                else
                                {
                                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX114",
                                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                                        Errortype = "Error"
                                    };
                                    return Json(ModelSender);
                                }
                            }
                            else
                            {
                                List<ExcParameters> parss = new List<ExcParameters>();
                                ExcParameters par = new ExcParameters()
                                {
                                    _KEY = "@name",
                                    _VALUE = senderObj.AddCat
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@id_PT",
                                    _VALUE = senderObj.typeID
                                };
                                parss.Add(par);
                                db.Connect();
                                string result = db.Script("UPDATE [tbl_BLOG_Categories] SET [name] = @name WHERE Id= @id_PT", parss);
                                db.DC();
                                if (result == "1")
                                {
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "SX104",
                                        Errormessage = $"اطلاعات با موفقیت تغییر یافت!",
                                        Errortype = "Success"
                                    };
                                    return Json(ModelSender);
                                }
                                else
                                {
                                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX114",
                                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                                        Errortype = "Error"
                                    };
                                    return Json(ModelSender);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj) Cannot Cast to UINT}")
                            {
                                EXOBJ = ex
                            };
                            var ModelSender = new ErrorReporterModel
                            {
                                ErrorID = "EX113",
                                Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                                Errortype = "Error"
                            };
                            return Json(ModelSender);
                        }



                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj) Cannot Cast to UINT}");
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX111",
                            Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }

                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj)  (senderObj == null)");
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX111",
                        Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
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
                            IdOfProperty = AllKeys[i].Replace("addtypeField.", "addtypeField_"),
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
                return Json(ModelSender);
            }


        }

        [HttpGet]
        public ActionResult Add_Blog_Tags()
        {
            ///////connect to dataBase
            PDBC db = new PDBC();
            db.Connect();
            DataTable cat = db.Select("SELECT [Id],[name]FROM [tbl_BLOG_Categories] where Is_Deleted=0 AND Is_Disabled=0");
            DataTable TagList = db.Select("SELECT [Id],[TagName],[Is_Disabled],[Is_Deleted],[CatName] FROM [v_BlogTagsTable]");
            db.DC();
            ///////disconnect to dataBase

            ///fill Models
            var Cats = new List<Id_ValueModel>();
            for (int i = 0; i < cat.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(cat.Rows[i]["Id"]),
                    Value = cat.Rows[i]["name"].ToString()
                };
                Cats.Add(model);
            }


            var Tags = new List<BlogTagListModel>();
            for (int i = 0; i < TagList.Rows.Count; i++)
            {
                var model = new BlogTagListModel()
                {
                    Num = i + 1,
                    TagId = Convert.ToInt32(TagList.Rows[i]["Id"]),
                    CatName = TagList.Rows[i]["CatName"].ToString(),
                    Disabled = Convert.ToInt32(TagList.Rows[i]["Is_Disabled"]),
                    IsDeleted = Convert.ToInt32(TagList.Rows[i]["Is_Deleted"]),
                    TagName = TagList.Rows[i]["TagName"].ToString(),
                };
                Tags.Add(model);
            }

            var add = new AddTagModel()
            {
                typeID = "0"
            };

            var Model = new AddBlogTagModelView()
            {
                BlogCategories = Cats,
                TagList = Tags,
                AddTag = add
            };
            ///fill Models End
            return View(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Blog_Tags(AddBlogTagModelView senderObjs)
        {
            AddTagModel senderObj = senderObjs.AddTag;
            PDBC db = new PDBC();
            if (ModelState.IsValid)
            {
                if (senderObj != null)
                {
                    uint id = 0;
                    if (UInt32.TryParse(senderObj.typeID, out id))
                    {
                        try
                        {
                            if (senderObj.typeID == "0")
                            {
                                List<ExcParameters> parss = new List<ExcParameters>();
                                ExcParameters par = new ExcParameters()
                                {
                                    _KEY = "@name",
                                    _VALUE = senderObj.TagName
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@Cat",
                                    _VALUE = senderObj.CatId
                                };
                                parss.Add(par);
                                db.Connect();
                                string result = db.Script("INSERT INTO [tbl_BLOG_Tags]([Name],[CtegoryId],[Is_Disabled],[Is_Deleted]) VALUES(@name,@Cat,0,0)", parss);
                                db.DC();
                                if (result == "1")
                                {
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "SX105",
                                        Errormessage = $"اطلاعات با موفقیت ثبت شد!",
                                        Errortype = "Success"
                                    };
                                    return Json(ModelSender);
                                }
                                else
                                {
                                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX114",
                                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                                        Errortype = "Error"
                                    };
                                    return Json(ModelSender);
                                }
                            }
                            else
                            {
                                List<ExcParameters> parss = new List<ExcParameters>();
                                ExcParameters par = new ExcParameters()
                                {
                                    _KEY = "@name",
                                    _VALUE = senderObj.TagName
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@Cat",
                                    _VALUE = senderObj.CatId
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@id_PT",
                                    _VALUE = senderObj.typeID
                                };
                                parss.Add(par);
                                db.Connect();
                                string result = db.Script("UPDATE [tbl_BLOG_Tags] SET [Name] = @name  ,[CtegoryId] = @Cat  WHERE Id= @id_PT", parss);
                                db.DC();
                                if (result == "1")
                                {
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "SX104",
                                        Errormessage = $"اطلاعات با موفقیت تغییر یافت!",
                                        Errortype = "Success"
                                    };
                                    return Json(ModelSender);
                                }
                                else
                                {
                                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX114",
                                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                                        Errortype = "Error"
                                    };
                                    return Json(ModelSender);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj) Cannot Cast to UINT}")
                            {
                                EXOBJ = ex
                            };
                            var ModelSender = new ErrorReporterModel
                            {
                                ErrorID = "EX113",
                                Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                                Errortype = "Error"
                            };
                            return Json(ModelSender);
                        }



                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj) Cannot Cast to UINT}");
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX111",
                            Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }

                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType(addtype senderObj)  (senderObj == null)");
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX111",
                        Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
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
                            IdOfProperty = AllKeys[i].Replace("addtypeField.", "addtypeField_"),
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
                return Json(ModelSender);
            }


        }

        [HttpPost]
        public ActionResult GetBlogTags(int CatId)
        {
            PDBC db = new PDBC();
            List<ExcParameters> parss = new List<ExcParameters>();
            ExcParameters par = new ExcParameters()
            {
                _KEY = "@Cat",
                _VALUE = CatId
            };
            parss.Add(par);
            db.Connect();
            DataTable dt = db.Select("SELECT [Id],[Name] FROM [tbl_BLOG_Tags] WHERE Is_Deleted=0 AND Is_Disabled=0 AND CtegoryId=@Cat", parss);
            db.DC();
            var Model = new List<Id_ValueModel>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var model = new Id_ValueModel()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Value = dt.Rows[i]["Name"].ToString()
                };
                Model.Add(model);
            }

            return Json(Model);
        }
    }
}