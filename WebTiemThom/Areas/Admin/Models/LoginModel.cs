using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebTiemThom.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}