using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class AdministratorProducts_FieldLoaderController : AdminRules_ProductCTRLController
    {
        // GET: AdministratorProducts_FieldLoader
        [HttpPost]
        public JsonResult GetSubCateGoryForSelect2FromPTypeID(string PTypeID)
        {
            int idPT = 0;
            List<Id_ValueModel> model = new List<Id_ValueModel>();
            if (Int32.TryParse(PTypeID, out idPT))
            {
                PDBC db = new PDBC();
                ExcParameters par = new ExcParameters()
                {
                    _KEY = "@id_PT",
                    _VALUE = PTypeID
                };
                List<ExcParameters> parass = new List<ExcParameters>();
                parass.Add(par);
                db.Connect();
                using (DataTable dt = db.Select("SELECT [id_MC] as id,[MCName] as [name] FROM[tbl_Product_MainCategory] WHERE ISDelete=0 AND ISDESABLED=0 AND id_PT=@id_PT", parass))
                {
                    db.DC();
                    int dtrowcount = dt.Rows.Count;
                    if(dtrowcount > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var res = new Id_ValueModel()
                            {
                                Id = Convert.ToInt32(dt.Rows[i]["id"]),
                                Value = dt.Rows[i]["name"].ToString()
                            };
                            model.Add(res);
                        }
                    }
                    else
                    {
                        model.Add(new Id_ValueModel()
                        {
                            Id = 0,
                            Value = "هیچ موردی برای نمایش وجود ندارد!"
                        });
                    }
                } 
            }
            else
            {
                model.Add(new Id_ValueModel()
                {
                    Id = 0,
                    Value = "هیچ موردی برای نمایش وجود ندارد!"
                });
            }
            
            return Json(model);
        }
        public ActionResult TestPage()
        {
            return View();
        }
    }
}