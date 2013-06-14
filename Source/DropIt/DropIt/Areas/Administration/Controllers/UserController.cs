using DropIt.Common;
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
    //[Authorize(Roles = "Administrator")]
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
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {

                var records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);

                var Records = records.Select(e => new
                {
                    UserId = e.UserId,
                    UserName = e.UserName,
                    Email = e.Email,
                    Address = e.Address,
                    Phone = e.Phone,
                    Active = e.Active,
                    Sellable = e.Sellable,
                    ProvinceId = e.ProvinceId                    
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
        

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
