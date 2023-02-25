using Nimap_Infotech_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nimap_Infotech_Task.Controllers
{
    public class CategoryMasterController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CommonDBContext dBContext = new CommonDBContext();
            List<CategoryMaster> obj = dBContext.GetCategory();
            return View(obj);
        }

        //add category
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cat)

        {
            CommonDBContext context = new CommonDBContext();
            try
            {
                if (ModelState.IsValid == true)
                {

                    bool check = context.AddCategoryMaster(cat);
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

        //update displays data
        public ActionResult Edit(int CategoryId)
        {
            CommonDBContext context = new CommonDBContext();
            var row = context.GetCategory().Find(model => model.CategoryId == CategoryId);
            return View(row);
        }

        //update form data in db table
        [HttpPost]
        public ActionResult Edit(int CategoryId, Category prd)
        {
            if (ModelState.IsValid == true)
            {
                CommonDBContext context = new CommonDBContext();
                bool check = context.UpdateCategoryMaster(prd, CategoryId);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "data has been updated succefully.";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        //delete display data
        public ActionResult Delete(int CategoryId)
        {
            CommonDBContext context = new CommonDBContext();
            var row = context.GetCategory().Find(model => model.CategoryId == CategoryId);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int CategoryId, CategoryMaster cat)
        {
            CommonDBContext context = new CommonDBContext();
            bool check = context.DeleteCategoryMaster(CategoryId);
            if (check == true)
            {
                TempData["DeleteMessage"] = "data has been Deleted succefully.";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}