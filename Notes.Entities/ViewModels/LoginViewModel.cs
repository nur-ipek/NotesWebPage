﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notes.WebApp.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Username { get; set; }
        [DisplayName("Şifre"),Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string Password { get; set; }
    }
}