using BamboPortal_V1._0._0._0.DatabaseCenter.Class;
using BamboPortal_V1._0._0._0.ModelFiller.CustomerSide;
using BamboPortal_V1._0._0._0.Models.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide;
using BamboPortal_V1._0._0._0.StaticClass;
using System;
using System.Collections.Generic;
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
            ///این متغیر پر بشه
            int CustomerId = 1009;
            return View(modelFiller.customerDetail(CustomerId));
        }

        public ActionResult customerProfileAddress()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            ///این متغیر پر بشه
            int CustomerId = 1009;
            var model = new customerAddressModelView()
            {
                City = modelFiller.Ostanha(),
                Addresses = modelFiller.CustomerAddresses(CustomerId)

            };


            return View(model);
        }

        public ActionResult customerProfileHistory()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            ///این متغیر پر بشه
            int CustomerId = 1009;

            return View(modelFiller.Customers_Factors("تکمیل شده", CustomerId, "Date"));
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

        public ActionResult AddCustomerAddress(string CityId, string FullAddress, string CodePosti)
        {
            tbl_Customer_Main tcm = new tbl_Customer_Main();
            var coockie = HttpContext.Request.Cookies.Get(ProjectProperies.AuthCustomerCode());
            if(coockie!=null)
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

            }else
            {
                return Content("Error");
            }

        }

    }
}