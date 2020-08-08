using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models.AdministratorFactor;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorProducts_FactorsController : AdminRulesController
    {
        //need backend
        // GET: AdministratorProducts_Factors
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerBuy()
        {
            return View();
        }
        public ActionResult ProductSaleListFactor()
        {
            return View();
        }
        public ActionResult ProductFactorWaitingForMoney()
        {
            return View();
        }
        public ActionResult AllFactorTable()
        {
            return View();
        }

        public ActionResult ProductList_Factors()
        {
            var Model = new List<MainFactorModel>();
            PDBC db = new PDBC();

            DataTable dt = db.Select("SELECT [id_MainFactor],[MainFactor_CreateDate],[MainFactor_Code],[MainFactor_Price],[MainFactor_IsPay],[MainFactor_PaymentCode],[MainFactor_Tax],[MainFactor_TotalOff],[MainFactor_ISEDITED],[MainFactor_IsDeleted],[MainFactor_PayType],[PayType] FROM [v_Factor_Main]");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var m = new MainFactorModel()
                {
                    Num = i + 1,
                    MainFactorId = Convert.ToInt32(dt.Rows[i]["id_MainFactor"]),
                    IsDeleted = Convert.ToInt32(dt.Rows[i]["MainFactor_IsDeleted"]),
                    IsEdited = Convert.ToInt32(dt.Rows[i]["MainFactor_ISEDITED"]),
                    Is_Pay = Convert.ToInt32(dt.Rows[i]["MainFactor_IsPay"]),
                    MainFactor_Code = dt.Rows[i]["MainFactor_Code"].ToString(),
                    MainFactor_Price = dt.Rows[i]["MainFactor_Price"].ToString(),
                    PaymentCode = dt.Rows[i]["MainFactor_PaymentCode"].ToString(),
                    PayType = dt.Rows[i]["MainFactor_PayType"].ToString(),
                    Tax = dt.Rows[i]["MainFactor_Tax"].ToString(),
                    TotalOff = dt.Rows[i]["MainFactor_TotalOff"].ToString(),
                    CreateDate = BamboPortal_V1._0._0._0.StaticClass.DateConvert.DateReturner(dt.Rows[i]["MainFactor_CreateDate"].ToString(), "ShortDate")
                };


                DataTable itm = db.Select("SELECT [id_ChildFactor],[Title],[id_MProduct],[MoneyTypeName],[PQT_Demansion],[ChildFactor_PurePrice],[ChildFactor_QBuy],[PriceXquantity],[ChildFactor_OffCode],[ChildFactor_OffPrice],[ChildFactor_PriceAfterOff],[Quantity],[id_MPC],[PricePerquantity],[id_MainFactor] FROM [v_FactorItems] WHERE [id_MainFactor]=" + m.MainFactorId);
                for (int j = 0; j < itm.Rows.Count; j++)
                {
                    var item = new FactorItrmModel()
                    {
                        Num=j+1,
                        FactorChildId = Convert.ToInt32(dt.Rows[j]["id_ChildFactor"]),
                        ProductId = Convert.ToInt32(dt.Rows[j]["id_MProduct"]),
                        Title= dt.Rows[j]["Title"].ToString(),
                        MoneyType = dt.Rows[j]["MoneyTypeName"].ToString(),
                        OffCode = dt.Rows[j]["ChildFactor_OffCode"].ToString(),
                        OffPrice = dt.Rows[j]["ChildFactor_OffPrice"].ToString(),
                        PriceAfterOff = dt.Rows[j]["ChildFactor_PriceAfterOff"].ToString(),
                        PricePerquantity = dt.Rows[j]["PricePerquantity"].ToString(),
                        PurePrice = dt.Rows[j]["ChildFactor_PurePrice"].ToString(),
                        Quantity = dt.Rows[j]["Quantity"].ToString(),
                        QuantityType = dt.Rows[j]["PQT_Demansion"].ToString()

                    };

                    m.Items.Add(item);
                }
                Model.Add(m);
            }


            return View(Model);
        }
    }
}