using eCommerse.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerse.Controllers
{
    public class ProductController : Controller
    {
        eCommerseASMEntities objeCommerseEntities = new eCommerseASMEntities();

        // GET: Product
        public ActionResult Detail(int id)
        {
            var objProduct = objeCommerseEntities.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
    }
}