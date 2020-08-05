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
using BamboPortal_V1._0._0._0.StaticClass.UploaderStaticsCalculators;
using BamboPortal_V1._0._0._0.nonStaticUsefulClass.Stockpile;

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
            if (HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode()) != null)
            {
                model.islogin = true;
            }
            else
            {
                model.islogin = false;
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

            var ModelSender = new ErrorReporterModel();
            PDBC db = new PDBC();
            List<ExcParameters> pas = new List<ExcParameters>();
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            tcm = CoockieController.SayWhoIsHE(coockie.Value);
            FactorPopUpModel fpm = CoockieController.GetCustomerShopFactorCookie(HttpContext.Request.Cookies.Get(ProjectProperies.CustomerShoppingFactor()).Value);
            string DeleteAns = "خرید با موفقیت انجام شد!";
            var c = new HttpCookie(ProjectProperies.CustomerShoppingFactor());
            c.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(c);
            var d = new HttpCookie(ProjectProperies.AuthCustomerShoppingBasket());
            d.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(d);
            AmountOfProductsLeft itemRemains = new AmountOfProductsLeft();
            for (int i = 0; i < fpm.items.Count; i++)
            {
                if (itemRemains.CanBuyThisProductFromThisShop(fpm.items[i].Id.ToString(), "1", fpm.items[i].number) <= 0)
                {
                    DeleteAns = "متاسفانه موجودی برخی کالا ها برای خرید شما کافی نمیباشد ";
                    fpm.items.RemoveAt(i);
                }
            }
            if(fpm.items.Count == 0)
            {
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "SX-fa3432",
                    Errormessage = DeleteAns,
                    Errortype = "Success"
                };
                return Json(ModelSender);
            }
            Int64 totals = 0;
            for (int i = 0; i < fpm.items.Count; i++)
            {
                totals += fpm.items[i].total;
            }
            fpm.totality = totals.ToString();
            ExcParameters pa = new ExcParameters()
            {
                _KEY = "@id_Customer",
                _VALUE = tcm.id_Customer
            };
            pas.Add(pa);
            pa = new ExcParameters()
            {
                _KEY = "@MainFactor_Code",
                _VALUE = "FM-" + DateTime.Now.Ticks
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
            if (Int32.TryParse(ReturnedID, out idmf))
            {
                string flag = "";
                pas = new List<ExcParameters>();
                string res = "";
                db.Connect();
                for (int i = 0; i < fpm.items.Count; i++)
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

                    string idd = db.Script("INSERT INTO [tbl_Factor_ChildFactor]([id_MainFactor],[ChildFactor_DeleteTypeID],[ChildFactor_DeletedByAdminID],[ChildFactor_ISDELETED],[ChildFactor_CreateDate],[ChildFactor_CreatedByUserTypeID],[ChildFactor_CreatorID],[ChildFactor_ProductModuleType],[ChildFactor_ProductID],[ChildFactor_PastProductHistoryID],[ChildFactor_HasOff],[ChildFactor_OffID],[ChildFactor_OffCode],[ChildFactor_OffPrice],[ChildFactor_PurePrice],[ChildFactor_PriceAfterOff],[ChildFactor_ProductReturnTypeID],[ChildFactor_ISCERTIFIED],[ChildFactor_ISEDITED],[ChildFactor_EditedByAdminID],[ChildFactor_EditedTo_id_ChildFactor],[ChildFactor_QBuy]) OUTPUT inserted.[id_ChildFactor] VALUES(@id_MainFactor,0,0,0,GETDATE(),2,@ChildFactor_CreatorID ,1,@ChildFactor_ProductID ,0,0,0,N' ',0,@ChildFactor_PurePrice ,@ChildFactor_PurePricee,0,1,0,0,0,@ChildFactor_QBuy )", pas);

                    res += db.Script("INSERT INTO  [tbl_Factor_FactorInStock]([id_ChildFactor],[FactorInStock_FirstShopID],[FactorInStock_SecondShopID],[FactorInStock_CreatedDate],[FactorInStock_TransActionByAdminID],[FactorInStock_HasTransAction]) VALUES(" + idd + " ,1 ,0,GETDATE(),0,0)");
                    flag += "1";


                }
                db.DC();
                if (flag == res)
                {
                    ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX-fa3432",
                        Errormessage = DeleteAns,
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
        public JsonResult AddproductToBasket(string idp, string Number_inp)
        {
            var ModelSender = new ErrorReporterModel();
            if (string.IsNullOrEmpty(Number_inp) || Convert.ToInt32(Number_inp) < 1)
            {
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX186763",
                    Errormessage = $"تعداد محصول خریداری شده معتبر نمیباشد!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
            PDBC db = new PDBC();

            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            if (coockie != null)
            {
                tcm = CoockieController.SayWhoIsHE(coockie.Value);
            }
            else
            {
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX186763",
                    Errormessage = $"ابتدا وارد اکانت کاربری خود شوید!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }
            var coockie2 = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket());
            if (coockie2 != null)
            {
                var coockie3 = JsonConvert.DeserializeObject<ShoppingBasket>(HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket()).Value);
                var KK = coockie3.Items.Find(x => x.idmpc == idp);
                if (KK != null)
                {
                    coockie3.Items.Remove(KK);
                }
                List<ExcParameters> pars = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_MPC",
                    _VALUE = idp
                };
                pars.Add(par);
                db.Connect();
                using (DataTable dt = db.Select("SELECT [Quantity],[Title] ,[PriceXquantity] ,[PricePerquantity] ,[MultyPriceStartFromQ] ,[MultyPrice] FROM [v_Connector_MainProductConnectorToProduct] WHERE [id_MPC] = @id_MPC AND [tlb_Product_MainProductConnector_ISDELETE] = 0 ", pars))
                {
                    db.DC();
                    if (dt.Rows.Count > 0)
                    {
                        ShoppingBasketItems ssd = new ShoppingBasketItems()
                        {
                            idmpc = idp,
                            CountOf = Convert.ToInt32(Number_inp),
                            ImagePath = UploaderGeneral.imageFinderfromIDMPC(idp, ImageSizeEnums.Thumbnail),
                            Title = dt.Rows[0]["Title"].ToString()
                        };
                        int assd = Convert.ToInt32(dt.Rows[0]["MultyPriceStartFromQ"].ToString());
                        if (Convert.ToInt32(dt.Rows[0]["MultyPriceStartFromQ"].ToString()) < Convert.ToInt32(Number_inp))
                        {
                            ssd.PriceXQ = Convert.ToInt64(dt.Rows[0]["MultyPrice"].ToString());
                        }
                        else
                        {
                            ssd.PriceXQ = Convert.ToInt64(dt.Rows[0]["PriceXquantity"].ToString());
                        }
                        ssd.Totals = ssd.PriceXQ * ssd.CountOf;
                        coockie3.Items.Add(ssd);
                    }
                    else
                    {
                        ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX567763",
                            Errormessage = $"محصول یافت نشد!",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }
                }






                var userCookieIDV = new HttpCookie(ProjectProperies.AuthCustomerShoppingBasket());
                userCookieIDV.Value = JsonConvert.SerializeObject(coockie3);
                userCookieIDV.Expires = DateTime.Now.AddDays(2);
                Response.SetCookie(userCookieIDV);
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "SX106",
                    Errormessage = $"با موفقیت افزوده شد!",
                    Errortype = "Success"
                };
                return Json(ModelSender);
            }
            else
            {
                ShoppingBasket SB = new ShoppingBasket()
                {
                    Items = new List<ShoppingBasketItems>()
                };
                List<ExcParameters> pars = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_MPC",
                    _VALUE = idp
                };
                pars.Add(par);
                db.Connect();
                using (DataTable dt = db.Select("SELECT [Quantity] ,[Title],[PriceXquantity] ,[PricePerquantity]   ,[MultyPriceStartFromQ] ,[MultyPrice] FROM [v_Connector_MainProductConnectorToProduct] WHERE [id_MPC] = @id_MPC AND [tlb_Product_MainProductConnector_ISDELETE] = 0 ", pars))
                {
                    db.DC();
                    if (dt.Rows.Count > 0)
                    {
                        ShoppingBasketItems ssd = new ShoppingBasketItems()
                        {
                            idmpc = idp,
                            CountOf = Convert.ToInt32(Number_inp),
                            ImagePath = UploaderGeneral.imageFinderfromIDMPC(idp, ImageSizeEnums.Thumbnail),
                            Title = dt.Rows[0]["Title"].ToString()

                        };
                        if (Convert.ToInt32(dt.Rows[0]["MultyPriceStartFromQ"].ToString()) < Convert.ToInt32(Number_inp))
                        {
                            ssd.PriceXQ = Convert.ToInt64(dt.Rows[0]["MultyPrice"].ToString());
                        }
                        else
                        {
                            ssd.PriceXQ = Convert.ToInt64(dt.Rows[0]["PriceXquantity"].ToString());
                        }
                        ssd.Totals = ssd.PriceXQ * ssd.CountOf;
                        SB.Items.Add(ssd);
                    }
                    else
                    {
                        ModelSender = new ErrorReporterModel
                        {
                            ErrorID = "EX567763",
                            Errormessage = $"محصول یافت نشد!",
                            Errortype = "Error"
                        };
                        return Json(ModelSender);
                    }
                }
                var userCookieIDV = new HttpCookie(ProjectProperies.AuthCustomerShoppingBasket());
                userCookieIDV.Value = JsonConvert.SerializeObject(SB);
                userCookieIDV.Expires = DateTime.Now.AddDays(2);
                Response.SetCookie(userCookieIDV);
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "SX106",
                    Errormessage = $"با موفقیت افزوده شد!",
                    Errortype = "Success"
                };
                return Json(ModelSender);
            }
        }

        [HttpPost]
        public JsonResult DeleteFromBasket(string idp)
        {
            var ModelSender = new ErrorReporterModel();
            var coockie2 = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket());
            if (coockie2 != null)
            {
                var coockie3 = JsonConvert.DeserializeObject<ShoppingBasket>(HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerShoppingBasket()).Value);
                var KK = coockie3.Items.Find(x => x.idmpc == idp);
                if (KK != null)
                {
                    coockie3.Items.Remove(KK);
                    var userCookieIDV = new HttpCookie(ProjectProperies.AuthCustomerShoppingBasket());
                    userCookieIDV.Value = JsonConvert.SerializeObject(coockie3);
                    userCookieIDV.Expires = DateTime.Now.AddDays(2);
                    Response.SetCookie(userCookieIDV);
                    ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "SX106",
                        Errormessage = $"با موفقیت حذف شد!",
                        Errortype = "Success"
                    };
                    return Json(ModelSender);

                }
                else
                {
                    ModelSender = new ErrorReporterModel
                    {
                        ErrorID = "EX567313",
                        Errormessage = $"این کالا در سبد خرید موجود نمیباشد!",
                        Errortype = "Error"
                    };
                    return Json(ModelSender);
                }

            }
            else
            {
                ModelSender = new ErrorReporterModel
                {
                    ErrorID = "EX567313",
                    Errormessage = $"سبد خرید خالیست!",
                    Errortype = "Error"
                };
                return Json(ModelSender);
            }

        }
    }
}