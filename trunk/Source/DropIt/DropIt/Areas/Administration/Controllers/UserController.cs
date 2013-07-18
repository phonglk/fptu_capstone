﻿using DropIt.Common;
using DropIt.DAL;
using DropIt.Filters;
using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace DropIt.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
    [InitializeSimpleMembership]
    public class UserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private UserRepository Repository;
        //
        // GET: /Administration/User/

        public UserController()
        {
            Repository = unitOfWork.UserRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null,int isActive = -1,int isSellable =-1)
        {
            try
            {
                var records = Repository.GetAll();
                if (isActive != -1)
                {
                    records = records.Where(u => u.Active == (isActive == 1));
                }

                if (isSellable != -1)
                {
                    records = records.Where(u => u.Sellable == (isSellable == 1));
                }

                records = Repository.JT(records, jtStartIndex, jtPageSize, jtSorting);

                var Records = records.Select(e => new
                {
                    UserId = e.UserId,
                    UserName = e.UserName,
                    FullName = e.FullName,
                    Email = e.Email,
                    Address = e.Address,
                    Province = new {
                        e.Province.ProvinceId,
                        e.Province.ProvinceName
                    },
                    Phone = e.Phone,
                    Active = e.Active,
                    Sellable = e.Sellable,
                    e.CreatedDate,
                    e.ModifiedDate
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
        // Create

        [HttpPost]
        public JsonResult UpdateActive(int UserId, bool Active)
        {
            try
            {
                User user = Repository.GetById(UserId);
                if (user != null)
                {
                    user.Active = Active;
                    Repository.AddOrUpdate(user);
                    Repository.Save();
                    return Json(new
                    {
                        Result = "OK"
                    });
                }
                else
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "User not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "ERROR",
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public JsonResult UpdateSellable(int UserId, bool Sellable)
        {
            try
            {
                User user = Repository.GetById(UserId);
                if (user != null)
                {
                    user.Sellable = Sellable;
                    Repository.AddOrUpdate(user);
                    Repository.Save();
                    return Json(new
                    {
                        Result = "OK"
                    });
                }
                else
                {
                    return Json(new
                    {
                        Result = "ERROR",
                        Message = "User not found"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "ERROR",
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Create(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is not valid"));
                }

                var addedRecord = Repository.AddOrUpdate(user);
                unitOfWork.Save();
                return Json(new JSONResult(addedRecord, "Record"));

            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
                throw;
            }
        }

        // Update
        [HttpPost]
        public JsonResult Update(User user)
        {
            try
            {
                user.UserName = unitOfWork.UserRepository.GetById(user.UserId).UserName;
                user.CreatedDate = unitOfWork.UserRepository.GetById(user.UserId).CreatedDate;
                if (!ModelState.IsValid)
                {
                    return Json(new JSONResult("Form is invalid"));
                }
                
                
                Repository.AddOrUpdate(user);
                unitOfWork.Save();
                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }

        //Delete
        public JsonResult Delete(int UserId)
        {
            try
            {
                Repository.Delete(UserId);
                unitOfWork.Save();

                return Json(new JSONResult());
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }

        }
        [HttpPost]
        public JsonResult GetUserOptions()
        {
            try
            {
                var usernames = unitOfWork.UserRepository.GetAll().Select(
                    p => new { DisplayText = p.UserName, Value = p.UserId });

                return Json(new JSONResult(usernames, "Options"));

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