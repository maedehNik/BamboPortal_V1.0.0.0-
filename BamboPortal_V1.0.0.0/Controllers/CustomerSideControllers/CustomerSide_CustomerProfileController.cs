using BamboPortal_V1._0._0._0.BamboPortalSecurity.EncDec;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.ModelFiller.CustomerSide;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide.CustomerHistory;
using BamboPortal_V1._0._0._0.StaticClass;
using BamboPortal_V1._0._0._0.StaticClass.UploaderStaticsCalculators;
using MD.PersianDateTime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class CustomerSide_CustomerProfileController : CustomerSide_CustomerProfileRuleController
    {

        public ActionResult customerProfile()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            if (coockie != null)
            {
                tcm = CoockieController.SayWhoIsHE(coockie.Value);
                var Id = tcm.id_Customer;
                return View(modelFiller.customerDetail(Convert.ToInt32(Id)));
            }
            else
            {
                return Content("Error");
            }
        }

        public ActionResult customerProfileAddress()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            if (coockie != null)
            {
                tcm = CoockieController.SayWhoIsHE(coockie.Value);
                var Id = tcm.id_Customer;
                var model = new customerAddressModelView()
                {
                    City = modelFiller.Ostanha(),
                    Addresses = modelFiller.CustomerAddresses(Convert.ToInt32(Id))

                };


                return View(model);

            }
            else
            {
                return Content("Error");
            }
        }

        public ActionResult customerProfileHistory()
        {
            historyProductItemsModelView model = new historyProductItemsModelView()
            {
                History = new List<historyProductCardItemsModel>()
            };
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
            PDBC db = new PDBC();
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_MainFactor],[MainFactor_CreateDate],[MainFactor_Code],[MainFactor_Price],[MainFactor_IsPay],[MainFactor_Tax],[MainFactor_TotalOff],[PayType] FROM [v_Factor_Main] WHERE [id_Customer] = " + tcm.id_Customer))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    using (DataTable dt2 = db.Select("SELECT [id_MPC],[id_MainFactor],[id_ChildFactor],[Title],[MoneyTypeName],[PQT_Demansion],[ChildFactor_PurePrice],[ChildFactor_QBuy],[MultyPriceStartFromQ],[MultyPrice],[PriceXquantity]  FROM [v_ChildFactorToProduct] WHERE [id_MainFactor] = " + dt.Rows[i]["id_MainFactor"].ToString()))
                    {
                        db.DC();
                        historyProductCardItemsModel df = new historyProductCardItemsModel()
                        {
                            WhenCreated = new PersianDateTime(DateTime.Parse(dt.Rows[i]["MainFactor_CreateDate"].ToString())).ToLongDateTimeString(),
                            Ispay = (dt.Rows[i]["MainFactor_IsPay"].ToString()),
                            OffPrice = 0,
                            PeygiriCode = dt.Rows[i]["MainFactor_Code"].ToString(),
                            TaxPrice = 0,
                            PayMentTypeName = dt.Rows[i]["PayType"].ToString(),
                            PayPrice = Convert.ToInt64(dt.Rows[i]["MainFactor_Price"].ToString()),
                            TotalPrice = Convert.ToInt64(dt.Rows[i]["MainFactor_Price"].ToString())
                        };
                        df.AllItems = new List<historyProductTableItemsModel>();
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            historyProductTableItemsModel ai = new historyProductTableItemsModel()
                            {
                                Countof = dt2.Rows[j]["ChildFactor_QBuy"].ToString(),
                                id_MPC = dt2.Rows[j]["id_MPC"].ToString(),
                                ProductDimensionName = dt2.Rows[j]["PQT_Demansion"].ToString(),
                                ProductName = dt2.Rows[j]["Title"].ToString(),
                                scoknameandvalue = "",
                                ImagePath = UploaderGeneral.imageFinderfromIDMPC(dt2.Rows[j]["id_MPC"].ToString(), ImageSizeEnums.Thumbnail),
                            };
                            if (Convert.ToInt64(dt2.Rows[j]["ChildFactor_QBuy"].ToString()) > Convert.ToInt64(dt2.Rows[j]["MultyPriceStartFromQ"].ToString()))
                            {
                                ai.pricebperQ = dt2.Rows[j]["MultyPrice"].ToString();
                                ai.TotalPrice = (Convert.ToInt64(ai.pricebperQ) * Convert.ToInt64(dt2.Rows[j]["ChildFactor_QBuy"].ToString())).ToString();
                            }
                            else
                            {
                                ai.pricebperQ = dt2.Rows[j]["PriceXquantity"].ToString();
                                ai.TotalPrice = (Convert.ToInt64(ai.pricebperQ) * Convert.ToInt64(dt2.Rows[j]["ChildFactor_QBuy"].ToString())).ToString();

                            }

                            df.AllItems.Add(ai);
                        }


                        model.History.Add(df);
                        db.Connect();
                    }
                    

                }
                db.DC();
                
         



            }


            return View(model);
        }

        public ActionResult customerProfileReturn()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            ///این متغیر پر بشه
            int CustomerId = 1009;

            return View(modelFiller.Customers_Factors("تکمیل نشده", CustomerId, "Date"));
        }

        public ActionResult customerProfileSettings()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomerAddress(string CityId, string FullAddress, string CodePosti)
        {
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            if (coockie != null)
            {
                tcm = CoockieController.SayWhoIsHE(coockie.Value);
                var Id = tcm.id_Customer;

                PDBC db = new PDBC();
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@Id",
                    _VALUE = Id
                };
                parss.Add(par);

                par = new ExcParameters()
                {
                    _KEY = "@CityId",
                    _VALUE = CityId
                };
                parss.Add(par);

                par = new ExcParameters()
                {
                    _KEY = "@FullAddress",
                    _VALUE = FullAddress
                };
                parss.Add(par);

                par = new ExcParameters()
                {
                    _KEY = "@CodePosti",
                    _VALUE = CodePosti
                };
                parss.Add(par);

                db.Connect();
                string result = db.Script("INSERT INTO [tbl_Customer_Address]([id_Customer],[ID_Shahr],[C_AddressHint],[C_FullAddress])VALUES(@Id,@CityId,@CodePosti,@FullAddress)", parss);


                db.DC();

                if (result == "1")
                {
                    return Content("Success");
                }
                else
                {
                    return Content("Error");
                }

            }
            else
            {
                return Content("Error");
            }

            }else
            {
                return Content("Error");
            }

            }
            else
            {
                return Content("Error");
            }
        }

        [HttpPost]
        public ActionResult UpdateCustomerPass(string PrePass, string Pass)
        {
            EncDec enc = new EncDec();
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            if (coockie != null)
            {
                tcm = CoockieController.SayWhoIsHE(coockie.Value);
                var Id = tcm.id_Customer;


                PDBC db = new PDBC();
                List<ExcParameters> parss = new List<ExcParameters>();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@Id",
                    _VALUE = Id
                };
                parss.Add(par);

                par = new ExcParameters()
                {
                    _KEY = "@PrePass",
                    _VALUE =enc.HMACMD5Generator(PrePass)
                };
                parss.Add(par);

                par = new ExcParameters()
                {
                    _KEY = "@Pass",
                    _VALUE = enc.HMACMD5Generator(Pass)
                };
                parss.Add(par);


                db.Connect();

                int Count = Convert.ToInt32(db.Select("SELECT COUNT(*) FROM [tbl_Customer_Main] WHERE id_Customer=@Id AND C_Password LIKE @PrePass", parss).Rows[0][0]);

                if (Count > 0)
                {
                    string result = db.Script("UPDATE [tbl_Customer_Main] SET [C_Password]=@Pass WHERE [id_Customer]=@Id", parss);
                   db.DC();
                    if (result == "1")
                    {
                        return Content("Success");
                    }
                    else
                    {
                        return Content("ErrorSQL");
                    }
                    
                }
                else
                {
                    db.DC();
                    return Content("pre_Pass");
                   
                }

            }
            else
            {
                return Content("Error");
            }
        }

    }
}