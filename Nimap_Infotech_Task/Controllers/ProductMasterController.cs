using Nimap_Infotech_Task.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace Nimap_Infotech_Task.Controllers
{
    public class ProductMasterController : Controller
    {
        // GET: Category
        public ActionResult Index(int? pageNumber)
        {
            CommonDBContext dBContext = new CommonDBContext();
            ModelState.Clear();
            //List<ProductMaster> obj = dBContext.GetProducts();
            return View(dBContext.GetProducts().ToPagedList(pageNumber??1,10));
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
        public ActionResult Create(ProductMaster cat)

        {
            CommonDBContext context = new CommonDBContext();
            try
            {
                if (ModelState.IsValid == true)
                {

                    bool check = context.AddProductMaster(cat);
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
        public ActionResult Edit(int ProductId)
        {
            CommonDBContext context = new CommonDBContext();
            var row = context.GetProducts().Find(model => model.ProductId == ProductId);
            return View(row);
        }

        //update form data in db table
        [HttpPost]
        public ActionResult Edit(ProductMaster prd)
        {

                CommonDBContext context = new CommonDBContext();
                bool check = context.UpdateProductMaster(prd);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "data has been updated succefully.";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }

            return View();
        }

        //delete display data
        public ActionResult Delete(int ProductId)
        {
            CommonDBContext context = new CommonDBContext();
            var row = context.GetProducts().Find(model => model.ProductId == ProductId);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int ProductId, ProductMaster cat)
        {
            CommonDBContext context = new CommonDBContext();
            bool check = context.DeleteProductMaster(ProductId);
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