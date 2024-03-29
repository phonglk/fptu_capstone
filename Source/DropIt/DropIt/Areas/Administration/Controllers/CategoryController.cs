﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.Models;
using DropIt.DAL;
using DropIt.Common;
using System.Diagnostics;
using DropIt.Areas.Administration.ViewModels;
using DropIt.Filters;

namespace DropIt.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembership]
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

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = "CategoryName ASC", int CategoryStatus = -1)
        {
            try
            {
                if (jtSorting.Trim().Equals(""))
                {
                    jtSorting = "CategoryName ASC";
                }
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
                    Status = e.Status,
                    Description = e.Description,
                    ParentCategory = e.Category2 == null ? null : new
                    {
                        e.ParentCategoryId,
                        e.Category2.CategoryId,
                        e.Category2.CategoryName
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
            ViewBag.CategoryId = new SelectList(unitOfWork.CategoryRepository.GetAvailable().Where(t => t.ParentCategoryId == null), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Create(Category Category)
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

                TempData["Message"] = "Đã tạo thành công danh mục mới! " + Category.CategoryName;
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

        public ActionResult Edit(int Id)
        {
            Category e = Repository.GetById(Id);
            CategoryViewModel cvm = new CategoryViewModel()
            {
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName,
                Status = e.Status,
                Description = e.Description,
                ParentCategoryId = e.ParentCategoryId,
            };
            ViewBag.CategoryId = new SelectList(unitOfWork.CategoryRepository.Get(t => t.ParentCategoryId == null && t.Status != (int)Statuses.Category.Delete), "CategoryId", "CategoryName");
            return View(cvm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(Category Category)
        {
            Category oldCategory = Repository.GetById(Category.CategoryId);
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }
                Category.Status = oldCategory.Status;
                Repository.AddOrUpdate(Category);
                unitOfWork.Save();

                return Json(new JSONResult());

            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            };
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
                if
                    (delete.Events.Where(p => p.Status != (int)Statuses.Event.Delete && p.Status != (int)Statuses.Event.Disapprove).Count() >= 1)
                {
                    return Json(new JSONResult()
                    {
                        Result = "ERROR",
                        Message = "Không thể ẩn danh mục có sự kiện!"
                    });
                }
                else
                {
                    delete.Status = (int)Statuses.Category.Deactive;
                }
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
        public JsonResult Delete(int Id)
        {
            try
            {
                Category delete = Repository.Get(e => e.CategoryId == Id).FirstOrDefault();
                if (delete.Category1.Where(c=>c.Status != (int)Statuses.Category.Delete).Count() == 0)
                {
                    delete.Status = (int)Statuses.Category.Delete;
                }
                else
                {
                    return Json(new
                      {
                          Result = "ERROR",
                          Message = "Không thể xóa Danh mục có danh mục con!"
                      });
                }
                if(delete.Events.Where(p => p.Status != (int)Statuses.Event.Delete).Count() >= 1)
                {
                    return Json(new JSONResult()
                    {
                        Result = "ERROR",
                        Message = "Không thể xóa danh mục có sự kiện!"
                    });
                }



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

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}