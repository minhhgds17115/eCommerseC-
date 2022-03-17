using eCommerse.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerse.Areas.admin.Controllers
{
    public class CustomerController : Controller
    {
        eCommerseASMEntities dbObj = new eCommerseASMEntities();

        // GET: admin/Customer
        public ActionResult Index()
        {
            var lstCustomer = dbObj.Users.ToList();
            return View(lstCustomer);
        }
    }
}