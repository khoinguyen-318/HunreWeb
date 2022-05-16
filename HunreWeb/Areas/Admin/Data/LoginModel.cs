using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HunreWeb.Areas.Admin.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập username")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Mời nhập pasdword")]
        public string passWord { get; set; }
    }
}