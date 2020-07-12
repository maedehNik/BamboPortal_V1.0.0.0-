using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.nonStaticUsefulClass.Products
{
    public class JaygashtCalculator
    {
        List<string> Jaygasht(int a, List<List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator>> Position)
        {
            List<string> retval = new List<string>();
            if (a == Position.Count)
            {
                retval.Add("");
                return retval;
            }
            foreach (AllSubcategory_Keys_Vals_ModelJaygashtCalculator y in Position[a])
            {
                foreach (string x2 in Jaygasht(a + 1, Position))
                {
                    //.Replace("{", "[").Replace("}", "]")
                    retval.Add(JsonConvert.SerializeObject(y) + "," + x2.ToString());
                }
            }
            return retval;
        }
        public List<List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator>> ListMaker(List<AllSubcategory_Keys_Vals_class> SenderKeyValObj)
        {
            PDBC db = new PDBC();
            var result = new List<List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator>>();
            db.Connect();
            foreach (var item in SenderKeyValObj)
            {
                var m = new List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator>();

                foreach (var Ids_itm in item.SubCategoryKeyAllValues)
                {
                    var m2 = new AllSubcategory_Keys_Vals_ModelJaygashtCalculator()
                    {
                        ItemSubCategoryKeyID = item.ItemSubCategoryKeyID,
                        SubCategoryKeyValue = Ids_itm,
                        ItemSubCategoryValuOfKeyName = db.Select("SELECT [SCOVValueName] FROM [tbl_Product_SubCategoryOptionValue]where id_SCOV=" + Ids_itm).Rows[0][0].ToString()
                    };

                    m.Add(m2);
                }
                result.Add(m);
            }
            db.DC();
            return result;
        }
        public List<List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator>> Result(List<AllSubcategory_Keys_Vals_class> json)
        {
            List<List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator>> AA = new List<List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator>>();
            foreach (string x in Jaygasht(0, ListMaker(json)))
            {


                List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator> bb = JsonConvert.DeserializeObject<List<AllSubcategory_Keys_Vals_ModelJaygashtCalculator>>("[" + x.TrimEnd(',') + "]");
                AA.Add(bb);
            }
            return AA;
        }

    }
}