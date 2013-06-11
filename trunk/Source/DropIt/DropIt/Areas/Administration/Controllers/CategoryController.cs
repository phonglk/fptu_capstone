using DropIt.Common;
using DropIt.DAL;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Areas.Administration.Controllers
{
    public class CategoryController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private GenericRepository<Category> Repository;
        //
        // GET: /Venue/

        public CategoryController()
        {
            Repository = unitOfWork.CategoryRepository;
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {

                var records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);

                var Records = records.Select(e => new
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = Repository.Count
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        [HttpPost]
        public JsonResult Create(Category Category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is not valid"));
                }

                var addedRecord = Repository.AddOrUpdate(Category);
                unitOfWork.Save();
                return Json(new JSONResult(addedRecord, "Record"));

            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
                throw;
            }
        }

        [HttpPost]
        public JsonResult Update(Category Category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }

                Repository.AddOrUpdate(Category);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public JsonResult Delete(int CategoryId)
        {
            try
            {
                Repository.Delete(CategoryId);
                unitOfWork.Save();

                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }

        }

        [HttpPost]
        public JsonResult GetOptions()
        {
            try
            {
                var Records = Repository.Get(x => x.ParentCategoryId == null).Select(
                    p => new
                    {
                        DisplayText = p.CategoryName,
                        Value = p.CategoryId,
                        Children = Repository.Get(x => x.ParentCategoryId == p.CategoryId).Select(c => new
                        {
                            DisplayText = c.CategoryName,
                            Value = c.CategoryId
                        })
                    });
                return Json(new JSONResult(Records, "Options"));

            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}
