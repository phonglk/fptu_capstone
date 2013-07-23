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
        // GET: /Category/

        public CategoryController()
        {
            Repository = unitOfWork.CategoryRepository;
        }

        public ActionResult Index(int CategoryStatus = 0)
        {
            ViewBag.CategoryStatus = CategoryStatus;
            return View();
        }

        //[HttpPost]
        //public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null)
        //{
        //    try
        //    {

        //        var records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);

        //        var Records = records.Select(e => new
        //        {
        //            CategoryId = e.CategoryId,
        //            CategoryName = e.CategoryName,
        //            ParentCategoryId = e.ParentCategoryId,
        //            Status = e.Status,
        //            Description = e.Description
        //        });
        //        return Json(new JSONResult(Records)
        //        {
        //            TotalRecordCount = Repository.Count
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        return Json(new JSONResult(e));
        //    }
        //}

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null, int CategoryStatus = -1)
        {
            try
            {
                IEnumerable<DropIt.Models.Category> records = null;

                if (CategoryStatus == -1)
                {
                    records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);
                }
                else
                {
                    records = Repository.JTGetExp(e => e.Status == CategoryStatus, jtStartIndex, jtPageSize, jtSorting);
                }
                var Records = records.Select(e => new
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName,
                    ParentCategoryId = e.ParentCategoryId,
                    Status = e.Status,
                    Description = e.Description,
                    Category = new
                    {
                        e.CategoryId,
                        e.CategoryName,
                        e.ParentCategoryId
                    }
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = (CategoryStatus == -1) ? Repository.Count : Repository.Get(e => e.Status == CategoryStatus).Count()
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(unitOfWork.CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            return View();
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
            String Error = "";
            try
            {
                Category.Status = (int)Statuses.Category.Active;

                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "Dữ liệu không hợp lệ";
                }

                var addedRecord = Repository.AddOrUpdate(Category);
                unitOfWork.Save();
                return Json(new
                    {
                        Result = "OK"
                    });
            }
            catch (Exception e)
            {
                Error = "Có lỗi xảy ra";
            }

            return Json(new
            {
                Result = "ERROR",
                Message = Error
            });
        }

        [HttpPost]
        public JsonResult Active(int Id)
        {
            try
            {
                Category delete = Repository.Get(e => e.CategoryId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Category.Active;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    CategoryId = delete.CategoryId
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    EventId = Id,
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Deactive(int Id)
        {
            try
            {
                Category delete = Repository.Get(e => e.CategoryId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Category.Deactive;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    CategoryId = delete.CategoryId
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    EventId = Id,
                    Message = e.Message
                });
            }
        }

        public JsonResult Delete(int Id)
        {
            try
            {
                Category delete = Repository.Get(e => e.CategoryId == Id).FirstOrDefault();
                delete.Status = (int)Statuses.Category.Delete;

                Repository.AddOrUpdate(delete);
                Repository.Save();
                return Json(new
                {
                    Result = "OK",
                    CategoryId = delete.CategoryId
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "ERROR",
                    EventId = Id,
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult GetOptions()
        {
            //try
            //{
            //    var Records = Repository.Get(x => x.ParentCategoryId == null).Select(
            //        p => new
            //        {
            //            DisplayText = p.CategoryName,
            //            Value = p.CategoryId,
            //            Children = Repository.Get(x => x.ParentCategoryId == p.CategoryId).Select(c => new
            //            {
            //                DisplayText = c.CategoryName,
            //                Value = c.CategoryId
            //            })
            //        });
            //    return Json(new JSONResult(Records, "Options"));

            //}
            //catch (Exception e)
            //{
            //    return Json(new JSONResult(e));
            //}
            try
            {
                var Records = unitOfWork.CategoryRepository.GetAll().Select(
                    p => new
                    {
                        DisplayText = p.CategoryName,
                        Value = p.CategoryId,
                        Children = unitOfWork.CategoryRepository.Get(x => x.ParentCategoryId == p.CategoryId).Select(c => new
                        {
                            DisplayText = c.CategoryName,
                            Value = c.CategoryId
                        })
                    });
                return Json(new JSONResult(Records, "Opptions"));
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        [HttpPost]
        public JsonResult GetParentOptions()
        {
            //try
            //{
            //    var Records = Repository.Get(x => x.ParentCategoryId == null).Select(
            //        p => new
            //        {
            //            DisplayText = p.CategoryName,
            //            Value = p.CategoryId
            //        });
            //    return Json(new JSONResult(Records, "Options"));

            //}
            try
            {
                var Records = unitOfWork.CategoryRepository.GetAll().Select(
                    p => new
                    {
                        DisplayText = p.CategoryName,
                        Value = p.CategoryId,
                        Parent = unitOfWork.CategoryRepository.Get(x => x.ParentCategoryId == null).Select(
                        t => new
                        {
                            DisplayText = t.CategoryName,
                            Value = t.CategoryId
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