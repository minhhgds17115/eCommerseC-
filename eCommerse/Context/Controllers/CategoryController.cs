using eCommerse.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerse.Controllers
{
    public class CategoryController : Controller
    {
        eCommerseASMEntities objeCommerseASMEntities = new eCommerseASMEntities();
        // GET: Category

        public ActionResult Index()
        {
            var lstCategory = objeCommerseASMEntities.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory (int id )
        {
            var lstProduct = objeCommerseASMEntities.Products.Where(n => n.idCategory == id).ToList();
            return View(lstProduct);
        }
    }
}