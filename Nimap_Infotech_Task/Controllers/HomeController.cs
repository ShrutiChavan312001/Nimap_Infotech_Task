using Nimap_Infotech_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Data;

namespace Nimap_Infotech_Task.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? pageNumber)
        {
            CommonDBContext db = new CommonDBContext();
            ModelState.Clear();
            return View(db.GetProductDetails().ToPagedList(pageNumber ?? 1, 10));
        }

        public ActionResult Create()
        {
            CommonDBContext context1 = new CommonDBContext();
            DataSet ds = new DataSet();
            ds = context1.GetCategoryMaster();
            ViewBag.CategoryName = ds.Tables[0].ToSelectList("CategoryId", "CategoryName");
            ViewBag.Product_Name = ds.Tables[1].ToSelectList("ProductId", "ProductName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryMaster cat)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    CommonDBContext context = new CommonDBContext();
                    bool check = context.AddCategory(cat);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data has been Inserted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


    }
}