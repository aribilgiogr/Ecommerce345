using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class RegisterCustomerDto
    {
        [Display(Name ="İsim",Prompt="İsim")]
        [Required(ErrorMessage = "İsim zorunludur!")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Soyisim", Prompt = "Soyisim")]
        [Required(ErrorMessage = "Soyisim zorunludur!")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Eposta Adresi", Prompt = "Eposta Adresi")]
        [Required(ErrorMessage = "Eposta adresi zorunludur!")]
        [EmailAddress(ErrorMessage = "Hatalı eposta formatı!")]
        public string Email { get; set; } = null!;

        [Display(Name = "Parola", Prompt = "Parola")]
        [Required(ErrorMessage = "Parola zorunludur!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre formatınız hatalı!")]
        public string Password { get; set; } = null!;

        [Display(Name = "Parola Onayla", Prompt = "Parola Onayla")]
        [Required(ErrorMessage = "Parola Onaylama zorunludur!")]
        [DataType(DataType.Password, ErrorMessage = "Şifre formatınız hatalı!")]
        [Compare("Password",ErrorMessage ="Parola girişlerinin uyuşmuyor!")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
