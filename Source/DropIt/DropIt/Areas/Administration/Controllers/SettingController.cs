using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropIt.DAL;
using DropIt.Models;
using DropIt.ViewModels;

namespace DropIt.Areas.Administration.Controllers
{
    [Authorize(Roles = "Administrator")]
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

        //Get: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SettingViewModel setting)
        {
            if (ModelState.IsValid)
            {
                Setting newSetting = new Setting()
                                         {
                                             Id = setting.Id,
                                             SettingName = setting.SettingName,
                                             Value = setting.Value
                                         };
                this.unitOfWork.SettingRepository.AddOrUpdate(newSetting);
                this.unitOfWork.Save();
                return RedirectToAction("List");
            }
            return View(setting);
        }

        //Get: Edit
        public ActionResult Edit(int id = 0)
        {
            Setting setting = this.unitOfWork.SettingRepository.GetById(id);
            SettingViewModel stt = new SettingViewModel()
                                       {
                                           Id = setting.Id,
                                           SettingName = setting.SettingName,
                                           Value = setting.Value
                                       };
            if (stt == null)
            {
                HttpNotFound();
            }
            return View(stt);
        }

        [HttpPost]
        public ActionResult Edit(SettingViewModel setting)
        {
            Setting getSetting = this.unitOfWork.SettingRepository.GetById(setting.Id);
            if (ModelState.IsValid)
            {
                Setting newSetting = new Setting()
                                         {
                                             Id = getSetting.Id,
                                             SettingName = setting.SettingName,
                                             Value = setting.Value
                                         };
                this.unitOfWork.SettingRepository.AddOrUpdate(newSetting);
                this.unitOfWork.Save();
                return RedirectToAction("List");
            }
            return View(setting);
        }
    }
}
