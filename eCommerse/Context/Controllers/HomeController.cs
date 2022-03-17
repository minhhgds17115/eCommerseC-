using eCommerse.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using eCommerse.Models;
using System.Security.Cryptography;
using System.Text;

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
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var check = objeCommerseASMEntities.Users.FirstOrDefault(s => s.emaild == user.emaild);
                if(check== null)
                {
                    user.password = GetMD5(user.password);
                    objeCommerseASMEntities.Configuration.ValidateOnSaveEnabled = false;
                    objeCommerseASMEntities.Users.Add(user);
                    objeCommerseASMEntities.SaveChanges();
                    return RedirectToAction("Index");   
                }
                else
                {
                    ViewBag.error = "email already exist";
                    return View();
                }

            }
            //kt vs luu vao db
            return View("Index");
        }
        //create a MD5  
        public static string GetMD5(string str)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = mD5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
                {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String; 
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = objeCommerseASMEntities.Users.Where(s => s.emaild.Equals(email) && s.password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().username ;
                    Session["Email"] = data.FirstOrDefault().emaild;
                    Session["idUser"] = data.FirstOrDefault().id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}