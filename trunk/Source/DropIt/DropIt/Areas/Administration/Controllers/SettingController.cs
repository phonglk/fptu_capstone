using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.DAL;
using DropIt.Models;
using DropIt.ViewModels;
using DropIt.Common;

namespace DropIt.Areas.Administration.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class SettingController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private SettingRepository Repository;

        public SettingController()
        {
            Repository = unitOfWork.SettingRepository;
        }
        //
        // GET: /Administration/Setting/

        public ActionResult Index()
        {
            return View();
        }   

        public ActionResult List()
        {
            var setting = this.unitOfWork.SettingRepository.GetAll();
            return View(setting.ToList());
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = -1, int jtPageSize = 0, string jtSorting = null)
        {
            IEnumerable<Setting> records = null;

            try
            {
                records = Repository.JTGet(jtStartIndex, jtPageSize, jtSorting);

                return Json(new JSONResult(records)
                {
                    TotalRecordCount = Repository.Count
                });
            }
            catch (Exception e)
            {
                return Json(new JSONResult(e));
            }
        }


        //Get: Create

        [HttpPost]
        public JsonResult Create(SettingViewModel setting)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Setting newSetting = new Setting()
                                             {
                                                 SettingName = setting.SettingName,
                                                 Value = setting.Value
                                             };
                    this.unitOfWork.SettingRepository.AddOrUpdate(newSetting);
                    this.unitOfWork.Save();
                    return Json(new
                    {
                        Result = "OK"
                    });
                }
                else
                {
                    return Json(new
                    {
                        Result = "Error",
                        Message = "Dữ liệu truyền lên không hợp lệ"
                    });
                }
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "Error",
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            try
            {
                this.unitOfWork.SettingRepository.Delete(Id);
                this.unitOfWork.Save();
                return Json(new
                {
                    Result = "OK"
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "Error",
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        public JsonResult Edit(Setting setting)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.unitOfWork.SettingRepository.AddOrUpdate(setting);
                    this.unitOfWork.Save();
                    return Json(new
                    {
                        Result = "OK"
                    });
                }
                else
                {
                    return Json(new
                    {
                        Result = "Error",
                        Message = "Dữ liệu truyền lên không hợp lệ"
                    });
                }
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Result = "Error",
                    Message = e.Message
                });
            }
        }
    }
}
