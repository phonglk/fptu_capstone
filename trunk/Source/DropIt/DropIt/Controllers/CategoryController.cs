using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Models;
using DropIt.DAL;

namespace DropIt.Controllers
{
    public class CategoryController : Controller
    {
        private DropItContext db = new DropItContext();
        private ICategoryRepository categoryRepository;

        //
        // GET: /Category/
        public CategoryController()
        {
            this.categoryRepository = new CategoryRepository(db);
        }

        public ActionResult Index()
        {
            var cats = categoryRepository.GetAll();
            return View(cats.ToList());          
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            Category category = categoryRepository.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            ViewBag.ParentCategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        //
        // POST: /Category/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.AddOrUpdate(category);
                categoryRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ParentCategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.ParentCategoryId);
            return View(category);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category category = categoryRepository.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentCategoryId = new SelectList(db.Categories, "CategoryId", "ParentCategoryName", category.ParentCategoryId);
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
                categoryRepository.AddOrUpdate(category);
                categoryRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryId = new SelectList(db.Categories, "CategoryId", "ParentCategoryName", category.ParentCategoryId);
            return View(category);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Category category = categoryRepository.GetById(id);
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
            categoryRepository.Delete(id);
            categoryRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}