using System.ComponentModel.DataAnnotations;

namespace CoreCampBlog.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Şifre Giriniz")]
        public string Password { get; set; }
    }
}
