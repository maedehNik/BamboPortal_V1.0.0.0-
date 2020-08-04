using BamboPortal_V1._0._0._0.ModelFiller.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class CustomerSide_PagesController : CustomerSide_CustomerRuleController
    {
        // GET: CustomerSide_Pages
        public ActionResult index()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller(4);
            ///آدرس شعبه ها رو مدلشو ساختم تو مدل ویو هم هست فقط پرش کن
            var ModelView = new IndexPageModelView()
            {
                NewProducts = modelFiller.ChosenProducts("New", 10, "Ago"),
                Sale_Products = modelFiller.ChosenProducts("Sale", 4, "Ago"),
                ProductsG3 = modelFiller.ChosenProducts("MainTag", 3, "Ago", 1),
                SelectedProducts = modelFiller.ProductList(20, "همه", 0, 1, "", "Date")
            };


            return View(ModelView);
        }

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

        public ActionResult Rules()
        {
            return View();
        }

    }
}