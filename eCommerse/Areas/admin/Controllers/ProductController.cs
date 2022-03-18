using eCommerse.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eCommerse.Areas.admin.Controllers
{
    public class ProductController : Controller
    {
        eCommerseASMEntities dbObj = new eCommerseASMEntities();
        // GET: admin/Product
        public ActionResult Index(string Currentfilter,string SearchString, int? page)
        {

            var lstProduct = new List<Product>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
                {
                SearchString = Currentfilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = dbObj.Products.Where(n => n.productName.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = dbObj.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            lstProduct = lstProduct.OrderByDescending(n => n.id).ToList();

            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = dbObj.Products.Where(n => n.id == objPro.id).FirstOrDefault();
            dbObj.Products.Remove(objProduct);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }
        
       
       
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try
            {
                if( objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName  + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                dbObj.Products.Add(objProduct);
                dbObj.SaveChanges();
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return RedirectToAction("index"); 
            }
            
        }
 //Edit
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objProduct = dbObj.Products.Where(n => n.id == n.id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product objProduct)
        {
            if
                (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyy,MM,D,H,ss")) + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/Product/ "), fileName));

            }
            dbObj.Entry(objProduct).State = EntityState.Modified;
            dbObj.SaveChanges();
            return View(objProduct);
        }

    }
    


}