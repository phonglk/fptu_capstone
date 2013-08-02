using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Models;
using DropIt.DAL;
using DropIt.Filters;

namespace DropIt.Controllers
{
    [InitializeSimpleMembership]
    public class CategoryController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Category/


        public CategoryController()
        {
            
        }

        public ActionResult Index()
        {
            var cats = this.unitOfWork.CategoryRepository.Get();
            return View(cats.ToList());
            //var cats = categoryRepository.GetAll();
            //return View(cats.ToList());          
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            Category cats = this.unitOfWork.CategoryRepository.GetById(id);
            if(cats == null)
            {
                return HttpNotFound();
            }
            return View(cats);
            //Category category = categoryRepository.GetById(id);
            //if (category == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            ViewBag.ParentCategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId",
                                                      "CategoryName");
            return View();
            //ViewBag.ParentCategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            //return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //categoryRepository.AddOrUpdate(category);
                //categoryRepository.Save();
                //return RedirectToAction("Index");
                this.unitOfWork.CategoryRepository.AddOrUpdate(category);
                this.unitOfWork.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.ParentCategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.ParentCategoryId);
            //return View(category);
            ViewBag.ParentCategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId",
                                                      "CategoryName", category.CategoryId);
            return View(category);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Category category = categoryRepository.GetById(id);
            Category category = this.unitOfWork.CategoryRepository.GetById(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentCategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "CategoryName", category.CategoryId);

            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                //categoryRepository.AddOrUpdate(category);
                //categoryRepository.Save();
                this.unitOfWork.CategoryRepository.AddOrUpdate(category);
                this.unitOfWork.CategoryRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryId = new SelectList(this.unitOfWork.CategoryRepository.Get(), "CategoryId", "ParentCategoryName", category.ParentCategoryId);
            return View(category);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Category category = categoryRepository.GetById(id);
            Category category = this.unitOfWork.CategoryRepository.GetById(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.unitOfWork.CategoryRepository.Delete(id);
            this.unitOfWork.CategoryRepository.Save();
            //categoryRepository.Delete(id);
            //categoryRepository.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult getAll()
        {
            var Categories = this.unitOfWork.CategoryRepository.GetAll().Select( c => new {
                c.CategoryId,
                c.CategoryName
            });
            return Json(new {
                Records = Categories
            });
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
            //db.Dispose();
            //base.Dispose(disposing);
        }
    }
}