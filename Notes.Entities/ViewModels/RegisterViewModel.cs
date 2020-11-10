using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notes.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            StringLength(25, ErrorMessage ="{0} max. {1} karekter olmalı.")]
        public string Username { get; set; }

        [DisplayName("E-posta"),
           Required(ErrorMessage = "{0} alanı boş geçilemez."),
           StringLength(70, ErrorMessage = "{0} max. {1} karekter olmalı."),
           EmailAddress()]
        public string Email { get; set; }

        [DisplayName("Şifre"),
           Required(ErrorMessage = "{0} alanı boş geçilemez."),
           StringLength(25, ErrorMessage = "{0} max. {1} karekter olmalı."),
           DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"),
           Required(ErrorMessage = "{0} alanı boş geçilemez."),
           StringLength(25, ErrorMessage = "{0} max. {1} karekter olmalı."),
           DataType(DataType.Password),
           Compare("Password", ErrorMessage = "{0} ile {1} uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}