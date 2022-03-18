using eCommerse.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerse.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {
        eCommerseASMEntities dbObj = new eCommerseASMEntities();
        // GET: admin/Category
        public ActionResult Index()
        {
            var lstCategory = dbObj.Categories.ToList();
            return View(lstCategory);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Category objCate)
        {
            if (ModelState.IsValid)
            {
                
                {
                    int CategoryID = objCate.id_category;
                    string CategoryName = objCate.name_category;
                    string CategoryDesc = objCate.desc_category;

                    dbObj.Categories.Add(objCate);
                    dbObj.SaveChanges();
                    return RedirectToAction("index");

                }
                }
                return RedirectToAction("index");
            }
        
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objCategory = dbObj.Categories.Where(n => n.id_category == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCategory = dbObj.Categories.Where(n => n.id_category == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Delete(Category objCate)
        {
            var objCategory = dbObj.Categories.Where(n => n.id_category == objCate.id_category).FirstOrDefault();
            dbObj.Categories.Remove(objCategory);
            dbObj.SaveChanges();
            return RedirectToAction( "index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objCategory = dbObj.Categories.Where(n => n.id_category == id).FirstOrDefault();
            return View(objCategory);
        }

        [HttpPost]
        public ActionResult Edit(int id, Category objCate)
        {
            if (objCate.name_category != null)
            {
                int CategoryID = objCate.id_category;
                string CategoryName = objCate.name_category;
                string CategoryDesc = objCate.desc_category;
            }

            dbObj.Entry(objCate).State = EntityState.Modified;
            dbObj.SaveChanges();
            return View(objCate);

        } 

         

}

    }
