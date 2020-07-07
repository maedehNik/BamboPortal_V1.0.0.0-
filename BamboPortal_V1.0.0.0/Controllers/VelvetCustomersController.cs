﻿using BamboPortal_V1._0._0._0.ModelFiller.CustomerSide;
using BamboPortal_V1._0._0._0.ModelViews.CustomerSide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BamboPortal_V1._0._0._0.Controllers
{
    public class VelvetCustomersController : Controller
    {
        // GET: VelvetCustomer
        public ActionResult index()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller(4);
            ///آدرس شعبه ها رو مدلشو ساختم تو مدل ویو هم هست فقط پرش کن
            var ModelView = new IndexPageModelView()
            {
                NewProducts=modelFiller.ChosenProducts("New", 10, "Ago"),
                Sale_Products = modelFiller.ChosenProducts("Sale", 4, "Ago"),
                ProductsG3 = modelFiller.ChosenProducts("MainTag", 3, "Ago", 1),
                SelectedProducts = modelFiller.ProductList(4, "همه", 0, 1, "", "Date")
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

        public ActionResult customershoppingCart()
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            ///این متغیرها پر بشه
            int CustomerId = 1009;
            int FactorId = 3005;
            var model = new ShoppingCartModelView()
            {
                FactorModel = modelFiller.shoppingCart(FactorId),
                Ostan = modelFiller.Ostanha(),
                Adresses = modelFiller.CustomerAddresses(CustomerId),
                Customer = modelFiller.customerDetail(CustomerId)
            };


            return View(model);
        }

        public ActionResult factor()
        {

            CustomerModelFiller modelFiller = new CustomerModelFiller();
            ///این متغیر پر بشه
            int CustomerId = 1009;

            return View(modelFiller.Customers_Factors("همه", CustomerId, "Date"));
        }

        public ActionResult loginandregister()
        {
            return View();
        }

        public ActionResult mobileverify()
        {
            return View();
        }

        public ActionResult productpage(int ProId)
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();
            ///این متغیرها پر بشه
            
            var model = new ProductDetail_ModelView()
            {
                ProductModel = modelFiller.SingleProduct(ProId, "Ago"),
                Sale_Products= modelFiller.ChosenProducts("Sale", 4, "Ago")
            };


            return View(model);
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult search(string Type, int Id = 0, int Page = 1, string Search = "")
        {
            CustomerModelFiller modelFiller = new CustomerModelFiller();

            ///این متغیر پر بشه
            int CustomerId = 1009;
            var model = new SearchPageModelView()
            {
                Cat=Type,
                CatId=Id,
                Cateqories = modelFiller.CategoriesAsTree_OneSub("MainCat", 1),
                thisPage=Page,
                Search=Search
            };

            if (Type == "پرفروش ها")
            {
                model.Products = modelFiller.ChosenProducts("Sale", 12, "Ago");
                model.Pages = 1;
            }
            else if (Type == "جدیدترین")
            {
                model.Products = modelFiller.ChosenProducts("New", 12, "Ago");
                model.Pages = 1;
            }
            else if (Type == "فروش ویژه")
            {
                model.Products = modelFiller.ChosenProducts("MainTag", 12, "Ago", 1);
                model.Pages = 1;
            }
            else if (Type == "علاقه مندی ها")
            {
                model.Products = modelFiller.FavoriteProducts(12, Type, Id, Page, Search, "Date", CustomerId);
                model.Pages = modelFiller.ProList_Pages(Type, 12, Id, Search, CustomerId);
            }
            else
            {
                model.Products = modelFiller.ProductList(12, Type, Id, Page, Search, "Date");
                model.Pages = modelFiller.ProList_Pages(Type, 12, Id, Search);
            }


            return View(model);
        }
    }
}