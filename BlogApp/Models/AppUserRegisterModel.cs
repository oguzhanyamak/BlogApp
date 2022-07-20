using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class AppUserRegisterModel
    {
        [Display(Name="Ad")]
        [Required(ErrorMessage="Ad Giriniz")]
        public string name { get; set; }

        [Required(ErrorMessage = "Soyad Giriniz")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Şifre Giriniz")]
        public string password { get; set; }


        [Compare("password",ErrorMessage = "Şifreler Uyuşmuyor")]
        public string repassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail Adresi Giriniz")]
        public string mail { get; set; }
    }
}
