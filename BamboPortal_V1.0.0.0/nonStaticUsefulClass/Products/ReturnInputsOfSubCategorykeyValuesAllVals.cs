using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models.UsefulModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.nonStaticUsefulClass.Products
{
    public class ReturnInputsOfSubCategorykeyValuesAllVals
    {
        public List<Key_ValueModel> SubCat_Value(string SCOKID)
        {
            List<Key_ValueModel> result = new List<Key_ValueModel>();
            PDBC db = new PDBC();
            ExcParameters par = new ExcParameters()
            {
                _KEY = "@SCOKID",
                _VALUE = SCOKID
            };
            List<ExcParameters> pAs = new List<ExcParameters>();
            pAs.Add(par);
            db.Connect();
            using (DataTable dt = db.Select("SELECT [id_SCOV] as id,[SCOVValueName] as [name] FROM [tbl_Product_SubCategoryOptionValue] WHERE[id_SCOK] = @SCOKID", pAs))
            {
                db.DC();
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
            return result;
        }
    }
}