using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DropIt.Areas.Administration.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Bạn cần điền tên danh mục")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Bạn cần điền tên danh mục cha")]
        public string CategoryParentName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}