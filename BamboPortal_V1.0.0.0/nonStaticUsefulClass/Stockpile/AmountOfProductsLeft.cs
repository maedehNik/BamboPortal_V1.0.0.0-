using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.nonStaticUsefulClass.Stockpile
{
    public class AmountOfProductsLeft
    {
        PDBC db;
        public AmountOfProductsLeft()
        {
            db = new PDBC();
        }
        public List<ShopStructures> ItemRemainingInShops(string id_MPC)
        {
            List<ShopStructures> result = new List<ShopStructures>();
            Int64 entered = 0;
            Int64 Out = 0;
            ProductForStockpile product = new ProductForStockpile()
            {
                id_MPC = id_MPC
            };
            db.Connect();
            using (DataTable dt = db.Select("SELECT [FactorInStock_FirstShopID] ,Sum([v_Factor_Child_CertifiedSells].[ChildFactor_QBuy]) OVER (PARTITION BY [v_Factor_Child_CertifiedSells].[FactorInStock_FirstShopID]) as [AllSells]  FROM [v_Factor_Child_CertifiedSells] WHERE [ChildFactor_ProductID] = " + id_MPC))
            {
                db.DC();
                ShopStructures ds = new ShopStructures();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ds.ProductInShop = product;
                    ds.ShopID = dt.Rows[i]["FactorInStock_FirstShopID"].ToString();
                    try
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["AllSells"].ToString()))
                        {

                            ds.ProductRemaining = Convert.ToInt64(dt.Rows[i]["AllSells"].ToString());
                        }
                        else
                        {
                            ds.ProductRemaining = 0;
                        }
                    }
                    catch
                    {
                        ds.ProductRemaining = 0;
                    }
                    result.Add(ds);
                }
            }
            db.Connect();
            for (int i = 0; i < result.Count; i++)
            {
                using (DataTable sadere = db.Select("SELECT  SUM([PQTValueOf_Transaction]) AS [SaderePQTValueOf_Transaction] FROM [v_Stockpile_Transactions] WHERE [id_MPC] = " + id_MPC + " AND [id_TransactionType] =2"))
                {
                    using (DataTable varede = db.Select("SELECT  SUM([PQTValueOf_Transaction]) AS [VaredePQTValueOf_Transaction] FROM [v_Stockpile_Transactions] WHERE [id_MPC] = " + id_MPC + " AND [id_TransactionType] =1"))
                    {
                        Int64 varedeCount = Convert.ToInt64(varede.Rows[0]["VaredePQTValueOf_Transaction"].ToString());
                        Int64 sadereCount = Convert.ToInt64(sadere.Rows[0]["SaderePQTValueOf_Transaction"].ToString());
                        sadereCount += result[i].ProductRemaining;
                        result[i].ProductRemaining = varedeCount - sadereCount;
                    }
                }
            }
            db.DC();
            return result;
        }

        public Int64 CanBuyThisProductFromThisShop(string id_MPC, string id_Shop, Int64 HowMuchTobuy = 0)
        {
            Int64 OUTS = 0;
            db.Connect();
            using (DataTable dt = db.Select("SELECT Sum([v_Factor_Child_CertifiedSells].[ChildFactor_QBuy]) OVER (PARTITION BY [v_Factor_Child_CertifiedSells].[FactorInStock_FirstShopID]) as [AllSells]  FROM [v_Factor_Child_CertifiedSells] WHERE [ChildFactor_ProductID] = " + id_MPC + " AND FactorInStock_FirstShopID = " + id_Shop))
            {
                db.DC();

                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["AllSells"].ToString()))
                        {
                            OUTS = Convert.ToInt64(dt.Rows[0]["AllSells"].ToString());
                        }
                        else
                        {
                            OUTS = 0;
                        }
                    }
                    catch
                    {
                        OUTS = 0;
                    }
                }
            }
            db.Connect();
            using (DataTable varede = db.Select("SELECT  SUM([PQTValueOf_Transaction]) OVER (PARTITION BY [id_MPC]) as [AllPQT_PQTValue]  FROM  [v_Stockpile_Transactions] WHERE [shop_id] = " + id_Shop + " AND [id_TransactionType] = 1 AND [id_MPC] = " + id_MPC))
            {
                using (DataTable sadere = db.Select("SELECT  SUM([PQTValueOf_Transaction]) OVER (PARTITION BY [id_MPC]) as [AllPQT_PQTValue]  FROM  [v_Stockpile_Transactions] WHERE [shop_id] = " + id_Shop + " AND [id_TransactionType] = 2 AND [id_MPC] = " + id_MPC))
                {
                    Int64 cvarede = 0;
                    Int64 csadere = 0;
                    try
                    {
                        if (!string.IsNullOrEmpty(varede.Rows[0]["AllPQT_PQTValue"].ToString()))
                        {
                            cvarede = Convert.ToInt64(varede.Rows[0]["AllPQT_PQTValue"].ToString());
                        }
                        else
                        {
                            cvarede = 0;
                        }
                    }
                    catch
                    {
                        cvarede = 0;
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(sadere.Rows[0]["AllPQT_PQTValue"].ToString()))
                        {
                            csadere = Convert.ToInt64(sadere.Rows[0]["AllPQT_PQTValue"].ToString());
                        }
                        else
                        {
                            csadere = 0;
                        }
                    }
                    catch
                    {
                        csadere = 0;
                    }
                    csadere += OUTS;
                    OUTS = cvarede - csadere;
                    if (OUTS > HowMuchTobuy)
                    {
                        return OUTS;
                    }
                    else
                    {
                        return -1;
                    }


                }
            }

        }
    }
}