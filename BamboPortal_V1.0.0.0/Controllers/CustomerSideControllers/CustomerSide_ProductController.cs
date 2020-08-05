using BamboPortal_V1._0._0._0.ModelFiller.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using Newtonsoft.Json;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using System.Data;
using BamboPortal_V1._0._0._0.Models;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class CustomerSide_ProductController : CustomerSide_CustomerRuleController
    {
        public ActionResult customershoppingCart()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            if (HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode()) != null)
            {
                var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
                tcm = CoockieController.SayWhoIsHE(coockie.Value);
            }
            else
            {
                return RedirectToAction("loginandregister", "CustomerSide_Register");
            }
            int CustomerId = Convert.ToInt32(tcm.id_Customer);

            if (HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket()) != null)
            {
                var coockie = JsonConvert.DeserializeObject<ShoppingBasket>(HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket()).Value);
                var model = new ShoppingCartModelView()
                {
                    FactorModel = modelFiller.shoppingCart(coockie),
                    Ostan = modelFiller.Ostanha(),
                    Adresses = modelFiller.CustomerAddresses(CustomerId),
                    Customer = modelFiller.customerDetail(CustomerId)
                };

                FactorPopUpModel fpm = model.FactorModel;
                var userCookieIDV = new HttpCookie(ProjectProperies.CustomerShoppingFactor());
                userCookieIDV.Value = CoockieController.SetCustomerShopFactorCookie(fpm);
                userCookieIDV.Expires = DateTime.Now.AddDays(2);
                Response.SetCookie(userCookieIDV);
                return View(model);
            }
            else
            {
                return RedirectToAction("index", "CustomerSide_Pages");
            }
        }

        public ActionResult factor()
        {

            CustomerModelFiller modelFiller = new CustomerModelFiller();
            ///این متغیر پر بشه
            int CustomerId = 1009;

            return View(modelFiller.Customers_Factors("همه", CustomerId, "Date"));
        }

        public ActionResult productpage(int ProId)
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            ///این متغیرها پر بشه

            var model = new ProductDetail_ModelView()
            {
                ProductModel = modelFiller.SingleProduct(ProId, "Ago"),
                Sale_Products = modelFiller.ChosenProducts("Sale", 4, "Ago")
            };


            return View(model);
        }

        public ActionResult search(string Type, int Id = 0, int Page = 1, string Search = "")
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();

            ///این متغیر پر بشه
            int CustomerId = 1009;
            var model = new SearchPageModelView()
            {
                Cat = Type,
                CatId = Id,
                Cateqories = modelFiller.CategoriesAsTree_OneSub("MainCat", 1),
                thisPage = Page,
                Search = Search
            };

            if (Type == "پرفروش ها")
            {
                model.Products = modelFiller.ChosenProducts("Sale", 12, "Ago");
                model.Pages = 1;
            }
            else if (Type == "جدیدترین")
            {
                model.Products = modelFiller.ChosenProducts("New", 12, "Ago");
                model.Pages = 1;
            }
            else if (Type == "فروش ویژه")
            {
                model.Products = modelFiller.ChosenProducts("MainTag", 12, "Ago", 1);
                model.Pages = 1;
            }
            //else if (Type == "علاقه مندی ها")
            //{
            //    model.Products = modelFiller.FavoriteProducts(12, Type, Id, Page, Search, "Date", CustomerId);
            //    model.Pages = modelFiller.ProList_Pages(Type, 12, Id, Search, CustomerId);
            //}
            else
            {
                model.Products = modelFiller.ProductList(12, Type, Id, Page, Search, "Date");
                model.Pages = modelFiller.ProList_Pages(Type, 12, Id, Search);
            }


            return View(model);
        }

        public ActionResult ShoppingCartSlide()
        {
            ShoppingBasket model = new ShoppingBasket();
            if (HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode()) != null)
            {
                model.islogin = true;
            }
            else
            {
                model.islogin = false;
            }


            if (HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket()) != null)
            {
                model = JsonConvert.DeserializeObject<ShoppingBasket>(HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket()).Value);
            }
            else
            {
                model = new ShoppingBasket()
                {
                    Items = new List<ShoppingBasketItems>()
                };
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult GetMPCs(int id)
        {
            CustomerModelFiller DMF = new CustomerModelFiller();
            return Json(DMF.MPCs(id));
        }

        [HttpPost]
        public JsonResult ProductCountCalc(string QCount, string idmpc)
        {
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [Title],[MCName] ,[SCName],[PriceXquantity],[MultyPrice],[MultyPriceStartFromQ]  FROM [v_Connector_MainProductConnectorToProduct] WHERE [id_MPC] = " + idmpc))
            {
                db.DC();
                var ModelSender = new ErrorReporterModel();
                if (dt.Rows.Count == 0)
                {
                    ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX1153455",
                        Errormessage = $"محصول یافت نشد!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    if (Convert.ToInt32(QCount) > Convert.ToInt32(dt.Rows[0]["MultyPriceStartFromQ"].ToString()))
                    {
                        FactorPopUpModel fpm = CoockieController.GetCustomerShopFactorCookie(HttpContext.Request.Cookies.Get(ProjectProperies.CustomerShoppingFactor()).Value);
                        for (int i = 0; i < fpm.items.Count; i++)
                        {
                            if (fpm.items[i].Id == Convert.ToInt32(idmpc))
                            {
                                fpm.items[i].PriceXQ = Convert.ToInt64(dt.Rows[0]["MultyPrice"].ToString());
                                fpm.items[i].number = Convert.ToInt32(QCount);
                                fpm.items[i].total = fpm.items[i].PriceXQ * fpm.items[i].number;
                                break;
                            }
                        }
                        Int64 totality = 0;
                        for (int i = 0; i < fpm.items.Count; i++)
                        {
                            totality += fpm.items[i].total;
                        }
                        fpm.totality = totality.ToString();
                        ModelSender = new ErrorReporterModel
                        {
                            ErrorID = dt.Rows[0]["MultyPrice"].ToString(),
                            Errormessage = $"",
                            Errortype = "Success"
                        };
                        var userCookieIDV = new HttpCookie(ProjectProperies.CustomerShoppingFactor());
                        userCookieIDV.Value = CoockieController.SetCustomerShopFactorCookie(fpm);
                        userCookieIDV.Expires = DateTime.Now.AddDays(2);
                        Response.SetCookie(userCookieIDV);
                        return Json(ModelSender);
                    }
                    else
                    {
                        FactorPopUpModel fpm = CoockieController.GetCustomerShopFactorCookie(HttpContext.Request.Cookies.Get(ProjectProperies.CustomerShoppingFactor()).Value);
                        for (int i = 0; i < fpm.items.Count; i++)
                        {
                            if (fpm.items[i].Id == Convert.ToInt32(idmpc))
                            {
                                fpm.items[i].PriceXQ = Convert.ToInt64(dt.Rows[0]["PriceXquantity"].ToString());
                                fpm.items[i].number = Convert.ToInt32(QCount);
                                fpm.items[i].total = fpm.items[i].PriceXQ * fpm.items[i].number;
                                break;
                            }
                        }
                        Int64 totality = 0;
                        for (int i = 0; i < fpm.items.Count; i++)
                        {
                            totality += fpm.items[i].total;
                        }
                        fpm.totality = totality.ToString();
    
                        var userCookieIDV = new HttpCookie(ProjectProperies.CustomerShoppingFactor());
                        userCookieIDV.Value = CoockieController.SetCustomerShopFactorCookie(fpm);
                        userCookieIDV.Expires = DateTime.Now.AddDays(2);
                        Response.SetCookie(userCookieIDV);
                        ModelSender = new ErrorReporterModel
                        {
                            ErrorID = dt.Rows[0]["PriceXquantity"].ToString(),
                            Errormessage = $"",
                            Errortype = "Success"
                        };
                        return Json(ModelSender);
                    }
                }
            }
        }

        [HttpPost]
        public JsonResult SubmitFactor(string ABC)
        {
            // kollan bazbini mikhad
            var ModelSender = new ErrorReporterModel();
            PDBC db = new PDBC();
            List<ExcParameters> pas = new List<ExcParameters>();
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            tcm = CoockieController.SayWhoIsHE(coockie.Value);
            FactorPopUpModel fpm = CoockieController.GetCustomerShopFactorCookie(HttpContext.Request.Cookies.Get(ProjectProperies.CustomerShoppingFactor()).Value);

            ExcParameters pa = new ExcParameters()
            {
                _KEY = "@id_Customer",
                _VALUE = tcm.id_Customer
            };
            pas.Add(pa);
            pa = new ExcParameters()
            {
                _KEY = "@MainFactor_Code",
                _VALUE = "FM-"+DateTime.Now.Ticks
            };
            pas.Add(pa);
            pa = new ExcParameters()
            {
                _KEY = "@MainFactor_Price",
                _VALUE = fpm.totality
            };
            pas.Add(pa);
            pa = new ExcParameters()
            {
                _KEY = "@MainFactor_PaymentCode",
                _VALUE = "FMpc-" + DateTime.Now.Ticks
            };
            pas.Add(pa);
            pa = new ExcParameters()
            {
                _KEY = "@MainFactor_CreatorID",
                _VALUE = tcm.id_Customer
            };
            pas.Add(pa);
            pa = new ExcParameters()
            {
                _KEY = "@id_CAddress",
                _VALUE = "4003"
            };
            pas.Add(pa);
            db.Connect();
            string ReturnedID = db.Script("INSERT INTO [tbl_Factor_Main]([id_Customer],[MainFactor_Code],[MainFactor_Price],[MainFactor_IsPay],[MainFactor_PayMessage],[MainFactor_PaymentCode],[MainFactor_Tax],[MainFactor_TotalOff],[MainFactor_CreatedByUserType],[MainFactor_CreatorID],[MainFactor_ISEDITED],[MainFactor_EditedByAdminID],[MainFactor_EditedTo_id_MainFactor],[MainFactor_IsDeleted],[MainFactor_IsReturnedMoney],[MainFactor_PayType],[ChildFactor_DeleteTypeID],[id_CAddress]) output inserted.[id_MainFactor]     VALUES(@id_Customer ,@MainFactor_Code ,@MainFactor_Price ,1,N'NOMessage',@MainFactor_PaymentCode,0,0,2,@MainFactor_CreatorID ,0,0,0,0,0,1,0,@id_CAddress )", pas);
            db.DC();
            int idmf = 0;
            if(Int32.TryParse(ReturnedID,out idmf))
            {
                string flag = "";
                pas = new List<ExcParameters>();
                string res = "";
                for(int i = 0; i < fpm.items.Count; i++)
                {
                    pa = new ExcParameters()
                    {
                        _KEY = "@id_MainFactor",
                        _VALUE = ReturnedID
                    };
                    pas.Add(pa);
                    pa = new ExcParameters()
                    {
                        _KEY = "@ChildFactor_CreatorID",
                        _VALUE = tcm.id_Customer
                    };
                    pas.Add(pa);
                    pa = new ExcParameters()
                    {
                        _KEY = "@ChildFactor_ProductID",
                        _VALUE = fpm.items[i].Id
                    };
                    pas.Add(pa);
                    pa = new ExcParameters()
                    {
                        _KEY = "@ChildFactor_PurePrice",
                        _VALUE = fpm.items[i].total
                    };
                    pas.Add(pa);
                    pa = new ExcParameters()
                    {
                        _KEY = "@ChildFactor_PurePricee",
                        _VALUE = fpm.items[i].total
                    };
                    pas.Add(pa);
                    pa = new ExcParameters()
                    {
                        _KEY = "@ChildFactor_QBuy",
                        _VALUE = fpm.items[i].number
                    };
                    pas.Add(pa);
                    res += db.Script("INSERT INTO [tbl_Factor_ChildFactor]([id_MainFactor],[ChildFactor_DeleteTypeID],[ChildFactor_DeletedByAdminID],[ChildFactor_ISDELETED],[ChildFactor_CreateDate],[ChildFactor_CreatedByUserTypeID],[ChildFactor_CreatorID],[ChildFactor_ProductModuleType],[ChildFactor_ProductID],[ChildFactor_PastProductHistoryID],[ChildFactor_HasOff],[ChildFactor_OffID],[ChildFactor_OffCode],[ChildFactor_OffPrice],[ChildFactor_PurePrice],[ChildFactor_PriceAfterOff],[ChildFactor_ProductReturnTypeID],[ChildFactor_ISCERTIFIED],[ChildFactor_ISEDITED],[ChildFactor_EditedByAdminID],[ChildFactor_EditedTo_id_ChildFactor],[ChildFactor_QBuy]) VALUES(@id_MainFactor,0,0,0,GETDATE(),2,@ChildFactor_CreatorID ,1,@ChildFactor_ProductID ,0,0,0,N' ',0,@ChildFactor_PurePrice ,@ChildFactor_PurePricee,0,1,0,0,@ChildFactor_QBuy )", pas);
                    flag += "1";
                }
                if(flag == res)
                {
                    ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX-fa3432",
                        Errormessage = $"",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);
                }
                else
                {
                    ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX15779455",
                        Errormessage = $"خرید انجام نشد!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }
            }
            else
            {
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX785673455",
                    Errormessage = $"خرید انجام نشد!!",
                    Errortype = "Error"
                };
                return Json(ModelSender);

            }


        }

        [HttpPost]
        public JsonResult AddproductToBasket()
        {
        //    "idp": $("#idp").val(),
        //"Number_inp": $("#Number_inp").val()
        }
    }
}