using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DropIt.DAL;

namespace DropIt.ViewModels
{
    public class UserViewModel
    {
         public UserViewModel()
        {
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }
    
        public int UserId { get; set; }

        public string UserName { get;set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Bạn phải nhập Email.")]
        [RegularExpression(@"^[a-zA-Z0-9\.-]*@[a-zA-Z0-9\.]*\.[a-zA-Z\.]{2,6}$", ErrorMessage = "Email Không Chính xác.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Số Điện Thoại.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Địa chỉ.")]
        public string Address { get; set; }

        public bool Active { get; set; }
        public bool Sellable { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn Tỉnh/Thành Phố.")]
        public int? ProvinceId { get; set; }

        public string FullName { get; set; }

        public string BankAccount { get; set; }

        public string BankName { get; set; }

        [StringLength(100, ErrorMessage = "{0} phải dài ít nhất {2} kí tự.", MinimumLength = 9)]
        [Display(Name = "Số CMND")]
        public string IdentityCard { get; set; }
    
        public virtual Province Province { get; set; }
    }
    }