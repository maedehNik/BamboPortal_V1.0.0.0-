using BamboPortal_V1._0._0._0.BamboPortalSecurity.EncDec;
using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models;
using BamboPortal_V1._0._0._0.Models.AdministratorProductsModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            AddDataToDataBase add = new AddDataToDataBase();
            return Content(add.AddData());
        }

        [HttpGet]
        public ActionResult GetTest()
        {
            var result = new List<CategotyTreeModel>();
            PDBC db = new PDBC();
            db.Connect();
            DataTable Type = db.Select("SELECT [id_PT],[PTname] FROM [tbl_Product_Type] where ISDelete=0 AND ISDESABLED=0");
            for (int i = 0; i < Type.Rows.Count; i++)
            {
                var MainCat = new List<CategotyTreeModel>();
                DataTable Mains = db.Select("SELECT [id_MC],[MCName] FROM [tbl_Product_MainCategory] WHERE ISDelete=0 AND ISDESABLED=0 AND id_PT=" + Type.Rows[i]["id_PT"]);
                for (int j = 0; j < Mains.Rows.Count; j++)
                {
                    var SubCat = new List<CategotyTreeModel>();
                    DataTable Subs = db.Select("SELECT [id_SC],[SCName] FROM [tbl_Product_SubCategory] WHERE ISDelete=0 AND ISDESABLED=0 AND id_MC=" + Mains.Rows[j]["id_MC"]);
                    for (int k = 0; k < Subs.Rows.Count; k++)
                    {
                        var SubCatKey = new List<CategotyTreeModel>();
                        DataTable SubsK = db.Select("SELECT [id_SCOK],[SCOKName] FROM [tbl_Product_SubCategoryOptionKey] where ISDelete=0 AND ISDESABLED=0 AND id_SC=" + Subs.Rows[k]["id_SC"]);
                        for (int k1 = 0; k1 < SubsK.Rows.Count; k1++)
                        {
                            var SubCatKeyVal = new List<CategotyTreeModel>();
                            DataTable SubsKV = db.Select("SELECT [id_SCOV],[SCOVValueName] FROM [tbl_Product_SubCategoryOptionValue] where id_SCOK=" + SubsK.Rows[k1]["id_SCOK"]);
                            for (int k2 = 0; k2 < SubsKV.Rows.Count; k2++)
                            {
                                var M5 = new CategotyTreeModel()
                                {
                                    Id = Convert.ToInt32(SubsKV.Rows[k2]["id_SCOV"]),
                                    text = SubsKV.Rows[k2]["SCOVValueName"].ToString(),
                                    icon = "fa fa-file m--font-secondary"
                                };
                                SubCatKeyVal.Add(M5);
                            }
                            var M4 = new CategotyTreeModel()
                            {
                                Id = Convert.ToInt32(SubsK.Rows[k1]["id_SCOK"]),
                                text = SubsK.Rows[k1]["SCOKName"].ToString(),
                                icon = "fa fa-folder m--font-brand",
                                children = SubCatKeyVal
                            };
                            SubCatKey.Add(M4);
                        }
                        var M3 = new CategotyTreeModel()
                        {
                            Id = Convert.ToInt32(Subs.Rows[k]["id_SC"]),
                            text = Subs.Rows[k]["SCName"].ToString(),
                            icon = "fa fa-folder m--font-warning",
                            children = SubCatKey
                        };

                        SubCat.Add(M3);

                    }
                    var M2 = new CategotyTreeModel()
                    {
                        Id = Convert.ToInt32(Mains.Rows[j]["id_MC"]),
                        text = Mains.Rows[j]["MCName"].ToString(),
                        icon = "fa fa-folder m--font-danger",
                        children = SubCat
                    };
                    MainCat.Add(M2);

                }
                var M1 = new CategotyTreeModel()
                {
                    Id = Convert.ToInt32(Type.Rows[i]["id_PT"]),
                    text = Type.Rows[i]["PTname"].ToString(),
                    icon = "fa fa-folder m--font-success",
                    children = MainCat
                };
                result.Add(M1);
            }
            db.DC();

            return Content(JsonConvert.SerializeObject(result));
        }
    }
}