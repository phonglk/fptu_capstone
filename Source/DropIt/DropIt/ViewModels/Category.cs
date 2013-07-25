using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DropIt.ViewModels
{
    public class Category
    {

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Bạn cần phải nhập thể loại!")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập miêu tả!")]
        public string Description { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}