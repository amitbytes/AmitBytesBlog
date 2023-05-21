using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmitBytesBlog.Admin.Models
{
    public class SystemUserVM
    {
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [MinLength(6,ErrorMessage ="Please enter atleast {1} characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Captcha is required")]
        [MinLength(5,ErrorMessage ="Please enter atleast {1} characters")]
        public string Captcha { get; set; }
    }
}
