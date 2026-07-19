using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class LoginDto
    {
        [Display(Name = "Eposta Adresi", Prompt = "Eposta Adresi")]
        [Required(ErrorMessage = "Eposta adresi zorunludur!")]
        [EmailAddress(ErrorMessage = "Hatalı eposta formatı!")]
        public string Email { get; set; } = null!;

        [Display(Name = "Parola", Prompt = "Parola")]
        [Required(ErrorMessage = "Parola zorunludur!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre formatınız hatalı!")]
        public string Password { get; set; } = null!;

        [Display(Name = "Beni Hatırla", Prompt = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
