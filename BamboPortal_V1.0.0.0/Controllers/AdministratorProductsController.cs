using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using BamboPortal_V1._0._0._0.ModelViews.AdministratorProducts;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            return Json("");
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
                string result = db.Script("INSERT INTO [tbl_Product_SubCategoryOptionValue]VALUES(@data_SCK,@value)", paramss);
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
            return View();
        }
        //{END}For Product  AddProduct
        //=================================================================================================================

        public ActionResult ProductList()
        {
            return View();
        }
    }
}