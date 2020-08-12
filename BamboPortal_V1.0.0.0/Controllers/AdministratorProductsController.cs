using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts;
using BamboPortal_V1._0._0._0.nonStaticUsefulClass.Products;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorProductsController : AdminRulesController
    {
        // GET: AdministratorProducts

        //{start}For Product Type
        [HttpGet]
        public ActionResult AddType()
        {
            PDBC db = new PDBC();
            AddTypeModelView ATM = new AddTypeModelView();
            ATM.addtypeField = new addtype();
            ATM.TableAvailableProperty = new List<AddTypeTable>();
            ATM.TableDeletedProperties = new List<AddTypeTable>();

            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_PT] ,[PTname],[ISDESABLED] ,[ISDelete] ,[DateDesabled] ,[DateDeleted] FROM [tbl_Product_Type]"))
            {
                db.DC();
                if (dt.Rows.Count > 0)
                {
                    int counts = dt.Rows.Count;
                    for (int i = 0; i < counts; i++)
                    {
                        switch (dt.Rows[i]["ISDelete"].ToString())
                        {
                            case "1":
                                ATM.TableDeletedProperties.Add(new AddTypeTable
                                {
                                    id = dt.Rows[i]["id_PT"].ToString(),
                                    IsActivate = dt.Rows[i]["ISDESABLED"].ToString(),
                                    IsDeleted = dt.Rows[i]["ISDelete"].ToString(),
                                    RowColumnNumber = i.ToString(),
                                    Typename = dt.Rows[i]["PTname"].ToString()
                                });
                                break;
                            case "0":
                                ATM.TableAvailableProperty.Add(new AddTypeTable
                                {
                                    id = dt.Rows[i]["id_PT"].ToString(),
                                    IsActivate = dt.Rows[i]["ISDESABLED"].ToString(),
                                    IsDeleted = dt.Rows[i]["ISDelete"].ToString(),
                                    RowColumnNumber = i.ToString(),
                                    Typename = dt.Rows[i]["PTname"].ToString()
                                });
                                break;
                        }
                    }
                }
            }


            if (Request.QueryString["tID"] != null)
            {
                List<ExcParameters> excParameters = new List<ExcParameters>();
                ExcParameters excParameter = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = Request.QueryString["tID"].ToString()
                };
                excParameters.Add(excParameter);
                db.Connect();
                using (DataTable dt = db.Select("SELECT [id_PT] ,[PTname] ,[ISDelete] ,[DateDesabled] ,[DateDeleted] FROM [tbl_Product_Type] WHERE [id_PT] = @id_PT", excParameters))
                {
                    db.DC();
                    if (dt.Rows.Count > 0)
                    {
                        addtype ad = new addtype()
                        {
                            ProductType = dt.Rows[0]["PTname"].ToString(),
                            typeID = dt.Rows[0]["id_PT"].ToString()
                        };
                        ATM.addtypeField = ad;
                        return View(ATM);
                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType() Cannot Cast to Request.QueryString[\"tID\"].ToString()}");
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX112",
                            Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }
                }
            }
            else
            {
                addtype ad = new addtype()
                {
                    ProductType = "",
                    typeID = "0"
                };
                ATM.addtypeField = ad;
                return View(ATM);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddType(AddTypeModelView senderObjs)
        {
            addtype senderObj = senderObjs.addtypeField;
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
                                    _KEY = "@PTname",
                                    _VALUE = senderObj.ProductType
                                };
                                parss.Add(par);
                                db.Connect();
                                string result = db.Script("INSERT INTO[tbl_Product_Type] ([PTname] ,[ISDESABLED] ,[ISDelete]) VALUES (@PTname,0,0)", parss);
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
                                    _KEY = "@PTname",
                                    _VALUE = senderObj.ProductType
                                };
                                parss.Add(par);
                                par = new ExcParameters()
                                {
                                    _KEY = "@id_PT",
                                    _VALUE = senderObj.typeID
                                };
                                parss.Add(par);
                                db.Connect();
                                string result = db.Script("UPDATE [tbl_Product_Type] SET [PTname] = @PTname WHERE [id_PT] =@id_PT", parss);
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
        public JsonResult DeleteType(string idTodelete)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idTodelete, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idTodelete
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_Type] SET [ISDelete] = 1 ,[DateDeleted] = GETDATE() WHERE [id_PT] =@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[ISDELETE] = 1 WHERE [id_Type]=@id_PT", parss);
                result += db.Script("UPDATE P SET P.ISDelete=1,P.DateDeleted= GETDATE() FROM[tbl_Product_SubCategory] AS P inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product_MainCategory] SET ISDelete = 1 , DateDeleted= GETDATE() WHERE id_PT=@id_PT", parss);
                result += db.Script("UPDATE R SET R.ISDelete=1,R.DateDeleted= GETDATE() FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=@id_PT", parss);
                db.DC();
                if (result == "11111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این دسته بندی اصلی با موفقیت حذف شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }
        [HttpPost]
        public JsonResult ActiveType(string idToActive)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE[tbl_Product_Type] SET [ISDESABLED] = 0 ,[DateDesabled] = GETDATE() WHERE id_PT =@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 1 WHERE [id_Type]=@id_PT", parss);
                result += db.Script("UPDATE P SET P.ISDESABLED=0 FROM[tbl_Product_SubCategory] AS P inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product_MainCategory] SET ISDESABLED = 0 WHERE id_PT=@id_PT", parss);
                result += db.Script("UPDATE R SET R.ISDESABLED=0 FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=@id_PT", parss);
                db.DC();
                if (result == "11111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این دسته بندی اصلی با موفقیت فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        [HttpPost]
        public JsonResult DeActiveType(string idToDEActive)
        {

            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToDEActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToDEActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE[tbl_Product_Type] SET [ISDESABLED] = 1 ,[DateDesabled] = GETDATE()  WHERE id_PT = @id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 0 WHERE [id_Type]=@id_PT", parss);
                result += db.Script("UPDATE P SET P.ISDESABLED=1,P.DateDesabled= GETDATE() FROM[tbl_Product_SubCategory] AS P inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product_MainCategory] SET ISDESABLED = 1 , DateDesabled= GETDATE() WHERE id_PT=@id_PT", parss);
                result += db.Script("UPDATE R SET R.ISDESABLED=1,R.DateDesabled= GETDATE() FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC inner Join [tbl_Product_MainCategory] As M On P.id_MC=M.id_MC where M.id_PT=@id_PT", parss);
                db.DC();
                if (result == "11111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این دسته بندی اصلی با موفقیت فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        //{END}For Product Type
        //=================================================================================================================
        //{START}For Product MainCategory
        public ActionResult MainCategory()
        {
            AddMainCategoryModel model = new AddMainCategoryModel();
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_PT] as id ,[PTname] as [name] FROM [tbl_Product_Type] WHERE ISDelete=0 AND ISDESABLED=0"))
            {
                db.DC();
                List<Key_ValueModel> result = new List<Key_ValueModel>();
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var maodel = new Key_ValueModel()
                        {
                            Id = Convert.ToInt32(dt.Rows[i]["id"]),
                            Value = dt.Rows[i]["name"].ToString()
                        };
                        result.Add(maodel);
                    }
                }
                else
                {
                    result.Add(new Key_ValueModel { Id = 0, Value = "موردی برای انتخاب وجود ندارد" });

                }
                model.dastebandi_asli = result;
            }

            var res = new List<ProductGroupModel>();
            db.Connect();
            using (DataTable dt = db.Select("SELECT A.[id_MC],B.PTname,A.MCName,A.ISDelete,A.ISDESABLED,A.id_PT FROM [tbl_Product_MainCategory] as A inner join [tbl_Product_Type] as B on A.id_PT=B.id_PT"))
            {
                db.DC();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var ModelSender = new ProductGroupModel()
                    {
                        Num = i + 1,
                        Id = Convert.ToInt32(dt.Rows[i]["id_MC"]),
                        IsDeleted = Convert.ToInt32(dt.Rows[i]["ISDelete"]),
                        IsDisables = Convert.ToInt32(dt.Rows[i]["ISDESABLED"]),
                        Type = dt.Rows[i]["PTname"].ToString(),
                        Main = dt.Rows[i]["MCName"].ToString(),
                        IDtype = dt.Rows[i]["id_PT"].ToString()
                    };

                    res.Add(ModelSender);
                }
                model.Table = res;
            }
            //================================================================================ For Editpage
            model.FormSubmiting = new AddMainCategorySubmiterForm()
            {
                IDMainCategoryForEdit = "0",
                IdofSardastebandi = "0",
                NameofCategory = ""
            };
            //================================================================================ For Editpage
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddMainCategory(AddMainCategoryModel senderobj)
        {
            if (ModelState.IsValid)
            {
                PDBC db = new PDBC();
                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters()
                {
                    _KEY = "@value",
                    _VALUE = senderobj.FormSubmiting.NameofCategory
                };
                paramss.Add(parameters);
                parameters = new ExcParameters()
                {
                    _KEY = "@data_typa",
                    _VALUE = senderobj.FormSubmiting.IdofSardastebandi
                };
                paramss.Add(parameters);
                if (senderobj.FormSubmiting.IDMainCategoryForEdit == "0")
                {
                    db.Connect();
                    using (DataTable dt = db.Select("SELECT COUNT(*)as RN from [tbl_Product_MainCategory] WHERE [id_PT] = @data_typa AND [MCName] LIKE @value", paramss))
                    {
                        db.DC();
                        if (dt.Rows[0]["RN"].ToString() != "0")
                        {
                            var ModelSender = new ErrorReporterModel
                            {
                                ErrorID = "EX115",
                                Errormessage = $"عدم توانایی در ثبت اطلاعات! مورد با این مشخصات در پایگاه داده موجود است",
                                Errortype = "Error"
                            };
                            return Json(ModelSender);
                        }
                    }

                    db.Connect();
                    string resutlt = db.Script("INSERT INTO [tbl_Product_MainCategory]([id_PT],[MCName],[ISDESABLED],[ISDelete])VALUES (@data_typa, @value,0,0)", paramss);
                    db.DC();
                    if (resutlt == "1")
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "SX106",
                            Errormessage = $"گروه اصلی با موفقیت اضافه گردید!",
                            Errortype = "Success"
                        };
                        return Json(ModelSender);
                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, resutlt);
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX115",
                            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }
                }
                else
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@id",
                        _VALUE = senderobj.FormSubmiting.IDMainCategoryForEdit
                    };
                    paramss.Add(parameters);
                    db.Connect();
                    string result = db.Script("UPDATE [tbl_Product_MainCategory] SET [MCName] = @value,[id_PT] = @data_typa WHERE id_MC = @id", paramss);
                    db.DC();
                    if (result == "1")
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "SX106",
                            Errormessage = $"گروه اصلی با موفقیت ویرایش گردید!",
                            Errortype = "Success"
                        };
                        return Json(ModelSender);
                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX115",
                            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }

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
                            IdOfProperty = AllKeys[i].Replace("FormSubmiting.", "FormSubmiting_"),
                            ErrorMessage = AllValues[i].Errors[0].ErrorMessage
                        };
                        allErrors.Add(er);
                    }
                }
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX0012",
                    Errormessage = $"عدم رعایت استاندارد ها!",
                    Errortype = "ErrorWithList",
                    AllErrors = allErrors
                };
                return Json(ModelSender);
            }

        }
        [HttpPost]
        public JsonResult AddMainCategory_DeActive(string idToDEActive)
        {

            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToDEActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToDEActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_MainCategory] SET [ISDESABLED] = 1 , [DateDesabled] = GETDATE() WHERE id_MC=@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 0 WHERE [id_MainCategory]=@id_PT", parss);
                result += db.Script("UPDATE[tbl_Product_SubCategory] SET[ISDESABLED] = 1,[DateDesabled] = GETDATE() WHERE [id_MC]=@id_PT", parss);
                result += db.Script("UPDATE R SET R.ISDESABLED=1,R.DateDesabled= GETDATE() FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC where P.id_MC=@id_PT", parss);
                db.DC();
                if (result == "1111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این گروه اصلی با موفقیت غیر فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        [HttpPost]
        public JsonResult AddMainCategory_Active(string idToActive)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_MainCategory] SET [ISDESABLED] = 0 , [DateDesabled] = GETDATE() WHERE id_MC=@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 1 WHERE [id_MainCategory]=@id_PT", parss);
                result += db.Script("UPDATE[tbl_Product_SubCategory] SET[ISDESABLED] = 0 WHERE [id_MC]=@id_PT", parss);
                result += db.Script("UPDATE R SET R.DateDesabled=0 FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC where P.id_MC=@id_PT", parss);
                db.DC();
                if (result == "1111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این گروه اصلی با موفقیت فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        [HttpPost]
        public JsonResult AddMainCategory_DELETE(string idTodelete)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idTodelete, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idTodelete
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_MainCategory] SET [ISDelete] =1 , [DateDeleted] = GETDATE()  WHERE id_MC =@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[ISDELETE] = 1 WHERE [id_MainCategory]=@id_PT", parss);
                result += db.Script("UPDATE[tbl_Product_SubCategory] SET[ISDelete] = 1,[DateDeleted] = GETDATE() WHERE [id_MC]=@id_PT", parss);
                result += db.Script("UPDATE R SET R.ISDelete=1,R.DateDeleted= GETDATE() FROM[tbl_Product_SubCategoryOptionKey]AS R inner Join [tbl_Product_SubCategory] AS P On R.id_SC=P.id_SC where P.id_MC=@id_PT", parss);
                db.DC();
                if (result == "1111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این گروه بندی اصلی با موفقیت حذف شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        //{END}For Product MainCategory
        //=================================================================================================================
        //{start}For Product  SubCategory
        public ActionResult AddSubCategory()
        {
            AddSubCategoryModelView model = new AddSubCategoryModelView();
            model.Tbl = new List<ProductGroupModel>();
            model.SubmiterModel = new AddSubCategorySubmiterModel()
            {
                IdSubCategoryForEdit = "0",
                MainCategoryID = "0",
                SubCategoryName = "",
                typeID = "0"
            };
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_PT] as id ,[PTname] as [name] FROM [tbl_Product_Type] WHERE ISDelete=0 AND ISDESABLED=0"))
            {
                db.DC();
                List<Key_ValueModel> result = new List<Key_ValueModel>();
                if (dt.Rows.Count > 0)
                {
                    var maodel = new Key_ValueModel()
                    {
                        Id = 0,
                        Value = "یک مورد را انتخاب نمایید"
                    };
                    result.Add(maodel);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        maodel = new Key_ValueModel()
                        {
                            Id = Convert.ToInt32(dt.Rows[i]["id"]),
                            Value = dt.Rows[i]["name"].ToString()
                        };
                        result.Add(maodel);
                    }
                }
                else
                {
                    result.Add(new Key_ValueModel { Id = 0, Value = "موردی برای انتخاب وجود ندارد" });

                }
                model.IdTypes = result;
            }

            db.Connect();
            using (DataTable dt = db.Select("SELECT C.id_SC,B.PTname,A.MCName,C.ISDelete,C.ISDESABLED,C.SCName FROM [tbl_Product_MainCategory] as A inner join [tbl_Product_Type] as B on A.id_PT=B.id_PT inner join [tbl_Product_SubCategory] as C on A.id_MC=C.id_MC"))
            {
                var res = new List<ProductGroupModel>();
                db.DC();
                int dtrowcount = dt.Rows.Count;
                for (int i = 0; i < dtrowcount; i++)
                {
                    var mdl = new ProductGroupModel()
                    {
                        Num = i + 1,
                        Id = Convert.ToInt32(dt.Rows[i]["id_SC"]),
                        IsDeleted = Convert.ToInt32(dt.Rows[i]["ISDelete"]),
                        IsDisables = Convert.ToInt32(dt.Rows[i]["ISDESABLED"]),
                        Type = dt.Rows[i]["PTname"].ToString(),
                        Main = dt.Rows[i]["MCName"].ToString(),
                        Sub = dt.Rows[i]["SCName"].ToString()
                    };
                    res.Add(mdl);
                }

                model.Tbl = res;
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubCategory(AddSubCategoryModelView senderobj)
        {
            if (ModelState.IsValid)
            {
                PDBC db = new PDBC();

                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();
                parameters = new ExcParameters()
                {
                    _KEY = "@value",
                    _VALUE = senderobj.SubmiterModel.SubCategoryName
                };
                paramss.Add(parameters);
                parameters = new ExcParameters()
                {
                    _KEY = "@data_Sub",
                    _VALUE = senderobj.SubmiterModel.MainCategoryID
                };
                paramss.Add(parameters);
                db.Connect();
                string result = db.Script("INSERT INTO [tbl_Product_SubCategory]([id_MC],[SCName],[ISDESABLED],[ISDelete])VALUES (@data_Sub,@value,0,0)", paramss);
                db.DC();
                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"گروه محصولات با موفقیت ثبت شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
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
                            IdOfProperty = AllKeys[i].Replace("SubmiterModel.", "SubmiterModel_"),
                            ErrorMessage = AllValues[i].Errors[0].ErrorMessage
                        };
                        allErrors.Add(er);
                    }
                }
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX0012",
                    Errormessage = $"عدم رعایت استاندارد ها!",
                    Errortype = "ErrorWithList",
                    AllErrors = allErrors
                };
                return Json(ModelSender);
            }

        }
        [HttpPost]
        public JsonResult AddSubCategoryActive(string idToActive)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_SubCategory] SET [ISDESABLED] = 0 , [DateDesabled] = GETDATE() WHERE id_SC=@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 1 WHERE [id_SubCategory]=@id_PT", parss);
                result += db.Script("UPDATE[tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] =0 WHERE id_SC=@id_PT", parss);

                db.DC();
                if (result == "111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این گروه با موفقیت فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }
        [HttpPost]
        public JsonResult AddSubCategoryDeActive(string idToDEActive)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToDEActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToDEActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_SubCategory] SET [ISDESABLED] =1 , [DateDesabled] = GETDATE() WHERE id_SC=@id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[IS_AVAILABEL] = 0 WHERE [id_SubCategory]=@id_PT", parss);
                result += db.Script("UPDATE[tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] =1,[DateDesabled] = GETDATE() WHERE id_SC=@id_PT", parss);

                db.DC();
                if (result == "111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این گروه با موفقیت غیر فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }
        [HttpPost]
        public JsonResult AddSubCategoryDelete(string idTodelete)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idTodelete, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idTodelete
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_SubCategory] SET [ISDelete] = 1 , [DateDeleted] = GETDATE()  WHERE id_SC= @id_PT", parss);
                result += db.Script("UPDATE [tbl_Product]SET[ISDELETE] = 1 WHERE [id_SubCategory]=@id_PT", parss);
                result += db.Script("UPDATE[tbl_Product_SubCategoryOptionKey] SET [ISDelete] =1,[DateDeleted] = GETDATE() WHERE id_SC=@id_PT", parss);

                db.DC();
                if (result == "111")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این گروه با موفقیت حذف شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }
        //{END}For Product  SubCategory
        //=================================================================================================================
        //=================================================================================================================
        //{start}For Product  AddSubCategoryKey
        public ActionResult AddSubCategoryKey()
        {
            AddSubCategoryKeyModelView model = new AddSubCategoryKeyModelView();
            model.KeySubmit = new AddSubCatKeySubmit()
            {
                ProductSubCategoryKeyIDForEdit = "0"
            };
            model.ProductTypes = new List<Key_ValueModel>();
            model.Tbl = new List<ProductGroupModel>();

            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_PT] as id ,[PTname] as [name] FROM [tbl_Product_Type] WHERE ISDelete=0 AND ISDESABLED=0"))
            {
                db.DC();
                List<Key_ValueModel> result = new List<Key_ValueModel>();
                if (dt.Rows.Count > 0)
                {
                    var maodel = new Key_ValueModel()
                    {
                        Id = 0,
                        Value = "لطفا یک مورد را انتخاب نمایید!"
                    };
                    result.Add(maodel);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        maodel = new Key_ValueModel()
                        {
                            Id = Convert.ToInt32(dt.Rows[i]["id"]),
                            Value = dt.Rows[i]["name"].ToString()
                        };
                        result.Add(maodel);
                    }
                }
                else
                {
                    result.Add(new Key_ValueModel { Id = 0, Value = "موردی برای انتخاب وجود ندارد" });

                }
                model.ProductTypes = result;
            }

            db.Connect();
            using (DataTable dt = db.Select("SELECT D.id_SCOK,B.PTname,A.MCName,D.ISDelete,D.ISDESABLED,C.SCName,D.SCOKName FROM [tbl_Product_MainCategory] as A inner join [tbl_Product_Type] as B on A.id_PT=B.id_PT inner join [tbl_Product_SubCategory] as C on A.id_MC=C.id_MC inner join [tbl_Product_SubCategoryOptionKey] as D on C.id_SC=D.id_SC"))
            {
                db.DC();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model1 = new ProductGroupModel()
                    {
                        Num = i + 1,
                        Id = Convert.ToInt32(dt.Rows[i]["id_SCOK"]),
                        IsDeleted = Convert.ToInt32(dt.Rows[i]["ISDelete"]),
                        IsDisables = Convert.ToInt32(dt.Rows[i]["ISDESABLED"]),
                        Type = dt.Rows[i]["PTname"].ToString(),
                        Main = dt.Rows[i]["MCName"].ToString(),
                        Sub = dt.Rows[i]["SCName"].ToString(),
                        SubK = dt.Rows[i]["SCOKName"].ToString()
                    };

                    model.Tbl.Add(model1);

                }
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubCategoryKey(AddSubCategoryKeyModelView senderobj)
        {
            if (ModelState.IsValid)
            {

                PDBC db = new PDBC();
                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                parameters = new ExcParameters()
                {
                    _KEY = "@value",
                    _VALUE = senderobj.KeySubmit.ProductSubCategoryKeyName
                };
                paramss.Add(parameters);

                parameters = new ExcParameters()
                {
                    _KEY = "@data_SCK",
                    _VALUE = senderobj.KeySubmit.ProductSubCategoryId
                };
                paramss.Add(parameters);
                db.Connect();
                string result = db.Script("INSERT INTO [tbl_Product_SubCategoryOptionKey]([id_SC],[SCOKName],[ISDESABLED],[ISDelete])VALUES(@data_SCK,@value,0,0)", paramss);
                db.DC();

                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"نام ویژگی محصولات با موفقیت ثبت شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
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
                            IdOfProperty = AllKeys[i].Replace("KeySubmit.", "KeySubmit_"),
                            ErrorMessage = AllValues[i].Errors[0].ErrorMessage
                        };
                        allErrors.Add(er);
                    }
                }
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX0012",
                    Errormessage = $"عدم رعایت استاندارد ها!",
                    Errortype = "ErrorWithList",
                    AllErrors = allErrors
                };
                return Json(ModelSender);
            }
        }

        [HttpPost]
        public JsonResult AddSubCategoryKeyActive(string idToActive)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] = 0, [DateDesabled] = GETDATE() WHERE id_SCOK=@id_PT", parss);
                db.DC();
                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این ویژگی با موفقیت فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        [HttpPost]
        public JsonResult AddSubCategoryKeyDeActive(string idToDEActive)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idToDEActive, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idToDEActive
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE [tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] = 1 , [DateDesabled] = GETDATE() WHERE id_SCOK=@id_PT", parss);

                db.DC();
                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این ویژگی با موفقیت غیر فعال شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        [HttpPost]
        public JsonResult AddSubCategoryKeyDelete(string idTodelete)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idTodelete, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idTodelete
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("UPDATE[tbl_Product_SubCategoryOptionKey] SET [ISDelete] = 1, [DateDeleted] = GETDATE()  WHERE id_SCOK =@id_PT", parss);

                db.DC();
                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این ویژگی با موفقیت حذف شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        //{END}For Product  AddSubCategoryKey
        //=================================================================================================================
        //=================================================================================================================
        //{start}For Product  AddSubCateGoryValuesOfKeys
        public ActionResult AddSubCateGoryValuesOfKeys()
        {
            AddSubCateGoryValuesOfKeysModelView model = new AddSubCateGoryValuesOfKeysModelView();

            model.KeySubmit = new AddSubCateGoryValuesOfKeysSubmit()
            {
                ProductSubCategoryValueOfKeyIDForEdit = "0"
            };
            model.ProductTypes = new List<Key_ValueModel>();
            model.Tbl = new List<ProductGroupModel>();

            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_PT] as id ,[PTname] as [name] FROM [tbl_Product_Type] WHERE ISDelete=0 AND ISDESABLED=0"))
            {
                db.DC();
                List<Key_ValueModel> result = new List<Key_ValueModel>();
                if (dt.Rows.Count > 0)
                {
                    var maodel = new Key_ValueModel()
                    {
                        Id = 0,
                        Value = "لطفا یک مورد را انتخاب نمایید!"
                    };
                    result.Add(maodel);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        maodel = new Key_ValueModel()
                        {
                            Id = Convert.ToInt32(dt.Rows[i]["id"]),
                            Value = dt.Rows[i]["name"].ToString()
                        };
                        result.Add(maodel);
                    }
                }
                else
                {
                    result.Add(new Key_ValueModel { Id = 0, Value = "موردی برای انتخاب وجود ندارد" });

                }
                model.ProductTypes = result;
            }

            db.Connect();
            using (DataTable dt = db.Select("SELECT E.id_SCOV,B.PTname,A.MCName,C.SCName,D.SCOKName,E.SCOVValueName FROM [tbl_Product_MainCategory] as A inner join [tbl_Product_Type] as B on A.id_PT=B.id_PT inner join [tbl_Product_SubCategory] as C on A.id_MC=C.id_MC inner join [tbl_Product_SubCategoryOptionKey] as D on C.id_SC=D.id_SC inner join [tbl_Product_SubCategoryOptionValue] as E on D.id_SCOK=E.id_SCOK"))
            {
                db.DC();
                for (int i = 0; i < dt.Rows.Count; i++)
                {//ProductGroupModel
                    var model1 = new ProductGroupModel()
                    {
                        Num = i + 1,
                        Id = Convert.ToInt32(dt.Rows[i]["id_SCOV"]),
                        Type = dt.Rows[i]["PTname"].ToString(),
                        Main = dt.Rows[i]["MCName"].ToString(),
                        Sub = dt.Rows[i]["SCName"].ToString(),
                        SubK = dt.Rows[i]["SCOKName"].ToString(),
                        SubVal = dt.Rows[i]["SCOVValueName"].ToString()
                    };

                    model.Tbl.Add(model1);
                }
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubCateGoryValuesOfKeys(AddSubCateGoryValuesOfKeysModelView senderobj)
        {
            if (ModelState.IsValid)
            {

                PDBC db = new PDBC();
                List<ExcParameters> paramss = new List<ExcParameters>();
                ExcParameters parameters = new ExcParameters();

                parameters = new ExcParameters()
                {
                    _KEY = "@value",
                    _VALUE = senderobj.KeySubmit.ProductSubCategoryValueOfKeyName
                };
                paramss.Add(parameters);
                parameters = new ExcParameters()
                {
                    _KEY = "@data_SCK",
                    _VALUE = senderobj.KeySubmit.ProductSubCategoryKeyID
                };
                paramss.Add(parameters);
                db.Connect();
                string result = db.Script("INSERT INTO [tbl_Product_SubCategoryOptionValue] ([id_SCOK] ,[SCOVValueName] ,[CreatedDate]) VALUES(@data_SCK,@value,getdate())", paramss);
                db.DC();

                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"مقدار ویژگی محصولات با موفقیت ثبت شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
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
                            IdOfProperty = AllKeys[i].Replace("KeySubmit.", "KeySubmit_"),
                            ErrorMessage = AllValues[i].Errors[0].ErrorMessage
                        };
                        allErrors.Add(er);
                    }
                }
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX0012",
                    Errormessage = $"عدم رعایت استاندارد ها!",
                    Errortype = "ErrorWithList",
                    AllErrors = allErrors
                };
                return Json(ModelSender);
            }
        }
        [HttpPost]
        public JsonResult AddSubCateGoryValuesOfKeysDelete(string idTodelete)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idTodelete, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idTodelete
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("DELETE FROM[tbl_Product_SubCategoryOptionValue] WHERE id_SCOV = @id_PT", parss);

                db.DC();
                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این ویژگی با موفقیت حذف شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }

        //[HttpPost]
        //public JsonResult AddSubCateGoryValuesOfKeysActive(string idToActive)
        //{
        //    PDBC db = new PDBC();
        //    uint id = 0;
        //    if (UInt32.TryParse(idToActive, out id))
        //    {
        //        List<ExcParameters> parss = new List<ExcParameters>();
        //        ExcParameters par = new ExcParameters()
        //        {
        //            _KEY = "@id_PT",
        //            _VALUE = idToActive
        //        };
        //        parss.Add(par);
        //        db.Connect();
        //        string result = db.Script("UPDATE [tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] = 0, [DateDesabled] = GETDATE() WHERE id_SCOK=@id_PT", parss);
        //        db.DC();
        //        if (result == "1")
        //        {
        //            var ModelSender = new ErrorReporterModel
        //            {
        //                ErrorID = "SX106",
        //                Errormessage = $"این ویژگی با موفقیت فعال شد!",
        //                Errortype = "Success"
        //            };
        //            return Json(ModelSender);
        //        }
        //        else
        //        {
        //            PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
        //            var ModelSender = new ErrorReporterModel
        //            {
        //                ErrorID = "EX115",
        //                Errormessage = $"عدم توانایی در ثبت اطلاعات!",
        //                Errortype = "Error"
        //            };
        //            return Json(ModelSender);
        //        }

        //    }
        //    else
        //    {
        //        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
        //        var ModelSender = new ErrorReporterModel
        //        {
        //            ErrorID = "EX115",
        //            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
        //            Errortype = "Error"
        //        };
        //        return Json(ModelSender);
        //    }
        //}
        //[HttpPost]
        //public JsonResult AddSubCateGoryValuesOfKeysDeActive(string idToDEActive)
        //{
        //    PDBC db = new PDBC();
        //    uint id = 0;
        //    if (UInt32.TryParse(idToDEActive, out id))
        //    {
        //        List<ExcParameters> parss = new List<ExcParameters>();
        //        ExcParameters par = new ExcParameters()
        //        {
        //            _KEY = "@id_PT",
        //            _VALUE = idToDEActive
        //        };
        //        parss.Add(par);
        //        db.Connect();
        //        string result = db.Script("UPDATE [tbl_Product_SubCategoryOptionKey] SET [ISDESABLED] = 1 , [DateDesabled] = GETDATE() WHERE id_SCOK=@id_PT", parss);

        //        db.DC();
        //        if (result == "1")
        //        {
        //            var ModelSender = new ErrorReporterModel
        //            {
        //                ErrorID = "SX106",
        //                Errormessage = $"این ویژگی با موفقیت غیر فعال شد!",
        //                Errortype = "Success"
        //            };
        //            return Json(ModelSender);
        //        }
        //        else
        //        {
        //            PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
        //            var ModelSender = new ErrorReporterModel
        //            {
        //                ErrorID = "EX115",
        //                Errormessage = $"عدم توانایی در ثبت اطلاعات!",
        //                Errortype = "Error"
        //            };
        //            return Json(ModelSender);
        //        }

        //    }
        //    else
        //    {
        //        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
        //        var ModelSender = new ErrorReporterModel
        //        {
        //            ErrorID = "EX115",
        //            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
        //            Errortype = "Error"
        //        };
        //        return Json(ModelSender);
        //    }
        //}

        //{END}For Product  AddSubCateGoryValuesOfKeys
        //=================================================================================================================
        //=================================================================================================================
        //{start}For Product  AddMainTag
        public ActionResult AddMainTag()
        {
            AddMainTagModelView model = new AddMainTagModelView();
            model.TBLData = new List<MainTagStructure>();
            model.SubmiterStructure = new MainTagStructure()
            {
                MainTagValue = "",
                MainTagDescription = "",
                TagID = "0"
            };
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_MainStarTag],[MST_Description],[MST_Name] FROM [tbl_Product_MainStarTags]"))
            {
                db.DC();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model1 = new MainTagStructure()
                    {
                        RowNumber = i + 1,
                        TagID = dt.Rows[i]["id_MainStarTag"].ToString(),
                        MainTagValue = dt.Rows[i]["MST_Name"].ToString(),
                        MainTagDescription = dt.Rows[i]["MST_Description"].ToString()
                    };
                    model.TBLData.Add(model1);
                }
            }

            if (Request.QueryString["tID"] != null)
            {
                List<ExcParameters> excParameters = new List<ExcParameters>();
                ExcParameters excParameter = new ExcParameters()
                {
                    _KEY = "@id_MainStarTag",
                    _VALUE = Request.QueryString["tID"].ToString()
                };
                excParameters.Add(excParameter);
                db.Connect();
                using (DataTable dt = db.Select("SELECT [id_MainStarTag],[MST_Description],[MST_Name] FROM [tbl_Product_MainStarTags] WHERE [id_MainStarTag] = @id_MainStarTag", excParameters))
                {
                    db.DC();
                    if (dt.Rows.Count > 0)
                    {
                        MainTagStructure ad = new MainTagStructure()
                        {
                            MainTagValue = dt.Rows[0]["MST_Name"].ToString(),
                            MainTagDescription = dt.Rows[0]["MST_Description"].ToString(),
                            TagID = Request.QueryString["tID"].ToString()
                        };
                        model.SubmiterStructure = ad;
                        return View(model);
                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorProductsController}\nMethod : {public ActionResult AddType() Cannot Cast to Request.QueryString[\"tID\"].ToString()}");
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX112",
                            Errormessage = $"ورود متغیر خلاف پروتکل های امنیتی",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }
                }
            }




            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMainTag(AddMainTagModelView senderobj)
        {
            if (ModelState.IsValid)
            {
                if (senderobj.SubmiterStructure.TagID == "0")
                {
                    PDBC db = new PDBC();

                    List<ExcParameters> paramss = new List<ExcParameters>();
                    ExcParameters parameters = new ExcParameters();

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = senderobj.SubmiterStructure.MainTagValue
                    };
                    paramss.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@discription",
                        _VALUE = senderobj.SubmiterStructure.MainTagDescription
                    };
                    paramss.Add(parameters);
                    db.Connect();
                    string result = db.Script("INSERT INTO [tbl_Product_MainStarTags]VALUES( @discription , @value )", paramss);
                    db.DC();
                    if (result == "1")
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "SX106",
                            Errormessage = $"برچسب  محصولات با موفقیت ثبت شد!",
                            Errortype = "Success"
                        };
                        return Json(ModelSender);
                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX115",
                            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }
                }
                else
                {
                    PDBC db = new PDBC();

                    List<ExcParameters> paramss = new List<ExcParameters>();
                    ExcParameters parameters = new ExcParameters();

                    parameters = new ExcParameters()
                    {
                        _KEY = "@value",
                        _VALUE = senderobj.SubmiterStructure.MainTagValue
                    };
                    paramss.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@discription",
                        _VALUE = senderobj.SubmiterStructure.MainTagDescription
                    };
                    paramss.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@id",
                        _VALUE = senderobj.SubmiterStructure.TagID
                    };
                    paramss.Add(parameters);
                    db.Connect();
                    string result = db.Script("UPDATE [tbl_Product_MainStarTags] SET [MST_Description] = @discription ,[MST_Name] =@value WHERE id_MainStarTag= @id", paramss);
                    db.DC();
                    if (result == "1")
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "SX106",
                            Errormessage = $"برچسب  محصولات با موفقیت ویرایش شد!",
                            Errortype = "Success"
                        };
                        return Json(ModelSender);
                    }
                    else
                    {
                        PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX115",
                            Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }
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
                            IdOfProperty = AllKeys[i].Replace("SubmiterStructure.", "SubmiterStructure_"),
                            ErrorMessage = AllValues[i].Errors[0].ErrorMessage
                        };
                        allErrors.Add(er);
                    }
                }
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX0012",
                    Errormessage = $"عدم رعایت استاندارد ها!",
                    Errortype = "ErrorWithList",
                    AllErrors = allErrors
                };
                return Json(ModelSender);
            }

            return Json("");
        }

        public JsonResult AddMainTag_DELETE(string idTodelete)
        {
            PDBC db = new PDBC();
            uint id = 0;
            if (UInt32.TryParse(idTodelete, out id))
            {
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = idTodelete
                };
                parss.Add(par);
                db.Connect();
                string result = db.Script("DELETE FROM [tbl_Product_MainStarTags]WHERE id_MainStarTag = @id_PT", parss);
                db.DC();
                if (result == "1")
                {
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"این برچسب با موفقیت حذف شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                    var ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX115",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }

        //{END}For Product  AddMainTag
        //=================================================================================================================
        //=================================================================================================================
        //{start}For Product  AddProduct
        public ActionResult AddProduct()
        {
            AddProductModelView model = new AddProductModelView();
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_PT] as id ,[PTname] as [name] FROM [tbl_Product_Type] WHERE ISDelete=0 AND ISDESABLED=0"))
            {
                db.DC();
                List<Key_ValueModel> result = new List<Key_ValueModel>();
                if (dt.Rows.Count > 0)
                {
                    var maodel = new Key_ValueModel()
                    {
                        Id = 0,
                        Value = "لطفا یک مورد را انتخاب نمایید!"
                    };
                    result.Add(maodel);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        maodel = new Key_ValueModel()
                        {
                            Id = Convert.ToInt32(dt.Rows[i]["id"]),
                            Value = dt.Rows[i]["name"].ToString()
                        };
                        result.Add(maodel);
                    }
                }
                else
                {
                    result.Add(new Key_ValueModel { Id = 0, Value = "موردی برای انتخاب وجود ندارد" });

                }
                model.ProductTypes = result;
            }




            return View(model);
        }
        [HttpGet]
        public ActionResult ViewDetails(string idMPC)
        {
            if (!string.IsNullOrEmpty(idMPC))
            {
                int idmp = 0;
                if (Int32.TryParse(idMPC, out idmp))
                {
                    PDBC db = new PDBC();
                    ExcParameters par = new ExcParameters()
                    {
                        _KEY = "@id_MPC",
                        _VALUE = idMPC
                    };
                    List<ExcParameters> pars = new List<ExcParameters>();
                    pars.Add(par);
                    ProductViewDetailsModelView model = new ProductViewDetailsModelView();
                    model.ProductsJaygashtList = new List<ProductViewDetails_ProductSOCKandSOCKVLList>();
                    model.PropertyTable = new List<ProductViewDetails_PropertyTable>();
                    model.ProductStoreFromStockpile = new List<ProductViewDetails_PropertyTable>();
                    model.EditTimeLine = new List<ProductViewDetails_EditTimeLine>();
                    model.PicAddress = new List<string>();
                    model.PriceChart = new List<string>();
                    model.FactorsChart = new List<string>();
                    string id_MProductReal = "";
                    db.Connect();
                    using (DataTable dtproduct = db.Select("SELECT [id_MProduct],[id_MPC],[id_PQT],[IS_AVAILABEL],[id_DraftLevel],[id_Type],[id_MainCategory],[id_SubCategory],[idMPC_WhichTomainPrice],[Description],[DateCreated],[Title],[Seo_Description],[Seo_KeyWords],[IS_AD],[Search_Gravity],[Is_IntheDraft],[ISDELETE],[PTname],[ISDESABLED],[tbl_Product_Type_ISDelete],[MCName],[SCName],[Quantity],[PriceXquantity],[PricePerquantity],[PriceOff],[offTypeValue],[OffType],[tlb_Product_MainProductConnector_ISDELETE],[OutOfStock],[DateToRelease],[PriceShow],[PriceShowformat],[id_CreatedByAdmin],[ad_NickName],[ad_firstname],[ad_lastname],[id_MainStarTag],[PQT_Description],[PQT_Demansion],[PQT_Quantom],[code_Stockpile],[MoneyTypeName]  FROM [v_Connector_MainProductConnectorToProduct] WHERE [id_MPC] = @id_MPC", pars))
                    {
                        db.DC();
                        if (dtproduct.Rows.Count > 0)
                        {
                            id_MProductReal = dtproduct.Rows[0]["id_MProduct"].ToString();
                            model.id_MPC = idMPC;
                            model.ProductName = dtproduct.Rows[0]["Title"].ToString();
                            model.ProductStockpileCode = dtproduct.Rows[0]["code_Stockpile"].ToString();
                            model.Description = dtproduct.Rows[0]["Description"].ToString();
                            model.ProductPrice = dtproduct.Rows[0]["PriceXquantity"].ToString();
                            PersianDateTime date = new PersianDateTime(Convert.ToDateTime(dtproduct.Rows[0]["DateCreated"].ToString()));
                            model.LastEdit = date.ToLongDateTimeString();
                            model.PriceTypeName = dtproduct.Rows[0]["MoneyTypeName"].ToString();
                            db.Connect();
                            using (DataTable dt = db.Select("SELECT [id_MPC] ,[SCOKName] ,[SCOVValueName] FROM [v_ConnectorTheProductConnectorViewToSCOVandSCOKV_s] WHERE [id_MProduct] = " + dtproduct.Rows[0]["id_MProduct"].ToString() + " ORDER BY [id_MPC] DESC"))
                            {
                                db.DC();
                                if (dt.Rows.Count > 0)
                                {
                                    int dtrows = dt.Rows.Count;
                                    ProductViewDetails_ProductSOCKandSOCKVLList products = new ProductViewDetails_ProductSOCKandSOCKVLList();
                                    products.ProductSOCKSOCKVList = new List<ProductViewDetails_ProductSOCKandSOCKVL>();
                                    string id_MPC = "";
                                    products.ProductSOCKSOCKVList.Add(new ProductViewDetails_ProductSOCKandSOCKVL()
                                    {
                                        BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.primary),
                                        SOCKName = "سردسته بندی اصلی",
                                        SOCKVName = dtproduct.Rows[0]["PTname"].ToString()
                                    });
                                    products.ProductSOCKSOCKVList.Add(new ProductViewDetails_ProductSOCKandSOCKVL()
                                    {
                                        BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.primary),
                                        SOCKName = "گروه اصلی",
                                        SOCKVName = dtproduct.Rows[0]["MCName"].ToString()
                                    });
                                    products.ProductSOCKSOCKVList.Add(new ProductViewDetails_ProductSOCKandSOCKVL()
                                    {
                                        BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.primary),
                                        SOCKName = "گروه محصول",
                                        SOCKVName = dtproduct.Rows[0]["SCName"].ToString()
                                    });
                                    for (int i = 0; i < dtrows; i++)
                                    {
                                        if (id_MPC != dt.Rows[i]["id_MPC"].ToString())
                                        {
                                            if (!string.IsNullOrEmpty(id_MPC))
                                            {
                                                products.id_MPC = id_MPC;
                                                model.ProductsJaygashtList.Add(products);
                                                products = new ProductViewDetails_ProductSOCKandSOCKVLList();
                                                products.ProductSOCKSOCKVList = new List<ProductViewDetails_ProductSOCKandSOCKVL>();
                                                products.id_MPC = dt.Rows[i]["id_MPC"].ToString();
                                                products.ProductSOCKSOCKVList.Add(new ProductViewDetails_ProductSOCKandSOCKVL()
                                                {
                                                    BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.primary),
                                                    SOCKName = "سردسته بندی اصلی",
                                                    SOCKVName = dtproduct.Rows[0]["PTname"].ToString()
                                                });
                                                products.ProductSOCKSOCKVList.Add(new ProductViewDetails_ProductSOCKandSOCKVL()
                                                {
                                                    BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.primary),
                                                    SOCKName = "گروه اصلی",
                                                    SOCKVName = dtproduct.Rows[0]["MCName"].ToString()
                                                });
                                                products.ProductSOCKSOCKVList.Add(new ProductViewDetails_ProductSOCKandSOCKVL()
                                                {
                                                    BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.primary),
                                                    SOCKName = "گروه محصول",
                                                    SOCKVName = dtproduct.Rows[0]["SCName"].ToString()
                                                });

                                            }
                                        }
                                        products.ProductSOCKSOCKVList.Add(new ProductViewDetails_ProductSOCKandSOCKVL()
                                        {
                                            BootstrapColor = BootstrapColorPicker.GetbootstrapColorRandomByCounter(i),
                                            SOCKName = dt.Rows[i]["SCOKName"].ToString(),
                                            SOCKVName = dt.Rows[i]["SCOVValueName"].ToString()
                                        });
                                        id_MPC = dt.Rows[i]["id_MPC"].ToString();
                                        if (i == dtrows - 1)
                                        {
                                            products.id_MPC = id_MPC;
                                            model.ProductsJaygashtList.Add(products);
                                        }
                                    }

                                }
                                else
                                {
                                    return RedirectToAction("ProductList");
                                }
                            }
                        }
                        else
                        {
                            return RedirectToAction("ProductList");
                        }
                        db.Connect();
                        using (DataTable dt = db.Select("SELECT [KeyName] ,[Value] FROM [tbl_Product_tblOptions] WHERE [id_MProduct] = " + id_MProductReal))
                        {
                            db.DC();
                            int dtrows = dt.Rows.Count;
                            ProductViewDetails_PropertyTable pvdpt = new ProductViewDetails_PropertyTable();
                            if (dtrows == 0)
                            {
                                pvdpt = new ProductViewDetails_PropertyTable()
                                {
                                    Key = "موردی برای نمایش وجود ندارد",
                                    Value = "موردی برای نمایش وجود ندارد"
                                };
                                model.PropertyTable.Add(pvdpt);
                            }
                            for (int i = 0; i < dtrows; i++)
                            {
                                pvdpt = new ProductViewDetails_PropertyTable()
                                {
                                    Key = dt.Rows[i]["KeyName"].ToString(),
                                    Value = dt.Rows[i]["Value"].ToString()
                                };
                                model.PropertyTable.Add(pvdpt);
                            }
                        }
                    }

                    db.Connect();
                    using (DataTable dt = db.Select("SELECT [orgUploadAddress] FROM [v_tblProduct_Image] WHERE [id_MProduct]=" + id_MProductReal))
                    {
                        db.DC();
                        int dtrows = dt.Rows.Count;
                        for (int i = 0; i < dtrows; i++)
                        {
                            model.PicAddress.Add(dt.Rows[i]["orgUploadAddress"].ToString());
                        }
                    }
                    if (model.PicAddress.Count == 0)
                    {
                        model.PicAddress.Add("/AdminDesignResource/app/media/img/users/user4.jpg");
                    }
                    //=================================================================================== EditNeed
                    string p1 = "", p2 = "", f1 = "", f2 = "";
                    for (int i = 0; i < 12; i++)
                    {
                        p1 += $"\"{i}\",";
                        p2 += "0 ,";
                    }
                    p1 = p1.Trim(',');
                    p2 = p2.Trim(',');
                    f1 = p1;
                    f2 = p2;
                    model.FactorsChart.Add(f1);
                    model.FactorsChart.Add(f2);
                    model.PriceChart.Add(p1);
                    model.PriceChart.Add(p2);
                    //=================================================================================== EndEditsNeed
                    db.Connect();
                    using (DataTable dtstock = db.Select("SELECT  [shop_id] ,[ItemRemaining] ,[shop_name] ,[shop_IsAvailable] ,[shop_IsDelete] FROM [v_Stockpile_MainView] WHERE [id_MPC] = " + idMPC))
                    {
                        db.DC();
                        for (int i = 0; i < dtstock.Rows.Count; i++)
                        {
                            model.ProductStoreFromStockpile.Add(new ProductViewDetails_PropertyTable()
                            {
                                Key = dtstock.Rows[i]["shop_name"].ToString(),
                                Value = dtstock.Rows[i]["ItemRemaining"].ToString()
                            });
                        }
                    }



                    return View(model);
                }
                else
                {
                    return RedirectToAction("ProductList");
                }
            }
            else
            {
                return RedirectToAction("ProductList");
            }

        }
        //{END}For Product  AddProduct
        //=================================================================================================================
        public ActionResult ReturnInputsOfSubCategorykeyValues(string[] ListOfKeyIDs)
        {
            PDBC db = new PDBC();
            var ids = ListOfKeyIDs;

            var Subval = new List<ReturnInputsOfSubCategorykeyValues>();
            db.Connect();
            ExcParameters pa = new ExcParameters();
            List<ExcParameters> pas = new List<ExcParameters>();
            ReturnInputsOfSubCategorykeyValuesAllVals MF = new ReturnInputsOfSubCategorykeyValuesAllVals();
            for (int i = 0; i < ids.Length; i++)
            {
                pa = new ExcParameters()
                {
                    _KEY = "@id_SCOK",
                    _VALUE = ids[i]
                };
                pas.Add(pa);
                var model = new ReturnInputsOfSubCategorykeyValues()
                {
                    SubCategoryID = ids[i],
                    NameOfSubCategoryKey = db.Select("SELECT [SCOKName] FROM [tbl_Product_SubCategoryOptionKey] where [id_SCOK]=@id_SCOK", pas).Rows[0][0].ToString(),
                    SubCategoryAllKeyValues = MF.SubCat_Value(ids[i])
                };
                pas = new List<ExcParameters>();
                Subval.Add(model);
            }
            db.DC();
            var result = new ReturnInputsOfSubCategorykeyValuesModelView()
            {
                AllSubCategoryKeyValues = Subval
            };


            return View(result);
        }

        public ActionResult AddproductGetAllFinallyPriceDataAboutProducts()
        {
            AddproductGetAllFinallyPriceDataAboutProductsModelView model = new AddproductGetAllFinallyPriceDataAboutProductsModelView();
            var result = new List<Key_ValueModel>();
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_MainStarTag],[MST_Name] FROM [tbl_Product_MainStarTags]"))
            {
                db.DC();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model1 = new Key_ValueModel()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["id_MainStarTag"]),
                        Value = dt.Rows[i]["MST_Name"].ToString()
                    };

                    result.Add(model1);
                }
            }
            model.MainTags = result;
            result = new List<Key_ValueModel>();
            //db.Connect();
            //using (DataTable dt = db.Select("SELECT [OffType],[OffType_Symbol] FROM [tbl_Product_OffType]"))
            //{
            //    db.DC();
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        var model1 = new Key_ValueModel()
            //        {
            //            Id = Convert.ToInt32(dt.Rows[i]["OffType"]),
            //            Value = dt.Rows[i]["OffType_Symbol"].ToString()
            //        };

            //        result.Add(model1);
            //    }
            //}
            //model.OffTypes = result;
            result = new List<Key_ValueModel>();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [PriceShowId],[PriceShowformat] FROM [tbl_Product_PriceShow]"))
            {
                db.DC();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model1 = new Key_ValueModel()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["PriceShowId"]),
                        Value = dt.Rows[i]["PriceShowformat"].ToString()
                    };

                    result.Add(model1);
                }
            }
            model.PriceShow = result;
            result = new List<Key_ValueModel>();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [MoneyId],[MoneyTypeName] FROM [tbl_Product_MoneyType]"))
            {
                db.DC();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model1 = new Key_ValueModel()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["MoneyId"]),
                        Value = dt.Rows[i]["MoneyTypeName"].ToString()
                    };

                    result.Add(model1);
                }
            }
            model.PriceType = result;
            result = new List<Key_ValueModel>();
            db.Connect();
            using (DataTable dt = db.Select("SELECT[id_PQT],[PQT_Demansion] FROM[tbl_Product_ProductQuantityType] order by([PQT_Demansion])"))
            {
                db.DC();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var model1 = new Key_ValueModel()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["id_PQT"]),
                        Value = dt.Rows[i]["PQT_Demansion"].ToString()
                    };

                    result.Add(model1);
                }
            }
            model.QuantityTypes = result;
            result = new List<Key_ValueModel>();




            return View(model);
        }
        [HttpPost]
        public JsonResult AddProduct_SeimiFinalStepToGenerateProductAndFinalSubmit(AddProductSemiFinalSubmitToCreateProducts Senderobj)
        {
            string id_CreatedByAdmin = "0";
            if (Session["AdministratorRegistery"] != null)
            {
                id_CreatedByAdmin = ((Administrator)Session["AdministratorRegistery"]).id_Admin;
            }
            else
            {
                var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCoockieCode());
                Administrator administratorobj = CoockieController.SayMyName(coockie.Value);
                id_CreatedByAdmin = administratorobj.id_Admin;
            }
            List<ExcParameters> paramss = new List<ExcParameters>();
            PDBC db = new PDBC();
            var parameters = new ExcParameters()
            {
                _KEY = "@id_CreatedByAdmin",
                _VALUE = id_CreatedByAdmin
            };
            paramss.Add(parameters);
            parameters = new ExcParameters()
            {
                _KEY = "@Title",
                _VALUE = Senderobj.PRDCTName
            };
            paramss.Add(parameters);
            parameters = new ExcParameters()
            {
                _KEY = "@Description",
                _VALUE = Senderobj.PRDCTDescription
            };
            paramss.Add(parameters);
            parameters = new ExcParameters()
            {
                _KEY = "@SEO_keyword",
                _VALUE = "_tshNOkey"
            };
            paramss.Add(parameters);
            parameters = new ExcParameters()
            {
                _KEY = "@SEO_description",
                _VALUE = "_tshNOkey"
            };
            paramss.Add(parameters);
            parameters = new ExcParameters()
            {
                _KEY = "@SearchGravity",
                _VALUE = 1
            };
            paramss.Add(parameters);
            parameters = new ExcParameters()
            {
                _KEY = "@IsAd",
                _VALUE = 0
            };
            paramss.Add(parameters);

            db.Connect();
            string result = db.Script("INSERT INTO [tbl_Product] Output Inserted.id_MProduct VALUES (0, @id_CreatedByAdmin , 0 , 0 , 0 , 0 , 0 ,@Description,GETDATE(), @Title , @SEO_description , @SEO_keyword , @IsAd , @SearchGravity , 0 , 0)", paramss);
            int id_MProductOUT = 0;
            if (!Int32.TryParse(result, out id_MProductOUT))
            {
                db.DC();
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, result);
                var ModelSender1 = new ErrorReporterModel
                {
                    ErrorID = "EX115",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender1);
            }
            string[] PicIds = Senderobj.AllImagesByID.Split(',');
            paramss = new List<ExcParameters>();
            for (int i = 0; i < PicIds.Length; i++)
            {
                parameters = new ExcParameters()
                {
                    _KEY = "@id_MProductOUT",
                    _VALUE = id_MProductOUT
                };
                paramss.Add(parameters);
                parameters = new ExcParameters()
                {
                    _KEY = "@PicId",
                    _VALUE = PicIds[i]
                };
                paramss.Add(parameters);
                db.Script("INSERT INTO [tbl_Product_PicConnector] VALUES (@id_MProductOUT,@PicId)", paramss);
                paramss = new List<ExcParameters>();
            }
            db.DC();
            //id_MProductOUT Returned in this step
            //EndofAddpage1
            //======================================================================================
            //start of step 2
            paramss = new List<ExcParameters>();
            parameters = new ExcParameters()
            {
                _KEY = "@id_Type",
                _VALUE = Senderobj.PRDCTType
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@id_MainCategory",
                _VALUE = Senderobj.PRDCTMainCat
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@id_SubCategory",
                _VALUE = Senderobj.PRDCTSubCat
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@id_MProduct",
                _VALUE = id_MProductOUT
            };
            paramss.Add(parameters);

            string query = "UPDATE [tbl_Product] SET [id_Type] =@id_Type ,[id_MainCategory] =@id_MainCategory ,[id_SubCategory] =@id_SubCategory WHERE [id_MProduct]=@id_MProduct";
            db.Connect();
            List<ExcParameters> Psubk = new List<ExcParameters>();
            for (int i = 0; i < Senderobj.AllSubcategory_Keys_Vals.Count; i++)
            {
                parameters = new ExcParameters()
                {
                    _KEY = "@ItemSubCategoryKeyID",
                    _VALUE = Senderobj.AllSubcategory_Keys_Vals[i].ItemSubCategoryKeyID
                };
                Psubk.Add(parameters);
                parameters = new ExcParameters()
                {
                    _KEY = "@id_MProduct",
                    _VALUE = id_MProductOUT
                };
                Psubk.Add(parameters);
                string resultitemSe = db.Script("INSERT INTO [tbl_Product_ConnectorSCOK_Product]([id_MProduct],[id_SCOK])VALUES(@id_MProduct,@ItemSubCategoryKeyID)", Psubk);
                Psubk = new List<ExcParameters>();
            }
            string results = db.Script(query, paramss);
            db.DC();
            //EndOFStem2
            //================================================================
            //db.Script("INSERT INTO[tbl_Product_tblOptions]VALUES(" + id + ",N'" + Key + "',N'" + value + "')");
            Psubk = new List<ExcParameters>();
            if (Senderobj.TagTargetAdded != null)
            {

                db.Connect();
                for (int i = 0; i < Senderobj.TagTargetAdded.Count; i++)
                {
                    parameters = new ExcParameters()
                    {
                        _KEY = "@TagTargeName",
                        _VALUE = Senderobj.TagTargetAdded[i].TagTargeName
                    };
                    Psubk.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@TagTargeValue",
                        _VALUE = Senderobj.TagTargetAdded[i].TagTargeValue
                    };
                    Psubk.Add(parameters);
                    parameters = new ExcParameters()
                    {
                        _KEY = "@id_MProduct",
                        _VALUE = id_MProductOUT
                    };
                    Psubk.Add(parameters);
                    string resultitemtest = db.Script("INSERT INTO [tbl_Product_tblOptions] VALUES(@id_MProduct,@TagTargeName,@TagTargeValue)", Psubk);
                    Psubk = new List<ExcParameters>();
                }
            }
            //EndSection2
            //==================================================================
            //Section 3 Skiped andd calculating in step 4
            //...................................................................
            //==================================================================
            //Step4
            Int64 PriceXquantity = Convert.ToInt64(Senderobj.PRDCTPricePer1Demansion) * Convert.ToInt64(Senderobj.PRDCTDemansionValue);
            Int64 MultyPriceXquantity = Convert.ToInt64(Senderobj.PRDCTMultyPricePer1Demansion) * Convert.ToInt64(Senderobj.PRDCTDemansionValue);
            JaygashtCalculator calculator = new JaygashtCalculator();
            var jaygashts = calculator.Result(Senderobj.AllSubcategory_Keys_Vals);
            string itemid = "0";
            SaveJaygashtOfProducts SJOP = new SaveJaygashtOfProducts();
            db.Connect();
            foreach (var item in jaygashts)
            {
                itemid = SJOP.MainProduct_Actions("insert", id_MProductOUT, Senderobj.PRDCTDemansionValue, Senderobj.PRDCTDemansion, PriceXquantity.ToString(), Senderobj.PRDCTPricePer1Demansion, "0", "0", "0", Senderobj.PRDCTTagSectionOfProduct, Senderobj.PRDCTPriceDemansion, Senderobj.PRDCTPriceShowType, MultyPriceXquantity.ToString(),Senderobj.PRDCTMultyDemansionValue);
                foreach (var itm in item)
                {
                    string resultstiem = db.Script("INSERT INTO[tbl_Product_connectorToMPC_SCOV] VALUES(" + itemid + "," + itm.SubCategoryKeyValue + ")");
                }
            }
            db.DC();

            var ModelSender = new ErrorReporterModel
            {
                ErrorID = "SX10776",
                Errormessage = $"ساخت محصولات با موفقیت انجام شد!",
                Errortype = "Success",
                ImportantValsReturn = id_MProductOUT.ToString()
            };
            return Json(ModelSender);
        }

        public ActionResult ProductList()
        {

            ProductListTableModelView modelView = new ProductListTableModelView();
            modelView.Allrows = new List<ProductListTable>();
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_MProduct],(SELECT TOP 1 [id_MPC] FROM [tlb_Product_MainProductConnector] WHERE [tlb_Product_MainProductConnector].[id_MProduct] =[tbl_Product].[id_MProduct] ) as idMPC,[IS_AVAILABEL],[Description],[DateCreated],[Title],[id_SubCategory],[ISDELETE],(SELECT top 1 [thumUploadAddress] FROM [v_tblProduct_Image] where [v_tblProduct_Image].[id_MProduct]=[tbl_Product].[id_MProduct]) as [pic],(SELECT[PricePerquantity] FROM [tlb_Product_MainProductConnector] WHERE id_MPC=idMPC_WhichTomainPrice) AS price,(SELECT[ad_firstname]+' '+[ad_lastname] FROM [tbl_ADMIN_main]where id_Admin=[id_CreatedByAdmin])as AddBy,(SELECT [PTname]FROM [tbl_Product_Type]where[id_PT]=[id_Type])as [type],(SELECT[SCName]FROM [tbl_Product_SubCategory]where[id_SC]=[id_SubCategory])as SubCat,(SELECT[MCName]FROM [tbl_Product_MainCategory]where[id_MC]=[id_MainCategory])as MainCat FROM [tbl_Product] ORDER BY (DateCreated) DESC"))
            {
                db.DC();
                int dtrows = dt.Rows.Count;
                for (int i = 0; i < dtrows; i++)
                {
                    DateTime date = Convert.ToDateTime(dt.Rows[i]["DateCreated"]);
                    PersianDateTime persianDateTime = new PersianDateTime(date);
                    string aa = dt.Rows[i]["id_MProduct"].ToString();
                    string bb = dt.Rows[i]["idMPC"].ToString();
                    int bb2 = 0;
                    int aa2 = 0;
                    if (!string.IsNullOrEmpty(aa))
                        aa2 = Convert.ToInt32(aa);
                    if (!string.IsNullOrEmpty(bb))
                        bb2 = Convert.ToInt32(bb);
                    var model = new ProductListTable()
                    {
                        idMPC = bb2,
                        id = aa2,
                        Productname = dt.Rows[i]["Title"].ToString(),
                        ProductDescription = dt.Rows[i]["Description"].ToString(),
                        AdminSubmiterName = dt.Rows[i]["AddBy"].ToString(),
                        SubmitedDate = persianDateTime.ToString(),
                        PicThumnailUrl = dt.Rows[i]["pic"].ToString(),
                    };

                    if (dt.Rows[i]["IS_AVAILABEL"].ToString() == "1")
                    {
                        model.ActivateStatus = 1;
                    }
                    else
                    {
                        model.ActivateStatus = 2;
                    }
                    if (dt.Rows[i]["ISDELETE"].ToString() == "1")
                    {
                        model.ActivateStatus = 3;
                    }
                    model.AllCategorys = new List<Categors>();
                    model.AllCategorys.Add(new Categors()
                    {
                        CategorColor = "success",
                        CategorName = dt.Rows[i]["SubCat"].ToString()

                    });
                    model.AllCategorys.Add(new Categors()
                    {
                        CategorColor = "info",
                        CategorName = dt.Rows[i]["MainCat"].ToString()

                    });
                    model.AllCategorys.Add(new Categors()
                    {
                        CategorColor = "danger",
                        CategorName = dt.Rows[i]["type"].ToString()

                    });
                    modelView.Allrows.Add(model);
                }
            }
            return View(modelView);
        }

        [HttpPost]
        public JsonResult ActiveProduct(string idToActive)
        {
            PDBC db = new PDBC();
            ExcParameters par = new ExcParameters()
            {
                _KEY = "@id_MProduct",
                _VALUE = idToActive
            };
            List<ExcParameters> parss = new List<ExcParameters>();
            parss.Add(par);
            db.Connect();
            string res = db.Script("UPDATE [tbl_Product] SET [IS_AVAILABEL] = 1 WHERE id_MProduct=@id_MProduct", parss);
            if (res == "1")
            {
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "SX106453243",
                    Errormessage = $"این محصول با موفقیت فعال شد!",
                    Errortype = "Success"
                };
                return Json(ModelSender);
            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX11552345",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }

        [HttpPost]
        public JsonResult DeActiveProduct(string idToDEActive)
        {
            PDBC db = new PDBC();
            ExcParameters par = new ExcParameters()
            {
                _KEY = "@id_MProduct",
                _VALUE = idToDEActive
            };
            List<ExcParameters> parss = new List<ExcParameters>();
            parss.Add(par);
            db.Connect();
            string res = db.Script("UPDATE [tbl_Product] SET [IS_AVAILABEL] = 0 WHERE id_MProduct = @id_MProduct", parss);
            if (res == "1")
            {
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "SX1124543",
                    Errormessage = $"این محصول با موفقیت غیر فعال شد!",
                    Errortype = "Success"
                };
                return Json(ModelSender);
            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115098945",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }

        [HttpPost]
        public JsonResult DeleteProduct(string idTodelete)
        {
            PDBC db = new PDBC();
            ExcParameters par = new ExcParameters()
            {
                _KEY = "@id_MProduct",
                _VALUE = idTodelete
            };
            List<ExcParameters> parss = new List<ExcParameters>();
            parss.Add(par);
            db.Connect();
            string res = db.Script("UPDATE [tbl_Product] SET [ISDELETE] = 1 WHERE id_MProduct = @id_MProduct", parss);
            if (res == "1")
            {
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "SX1124543",
                    Errormessage = $"این محصول با موفقیت حذف شد!",
                    Errortype = "Success"
                };
                return Json(ModelSender);
            }
            else
            {
                PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "sher o ver e L326");
                var ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX115098945",
                    Errormessage = $"عدم توانایی در ثبت اطلاعات!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
        }
        [HttpPost]
        public ActionResult AddproductStep5Stockpile(string id_MProduct)
        {
            int id_MProductOUT = 0;
            if (!Int32.TryParse(id_MProduct, out id_MProductOUT))
            {
                return HttpNotFound();
            }
            AddproductStep5StockpileModelView model = new AddproductStep5StockpileModelView();
            model.AllProducts = new List<AddproductStep5Stockpile>();
            PDBC db = new PDBC();
            ExcParameters par = new ExcParameters()
            {
                _KEY = "@id_MProduct",
                _VALUE = id_MProduct
            };
            List<ExcParameters> pars = new List<ExcParameters>();
            pars.Add(par);
            db.Connect();
            using (DataTable dt = db.Select("SELECT [MultyPriceStartFromQ] ,[MultyPrice], [Quantity] ,[PricePerquantity] ,[Title] ,[PQT_Demansion] ,[MoneyTypeName] ,[id_MPC] FROM [v_Connector_MainProductConnectorToProduct] WHERE [id_MProduct] =@id_MProduct", pars))
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AddproductStep5Stockpile stockpile = new AddproductStep5Stockpile()
                    {
                        id_MPC = dt.Rows[i]["id_MPC"].ToString(),
                        MoneyType = dt.Rows[i]["MoneyTypeName"].ToString(),
                        ProductName = dt.Rows[i]["Title"].ToString(),
                        productPricePerQT = dt.Rows[i]["PricePerquantity"].ToString(),
                        productQT = dt.Rows[i]["Quantity"].ToString(),
                        QTDemansion = dt.Rows[i]["PQT_Demansion"].ToString(),
                        MultyproductPricePerQT = dt.Rows[i]["MultyPrice"].ToString(),
                        MultyproductQT = dt.Rows[i]["MultyPriceStartFromQ"].ToString(),
                    };
                    stockpile.ProductsJaygashtList = new List<ProductViewDetails_ProductSOCKandSOCKVL>();
                    using (DataTable dtJ = db.Select("SELECT  [SCOKName] ,[SCOVValueName] FROM [v_ConnectorTheProductConnectorViewToSCOVandSCOKV_s] WHERE [id_MPC] = " + stockpile.id_MPC))
                    {
                        for (int j = 0; j < dtJ.Rows.Count; j++)
                        {
                            stockpile.ProductsJaygashtList.Add(new ProductViewDetails_ProductSOCKandSOCKVL()
                            {
                                BootstrapColor = BootstrapColorPicker.GetbootstrapColorRandomByCounter(j)
                                ,
                                SOCKName = dtJ.Rows[j]["SCOKName"].ToString(),
                                SOCKVName = dtJ.Rows[j]["SCOVValueName"].ToString()
                            });
                        }
                    }
                    model.AllProducts.Add(stockpile);
                }
                db.DC();

            }
            return View(model);
        }

        [HttpPost]
        public JsonResult SaveDataToStockpileStep5(SaveDataToStockpileStep5[] ArryTosend)
        {
            ExcParameters par = new ExcParameters();
            List<ExcParameters> pars = new List<ExcParameters>();
            PDBC db = new PDBC();
            db.Connect();
            for (int i = 0; i < ArryTosend.Length; i++)
            {
                pars = new List<ExcParameters>();
                par = new ExcParameters()
                {
                    _KEY = "@Quantity",
                    _VALUE = ArryTosend[i].QTnumeric
                };
                pars.Add(par);
                par = new ExcParameters()
                {
                    _KEY = "@PricePerquantity",
                    _VALUE = ArryTosend[i].PriceNumeric
                };
                pars.Add(par);

                par = new ExcParameters()
                {
                    _KEY = "@PriceXquantity",
                    _VALUE = Convert.ToInt64(ArryTosend[i].PriceNumeric) * Convert.ToInt64(ArryTosend[i].QTnumeric)
                };
                pars.Add(par);
                par = new ExcParameters()
                {
                    _KEY = "@id_MPC",
                    _VALUE = ArryTosend[i].idMPC
                };
                pars.Add(par);
                par = new ExcParameters()
                {
                    _KEY = "@MultyPrice",
                    _VALUE = ArryTosend[i].MultyproductPricePerQT
                };
                pars.Add(par);
                par = new ExcParameters()
                {
                    _KEY = "@MultyPriceStartFromQ",
                    _VALUE = ArryTosend[i].MultyproductQT
                };
                pars.Add(par);
                string aa = db.Script("UPDATE [tlb_Product_MainProductConnector] SET  [Quantity] = @Quantity ,[PriceXquantity] = @PriceXquantity ,[PricePerquantity] = @PricePerquantity,[MultyPriceStartFromQ] = @MultyPriceStartFromQ  ,[MultyPrice] = @MultyPrice  WHERE [id_MPC] = @id_MPC", pars);
                pars = new List<ExcParameters>();
                if (aa != "1")
                {
                    PPBugReporter reps = new PPBugReporter(BugTypeFrom.SQL, "tlb_Product_MainProductConnector");
                    var ModelSenders = new ErrorReporterModel
                    {
                        ErrorID = "EX115098945",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات! tlb_Product_MainProductConnector",
                        Errortype = "Error"
                    };
                    return Json(ModelSenders);
                }
                par = new ExcParameters()
                {
                    _KEY = "id_MPC",
                    _VALUE = ArryTosend[i].idMPC
                };
                pars.Add(par);
                par = new ExcParameters()
                {
                    _KEY = "code_Stockpile",
                    _VALUE = ArryTosend[i].ProductCode
                };
                pars.Add(par);
                aa = db.Script("UPDATE  [tbl_Modules_StockpileMainTable]  SET [code_Stockpile] = @code_Stockpile  WHERE [id_MPC] =@id_MPC", pars);
                if (aa != "1")
                {
                    PPBugReporter rep1 = new PPBugReporter(BugTypeFrom.SQL, "tbl_Modules_StockpileMainTable");
                    var ModelSender1 = new ErrorReporterModel
                    {
                        ErrorID = "EX115098945",
                        Errormessage = $"عدم توانایی در ثبت اطلاعات! tbl_Modules_StockpileMainTable",
                        Errortype = "Error"
                    };
                    return Json(ModelSender1);
                }
            }
            db.DC();


            var ModelSender = new ErrorReporterModel
            {
                ErrorID = "SX105675",
                Errormessage = $"اطلاعات با موفقیت ثبت شد!",
                Errortype = "Success"
            };
            return Json(ModelSender);
        }
        //========================================================



    }
}