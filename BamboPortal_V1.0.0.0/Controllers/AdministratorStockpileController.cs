﻿using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using BamboPortal_V1._0._0._0.Models.AdministratorStockpile;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using BamboPortal_V1._0._0._0.ModelViews.AdministratorStockpile;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.StaticClass.BugReporter;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorStockpileController : AdminRulesController
    {
        // GET: AdministratorStockpile
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProductInStockpile(int PSID)
        {


            ProductInStockpileModelView model = new ProductInStockpileModelView();

            PDBC db = new PDBC();
           
            ExcParameters par = new ExcParameters()
            {
                _KEY = "@id_MPC",
                _VALUE = PSID
            };
            List<ExcParameters> pars = new List<ExcParameters>();
            pars.Add(par);
            string id_MProductReal = "";
            db.Connect();
            using (DataTable dtproduct = db.Select("SELECT [id_MProduct],[id_MPC],[id_PQT],[IS_AVAILABEL],[id_DraftLevel],[id_Type],[id_MainCategory],[id_SubCategory],[idMPC_WhichTomainPrice],[Description],[DateCreated],[Title],[Seo_Description],[Seo_KeyWords],[IS_AD],[Search_Gravity],[Is_IntheDraft],[ISDELETE],[PTname],[ISDESABLED],[tbl_Product_Type_ISDelete],[MCName],[SCName],[Quantity],[PriceXquantity],[PricePerquantity],[PriceOff],[offTypeValue],[OffType],[tlb_Product_MainProductConnector_ISDELETE],[OutOfStock],[DateToRelease],[PriceShow],[PriceShowformat],[id_CreatedByAdmin],[ad_NickName],[ad_firstname],[ad_lastname],[id_MainStarTag],[PQT_Description],[PQT_Demansion],[PQT_Quantom],[code_Stockpile],[MoneyTypeName],[MultyPrice] ,[MultyPriceStartFromQ]  FROM [v_Connector_MainProductConnectorToProduct] WHERE [id_MPC] = @id_MPC", pars))
            {
                db.DC();
                if (dtproduct.Rows.Count > 0)
                {
                    id_MProductReal = dtproduct.Rows[0]["id_MProduct"].ToString();

                    model.ShowPSIDs = new ShowPSID()
                    {
                        id_MPC = PSID.ToString(),//check
                        MultyPriceStartFromQ = dtproduct.Rows[0]["MultyPriceStartFromQ"].ToString(),
                        PicList = new List<string>(),//check
                        ProductCode = dtproduct.Rows[0]["code_Stockpile"].ToString(),
                        ProductDescription = dtproduct.Rows[0]["Description"].ToString(),
                        ProductMultyPrice = dtproduct.Rows[0]["MultyPrice"].ToString(),
                        ProductName = dtproduct.Rows[0]["Title"].ToString(),
                        ProductPurePrice = dtproduct.Rows[0]["PricePerquantity"].ToString(),
                        ShopAvailable4Transaction = new List<Key_ValueModel>(),
                        ShopList = new List<Shops>(),//check
                        socKandSockvlList = new List<ProductViewDetails_ProductSOCKandSOCKVLList>(),//check
                        STHList = new List<StockpileTransactionHistoryModel>()//check
                    };

                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            //===========================pics
            db.Connect();
            using (DataTable dt = db.Select("SELECT [orgUploadAddress] FROM [v_tblProduct_Image] WHERE [id_MProduct]=" + id_MProductReal))
            {
                db.DC();
                int dtrows = dt.Rows.Count;
                for (int i = 0; i < dtrows; i++)
                {
                    model.ShowPSIDs.PicList.Add(dt.Rows[i]["orgUploadAddress"].ToString());
                }
            }
            if (model.ShowPSIDs.PicList.Count == 0)
            {
                model.ShowPSIDs.PicList.Add("/AdminDesignResource/app/media/img/users/user4.jpg");
            }
            //==============================Shops
            db.Connect();
            using (DataTable dtstock = db.Select("SELECT  [id_Stockpile]  ,[id_Stockpile_AllowType] ,[shop_id] ,[shop_name] ,[shop_IsAvailable] ,[shop_IsDelete]  FROM [v_Stockpile_MainView] WHERE [id_MPC] = " + PSID))
            {
                db.DC();
                for (int i = 0; i < dtstock.Rows.Count; i++)
                {
                    bool CalCulatingFromShops = false;
                    if (dtstock.Rows[i]["id_Stockpile_AllowType"].ToString() == "1")
                    {
                        CalCulatingFromShops = true;
                    }
                    bool ISActivate = false;
                    if (dtstock.Rows[i]["shop_IsDelete"].ToString() == "0" && dtstock.Rows[i]["shop_IsAvailable"].ToString() == "1")
                    {
                        ISActivate = true;
                    }
                    //ProductCALCULATOR
                    Int64 ProductAvailableCount = 0;
                    string BootstrapColor = "";
                    if (ProductAvailableCount > 200)
                    {
                        BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.success);
                    }
                    else if (ProductAvailableCount > 100)
                    {
                        BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.warning);
                    }
                    else
                    {
                        BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.danger);
                    }
                    model.ShowPSIDs.ShopList.Add(new Shops()
                    {
                        ShopName = dtstock.Rows[i]["shop_name"].ToString(),
                        CalCulatingFromShop = CalCulatingFromShops,
                        ISActivate = ISActivate,
                        ProductAvailableCount = String.Format("{0:n0}", ProductAvailableCount),
                        BootstrapColor = BootstrapColor
                    });
                }
            }

            //===================================socKandSockvlList
            db.Connect();
            using (DataTable dtproduct = db.Select("SELECT [PTname], [MCName],[SCName]  FROM [v_Connector_MainProductConnectorToProduct] WHERE [id_MPC] = " + PSID))
            {
                using (DataTable dt = db.Select("SELECT [id_MPC] ,[SCOKName] ,[SCOVValueName] FROM [v_ConnectorTheProductConnectorViewToSCOVandSCOKV_s] WHERE [id_MProduct] = " + id_MProductReal + " ORDER BY [id_MPC] DESC"))
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
                                    model.ShowPSIDs.socKandSockvlList.Add(products);
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
                                model.ShowPSIDs.socKandSockvlList.Add(products);
                            }
                        }

                    }
                    else
                    {
                        return RedirectToAction("index");
                    }
                }

            }

            //=-=======================================StockpileTransactionHistoryModel

            db.Connect();
            using (DataTable dt = db.Select("SELECT [shop_id], [id_TransactionType], [PQT_Demansion],[PQTValueOf_Transaction],[PriceOf_Transaction],[shop_name],[StockpileDate_Transaction],[StockpileTime_Transaction],[MoneyTypeName] FROM  [v_Stockpile_Transactions] WHERE [id_MPC] = " + PSID + " ORDER BY [id_Transaction] DESC"))
            {
                db.DC();
                int dtcount = dt.Rows.Count;
                if (dtcount > 0)
                {
                    for (int i = 0; i < dtcount; i++)
                    {
                        StockpileTransactionHistoryModel historyModel = new StockpileTransactionHistoryModel();
                        // {
                        //     BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.danger),
                        //     Dimension = "موردی یافت نشد",
                        //     HajmSadere = "موردی یافت نشد",x
                        //     HajmVarede = "موردی یافت نشد",x
                        //     MiyanginGheymateSadere = "موردی یافت نشد"x
                        //,
                        //     MiyanginGheymateVarede = "موردی یافت نشد",x
                        //     Mojoodi = "موردی یافت نشد",x
                        //     ShopID = "موردی یافت نشد",x
                        //     ShopName = "موردی یافت نشد",x
                        //     TotalPriceOfsadere = "موردی یافت نشد",x
                        //     TotalPriceOfVarede = "موردی یافت نشد",x
                        //     TransActionDate = "موردی یافت نشد",x
                        // };
                        historyModel.ShopID = dt.Rows[i]["shop_id"].ToString();
                        historyModel.ShopName = dt.Rows[i]["shop_name"].ToString();
                        historyModel.Mojoodi = "0";
                        historyModel.TransActionDate = dt.Rows[i]["StockpileDate_Transaction"].ToString() + " " + dt.Rows[i]["StockpileTime_Transaction"].ToString();
                        historyModel.Dimension = dt.Rows[i]["PQT_Demansion"].ToString();

                        if (dt.Rows[i]["id_TransactionType"].ToString() == "1")
                        {
                            historyModel.BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.success);
                            historyModel.HajmSadere = "0";
                            historyModel.MiyanginGheymateSadere = "0";
                            historyModel.TotalPriceOfsadere = "0";
                            historyModel.HajmVarede = String.Format("{0:n0}", dt.Rows[i]["PQTValueOf_Transaction"].ToString());
                            historyModel.MiyanginGheymateVarede = "0";
                            historyModel.TotalPriceOfVarede = String.Format("{0:n0}", dt.Rows[i]["PriceOf_Transaction"].ToString())+" "+ dt.Rows[i]["PQT_Demansion"].ToString();
                        }
                        else
                        {
                            historyModel.BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.danger);
                            historyModel.HajmVarede = "0";
                            historyModel.MiyanginGheymateVarede = "0";
                            historyModel.TotalPriceOfVarede = "0";
                            historyModel.HajmSadere = String.Format("{0:n0}", dt.Rows[i]["PQTValueOf_Transaction"].ToString());
                            historyModel.MiyanginGheymateSadere = "0";
                            historyModel.TotalPriceOfsadere = String.Format("{0:n0}", dt.Rows[i]["PriceOf_Transaction"].ToString()) + " " + dt.Rows[i]["PQT_Demansion"].ToString();

                        }



                        model.ShowPSIDs.STHList.Add(historyModel);
                    }
                }
                else
                {
                    StockpileTransactionHistoryModel historyModel = new StockpileTransactionHistoryModel()
                    {
                        BootstrapColor = BootstrapColorPicker.GetbootstrapColorByTag(BootstrapColorEnums.danger),
                        Dimension = "موردی یافت نشد",
                        HajmSadere = "موردی یافت نشد",
                        HajmVarede = "موردی یافت نشد",
                        MiyanginGheymateSadere = "موردی یافت نشد"
                        ,
                        MiyanginGheymateVarede = "موردی یافت نشد",
                        Mojoodi = "موردی یافت نشد",
                        ShopID = "موردی یافت نشد",
                        ShopName = "موردی یافت نشد",
                        TotalPriceOfsadere = "موردی یافت نشد",
                        TotalPriceOfVarede = "موردی یافت نشد",
                        TransActionDate = "موردی یافت نشد",
                    };
                    model.ShowPSIDs.STHList.Add(historyModel);
                }
            }


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetVaredeAndSadere(ProductInStockpileModelView SenderObj)
        {
            if (ModelState.IsValid)
            {
                if (SenderObj != null)
                {
                    int id_Mpc = 0;
                    if (Int32.TryParse(SenderObj.InOutStructures.id_Mpc, out id_Mpc))
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
                        PDBC db = new PDBC();
                        db.Connect();
                        using (DataTable dt = db.Select("SELECT [id_PQT] ,[PriceModule] FROM [tlb_Product_MainProductConnector] WHERE [id_MPC] = " + id_Mpc))
                        {
                            using (DataTable dtStockpile = db.Select("SELECT [id_Stockpile]  FROM [tbl_Modules_StockpileMainTable] WHERE [id_MPC] = " + id_Mpc))
                            {
                                db.DC();
                                if (dtStockpile.Rows.Count > 0)
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        List<ExcParameters> allpars = new List<ExcParameters>();
                                        ExcParameters par = new ExcParameters()
                                        {
                                            _KEY = "@id_TransactionType",
                                            _VALUE = SenderObj.InOutStructures.Whichone
                                        };
                                        allpars.Add(par);
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@id_Stockpile",
                                            _VALUE = dtStockpile.Rows[0]["id_Stockpile"].ToString()
                                        };
                                        allpars.Add(par);
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@shop_id",
                                            _VALUE = SenderObj.InOutStructures.Shopid
                                        };
                                        allpars.Add(par);
                                        DateTime dateTime = DateTime.Parse(SenderObj.InOutStructures.ActionDate);
                                        PersianDateTime persianDateTime = new PersianDateTime(dateTime);

                                        par = new ExcParameters()
                                        {
                                            _KEY = "@StockpileDate_Transaction",
                                            _VALUE = persianDateTime.ToDateTime()
                                        };
                                        allpars.Add(par);
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@StockpileTime_Transaction",
                                            _VALUE = SenderObj.InOutStructures.Time
                                        };
                                        allpars.Add(par);
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@id_PQT",
                                            _VALUE = dt.Rows[0]["id_PQT"].ToString()
                                        };
                                        allpars.Add(par);
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@MoneyId",
                                            _VALUE = dt.Rows[0]["PriceModule"].ToString()
                                        };
                                        allpars.Add(par);
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@PriceOf_Transaction",
                                            _VALUE = SenderObj.InOutStructures.INOUTPrice
                                        };
                                        allpars.Add(par);
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@PQTValueOf_Transaction",
                                            _VALUE = SenderObj.InOutStructures.INOUTValue
                                        };
                                        allpars.Add(par);
                                        if (!string.IsNullOrEmpty(SenderObj.InOutStructures.Description))
                                        {
                                            par = new ExcParameters()
                                            {
                                                _KEY = "@Description_Transaction",
                                                _VALUE = SenderObj.InOutStructures.Description
                                            };
                                            allpars.Add(par);
                                        }
                                        else
                                        {
                                            par = new ExcParameters()
                                            {
                                                _KEY = "@Description_Transaction",
                                                _VALUE = ""
                                            };
                                            allpars.Add(par);
                                        }
                                        par = new ExcParameters()
                                        {
                                            _KEY = "@id_SubmiterAdmin",
                                            _VALUE = id_CreatedByAdmin
                                        };
                                        allpars.Add(par);


                                        db.Connect();
                                        string result = db.Script("INSERT INTO [tbl_Modules_StockpileTransactionMainTable]([id_TransactionType],[id_Stockpile],[shop_id],[StockpileDate_Transaction],[StockpileTime_Transaction],[id_PQT],[MoneyId],[PriceOf_Transaction],[PQTValueOf_Transaction],[Description_Transaction],[id_SubmiterAdmin]) VALUES(@id_TransactionType,@id_Stockpile,@shop_id,@StockpileDate_Transaction,@StockpileTime_Transaction,@id_PQT,@MoneyId,@PriceOf_Transaction,@PQTValueOf_Transaction,@Description_Transaction,@id_SubmiterAdmin)", allpars);
                                        db.DC();
                                        if (result == "1")
                                        {
                                            var ModelSender = new ErrorReporterModel
                                            {
                                                ErrorID = "SX1645605",
                                                Errormessage = $"اطلاعات با موفقیت ثبت شد!",
                                                Errortype = "Success"
                                            };
                                            return Json(ModelSender);
                                        }
                                        else
                                        {
                                            PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorStockpileController}\nMethod : {public JsonResult GetVarede(ProductInStockpileModelView senderObj)  Script : INSERT INTO [tbl_Modules_StockpileTransactionMainTable]([id_TransactionType],[id_Stockpile],[shop_id],[Submitdate_Transaction],[StockpileDate_Transaction],[StockpileTime_Transaction],[id_PQT],[MoneyId],[PriceOf_Transaction],[PQTValueOf_Transaction],[Description_Transaction],[id_SubmiterAdmin]) VALUES(@id_TransactionType,@id_Stockpile,@shop_id,@Submitdate_Transaction,@StockpileDate_Transaction,@StockpileTime_Transaction,@id_PQT,@MoneyId,@PriceOf_Transaction,@PQTValueOf_Transaction,@Description_Transaction,@id_SubmiterAdmin) ||| Result :" + result);
                                            var ModelSender = new ErrorReporterModel
                                            {
                                                ErrorID = "EX1186781",
                                                Errormessage = $"عدم توانایی در ثبت اطلاعات",
                                                Errortype = "Error"
                                            };
                                            return Json(ModelSender);
                                        }

                                    }
                                    else
                                    {
                                        var ModelSender = new ErrorReporterModel
                                        {
                                            ErrorID = "EX645756697",
                                            Errormessage = $"محصول مورد نظر یافت نشد",
                                            Errortype = "Error"
                                        };
                                        return Json(ModelSender);
                                    }
                                }
                                else
                                {
                                    var ModelSender = new ErrorReporterModel
                                    {
                                        ErrorID = "EX645697",
                                        Errormessage = $"محصول مورد نظر یافت نشد",
                                        Errortype = "Error"
                                    };
                                    return Json(ModelSender);
                                }


                            }
                        }
                    }
                    else
                    {
                        var ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX1897",
                            Errormessage = $"اطلاعات وارده خلاف متغیر های قانونی میباشد!",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }
                }
                else
                {
                    PPBugReporter rep = new PPBugReporter(BugTypeFrom.SQL, "IN Controller : {AdministratorStockpileController}\nMethod : {public JsonResult GetVarede(ProductInStockpileModelView senderObj)  (senderObj == null)");
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
                            IdOfProperty = AllKeys[i].Replace("InOutStructures.", "InOutStructures_"),
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



            return Json("");
        }

    }
}