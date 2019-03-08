﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRunBingo.Models.Requests
{
    public class LoginRequest
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [MinLength(2)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
