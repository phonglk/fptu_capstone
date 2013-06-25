using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DropIt.ViewModels
{
    public class UserViewModel
    {
         public UserViewModel()
        {
            this.Requests = new HashSet<Request>();
            this.Tickets = new HashSet<Ticket>();
            this.Tickets1 = new HashSet<Ticket>();
            this.UserFollowEvents = new HashSet<UserFollowEvent>();
        }
    
        public int UserId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Tên Tài Khoản.")]
        public string UserName { get; set; }

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
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn Tỉnh/Thành Phố.")]
        public int ProvinceId { get; set; }
    
        public virtual Province Province { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Ticket> Tickets1 { get; set; }
        public virtual ICollection<UserFollowEvent> UserFollowEvents { get; set; }
    }
    }