﻿using BamboPortal_V1._0._0._0.ModelFiller.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    [RoutePrefix("گالری-پارچه-ولوت")]
    public class CustomerSide_PagesController : CustomerSide_CustomerRuleController
    {
        // GET: CustomerSide_Pages
        public ActionResult index()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller(4);
            var ModelView = new IndexPageModelView()
            {
                NewProducts = modelFiller.ChosenProducts("New", 10, "Ago"),
                Sale_Products = modelFiller.ChosenProducts("Sale", 4, "Ago"),
                ProductsG3 = modelFiller.ChosenProducts("MainTag", 3, "Ago", 1),
                SelectedProducts = modelFiller.ProductList(20, "همه", 0, 1, "", "Date")
            };


            return View(ModelView);
        }

        [Route("درباره-ما")]
        public ActionResult AboutUs()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();

            var ModelView = new AboutUsModelView()
            {
                CustomerMessages = modelFiller.CompanyCustomers(),
                TeamMembers = modelFiller.TeamMembers()
            };
            return View(ModelView);
        }
        [Route("قوانین")]
        public ActionResult Rules()
        {
            return View();
        }


        public ActionResult Test()
        {
            return View();
        }

    }
}