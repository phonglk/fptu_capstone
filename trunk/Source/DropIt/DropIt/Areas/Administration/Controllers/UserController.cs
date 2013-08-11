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
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null,int isActive = -1,int isSellable =-1,String UserName = "")
        {
            try
            {
                if (jtSorting.Trim().Equals(""))
                {
                    jtSorting = "UserName ASC";
                }
                var records = Repository.Get(u=>u.UserName.Equals("admin")==false);
                if (isActive != -1)
                {
                    records = records.Where(u => u.Active == (isActive == 1));
                }

                if (isSellable != -1)
                {
                    records = records.Where(u => u.Sellable == (isSellable == 1));
                }

                if (UserName.Trim().Equals("") == false)
                {
                    records = records.Where(u => u.UserName.Contains(UserName));
                }

                int totalFilterRecord = records.Count();

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
                    e.IdentityCard,
                    e.BankAccount,
                    e.BankName,
                    Phone = e.Phone,
                    Active = e.Active,
                    Sellable = e.Sellable,
                    e.CreatedDate,
                    e.ModifiedDate
                });
                return Json(new JSONResult(Records)
                {
                    TotalRecordCount = totalFilterRecord
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

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
