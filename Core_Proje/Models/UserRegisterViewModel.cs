using System.ComponentModel.DataAnnotations;

namespace Project.UI.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen isminizi girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyisminizi girin")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adı girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifreyi tekrar girin")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen mail girin")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen fotoğraf adresini girin")]
        public string ImageURL { get; set; }
    }
}
