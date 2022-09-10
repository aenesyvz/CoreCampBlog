using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCampBlog.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Ad Soyad Giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail Adresi Giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullaanıcı Adı")]
        [Required(ErrorMessage = "Kullanıc Adı Giriniz")]
        public string UserName { get; set; }
    }
}
