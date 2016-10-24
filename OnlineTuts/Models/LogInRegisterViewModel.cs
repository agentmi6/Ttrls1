using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTuts.Models
{
    public class LogInRegisterViewModel
    {
        public LoginViewModel login { get; set; }
        public RegisterViewModel register { get; set; }
    }
}