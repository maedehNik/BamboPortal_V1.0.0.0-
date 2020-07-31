using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.nonStaticUsefulClass.Products
{
    public class SaveJaygashtOfProducts
    {
        public string MainProduct_Actions(string action, int id_MProduct, string Quantity, string QuantityModule, string PriceXquantity, string PricePerquantity, string PriceOff, string offTypeValue, string OffType, string id_MainStarTag, string PriceModule, string PriceShow, string describtion = " ")
        {

            List<ExcParameters> paramss = new List<ExcParameters>();
            PDBC db = new PDBC();
            var parameters = new ExcParameters()
            {
                _KEY = "@id_MProduct",
                _VALUE = id_MProduct
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@Quantity",
                _VALUE = Quantity
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@QuantityModule",
                _VALUE = QuantityModule
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PriceXquantity",
                _VALUE = PriceXquantity
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PricePerquantity",
                _VALUE = PricePerquantity
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PriceOff",
                _VALUE = PriceOff
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@offTypeValue",
                _VALUE = offTypeValue
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@OffType",
                _VALUE = OffType
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@id_MainStarTag",
                _VALUE = id_MainStarTag
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PriceModule",
                _VALUE = PriceModule
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@PriceShow",
                _VALUE = PriceShow
            };
            paramss.Add(parameters);

            parameters = new ExcParameters()
            {
                _KEY = "@describtion",
                _VALUE = describtion
            };
            paramss.Add(parameters);

            string query = "";

            if (action == "insert")
            {
                query = "INSERT INTO [tlb_Product_MainProductConnector] Output Inserted.id_MPC VALUES(@id_MProduct, @Quantity, @PriceXquantity, @PricePerquantity, @PriceOff, @offTypeValue, @OffType, @id_MainStarTag , 0 , 0 ,  @QuantityModule ,GetDate(), @PriceModule, @PriceShow,@describtion,0)";
            }
            else if (action == "update")
            {
                query = "UPDATE [tlb_Product_MainProductConnector]SET [Quantity] =  @Quantity ,[PriceXquantity] = @PriceXquantity,[PricePerquantity] =@PricePerquantity ,[PriceOff] =@PriceOff ,[offTypeValue] = @offTypeValue ,[OffType] = @PriceOff,[id_MainStarTag] = @id_MainStarTag ,[id_PQT] = @QuantityModule,[PriceModule] = @PriceModule ,[PriceShow] = @PriceShow  WHERE id_MPC=@id_MProduct";

            }
            else if (action == "delete")
            {

            }

            if (query != "")
            {
                db.Connect();
                string res = db.Script(query, paramss);
                //==========================Add to stockpile=================

                db.Connect();
                using (DataTable dt = db.Select("SELECT [shop_id]  FROM [tbl_Modules_StockpileShopsMainTable]"))
                {
                    string idForShops = db.Script("INSERT INTO [tbl_Modules_StockpileMainTable] ([id_Stockpile_AllowType] ,[code_Stockpile] ,[id_MPC]) output inserted.id_Stockpile VALUES (1 ,N' ' ," + res + " )");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string tes = db.Script("INSERT INTO [tbl_Modules_StockpileConnectorMainToShops] ([id_Stockpile] ,[shop_id] ,[ItemRemaining]) VALUES (" + idForShops + " ," + dt.Rows[i]["shop_id"].ToString() + " ,0)");
                    }
                    db.DC();
                }
                //===========================================
                if (action == "insert")
                {
                    string ss = db.Script("INSERT INTO [tbl_Product_PastProductHistory] VALUES (" + res + ",@PriceXquantity,@PricePerquantity,@PriceOff,@OffType,@id_MainStarTag,GETDATE(),@offTypeValue)", paramss);
                }
                else if (action == "update")
                {
                    db.Script("INSERT INTO [tbl_Product_PastProductHistory]VALUES(@id_MProduct,@PriceXquantity,@PricePerquantity,@PriceOff,@OffType,@id_MainStarTag,GETDATE(),@offTypeValue)", paramss);
                }
                db.DC();
                return res;
            }
            else
                return "0";

        }
    }
}