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



            return new List<ShopStructures>();
        }

        public Int64 CanBuyThisProductFromThisShop(string id_MPC, string id_Shop, Int64 HowMuchTobuy = 0)
        {
            PDBC db = new PDBC();
            db.Connect();
            Int64 TotStock = 0;
            Int64 TotFactor = 0;
            using (DataTable dt = db.Select($"SELECT [shop_id] ,[id_MPC] ,[Total] FROM [V_StockpileVaredemenhaSadere] WHERE id_MPC={id_MPC} AND shop_id = {id_Shop}"))
            {
                if (dt.Rows.Count > 0)
                {
                    TotStock = Convert.ToInt64(dt.Rows[0]["Total"].ToString());
                    using (DataTable dt2 = db.Select($"SELECT [id_Shop] ,[id_MPC] ,[QREMAIN] FROM [V_AcceptedFactors] WHERE id_MPC = {id_MPC} AND id_Shop = {id_Shop}"))
                    {
                        db.DC();
                        if (dt2.Rows.Count > 0)
                        {
                            TotFactor = Convert.ToInt64(dt2.Rows[0]["QREMAIN"].ToString());
                        }
                        else
                        {
                            TotFactor = 0; 
                        }
                    }
                }
                else
                {
                    db.DC();
                }
            }

            TotStock = TotStock - TotFactor;

            return TotStock;
        }
    }
}