using BamboPortal_V1._0._0._0.ModelFiller.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide;
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

    }
}