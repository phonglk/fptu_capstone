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