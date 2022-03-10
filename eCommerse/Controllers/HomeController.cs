using eCommerse.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using eCommerse.Models;

namespace eCommerse.Controllers
{
    public class HomeController : Controller
    {
        eCommerseASMEntities objeCommerseASMEntities = new eCommerseASMEntities();
        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListCategory = objeCommerseASMEntities.Categories.ToList();

            objHomeModel.ListProduct = objeCommerseASMEntities.Products.ToList();
            return View(objHomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}