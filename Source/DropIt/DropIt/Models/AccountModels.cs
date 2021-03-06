﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
namespace DropIt.Models
{
    //public class UsersContext : DbContext
    //{
    //    public UsersContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public DbSet<UserProfile> UserProfiles { get; set; }
    //}

    //[Table("UserProfile")]
    //public class UserProfile
    //{
    //    [Key]
    //    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    //    public int UserId { get; set; }
    //    public string UserName { get; set; }
    //}

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required(ErrorMessage = "Bạn phải nhập Mật Khẩu.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu Hiện Tại: ")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Mật Khẩu mới.")]
        [StringLength(100, ErrorMessage = "{0} phải dài ít nhất {2} kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu Mới: ")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác Nhận Mật Khảu Mới")]
        [Compare("NewPassword", ErrorMessage = "Mật Khẩu Xác Nhận Không Trùng Với Mật Khẩu Mới.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn phải nhập Tên Tài Khoản.")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

         [Required(ErrorMessage = "Bạn phải nhập Mật Khẩu.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ Tài khoản?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Bạn phải nhập Tên Tài Khoản.")]
        [StringLength(100, ErrorMessage = "{0} phải dài ít nhất {2} kí tự.", MinimumLength = 6)]
        [Display(Name = "Tên Tài Khoản")]
        public string UserName { get; set; }
        
        [StringLength(100, ErrorMessage = "{0} phải dài ít nhất {2} kí tự.", MinimumLength = 6)]
        [Display(Name = "Tên đầy đủ")]
        public string FullName { get; set; }
        
        [Display(Name = "Tên ngân hàng")]
        public string BankName { get; set; }
        
        [Display(Name = "Tài khoản ngân hàng")]
        public string BankAccount { get; set; }

        [StringLength(100, ErrorMessage = "{0} phải dài ít nhất {2} kí tự.", MinimumLength = 9)]
        [Display(Name = "Số CMND")]
        public string IdentityCard { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Mật Khẩu.")]
        [StringLength(100, ErrorMessage = "{0} phải dài ít nhất {2} kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Mật Khẩu Xác Nhận Không Trùng Với Mật Khẩu.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Bạn phải nhập Email.")]
        [RegularExpression(@"^[a-zA-Z0-9\.-]*@[a-zA-Z0-9\.]*\.[a-zA-Z\.]{2,6}$", ErrorMessage = "Email Không Chính xác.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Bạn phải nhập Số Điện Thoại.")]
        [RegularExpression(@"^0[0-9]{6,10}$", ErrorMessage = "Số điện thoại không chính xác. Ví dụ: 0909666666 | 083991199")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Địa chỉ.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn Tỉnh/Thành Phố.")]
        public int ProvinceId { get; set; }

    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
