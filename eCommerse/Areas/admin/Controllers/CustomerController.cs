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
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objCustomer =  dbObj.Users.Where(n => n.id == id).FirstOrDefault();
            return View(objCustomer);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User objCustomer)
        {
            if(ModelState.IsValid)
            {
                int id = objCustomer.id;
                string nameUser = objCustomer.nameUser;
                string address = objCustomer.Address;
                string username = objCustomer.username;
                string password = objCustomer.password;
                int phonenumber = (int)objCustomer.phonenumber;
                string email = objCustomer.emaild;
                DateTime updateDate = (DateTime)objCustomer.updateDate;
                DateTime createdDate = (DateTime)objCustomer.createDate;
                string gender = objCustomer.gender;   
            }
            dbObj.Users.Add(objCustomer);
            dbObj.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCustomer = dbObj.Users.Where(n => n.id == id).FirstOrDefault();
            return View(objCustomer);
        }
        [HttpPost]
        public ActionResult Delete(User objUSer)
        {
            var objCustomer = dbObj.Users.Where(n => n.id == objUSer.id).FirstOrDefault();
            dbObj.Users.Remove(objCustomer);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}