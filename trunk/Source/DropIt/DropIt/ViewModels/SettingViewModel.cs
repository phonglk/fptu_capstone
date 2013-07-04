using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DropIt.ViewModels
{
    public class SettingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Bạn phải nhập tên Setting!")]
        public string SettingName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập giá trị!")]
        public string Value { get; set; }
    }
}