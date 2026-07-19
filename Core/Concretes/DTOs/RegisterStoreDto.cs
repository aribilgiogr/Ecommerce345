using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class RegisterStoreDto
    {
        [Display(Name = "Mağaza Adı", Prompt = "Mağaza Adı")]
        [Required(ErrorMessage = "Mağaza Adı zorunludur!")]
        public string StoreName { get; set; } = null!;

        [Display(Name = "Vergi Dairesi", Prompt = "Vergi Dairesi")]
        [Required(ErrorMessage = "Vergi Dairesi zorunludur!")]
        public string TaxOffice { get; set; } = null!;

        [Display(Name = "Vergi Numarası", Prompt = "Vergi Numarası")]
        [Required(ErrorMessage = "Vergi Numarası zorunludur!")]
        public string TaxNumber { get; set; } = null!;

        [Display(Name = "İletişim Telefonu", Prompt = "İletişim Telefonu")]
        [Required(ErrorMessage = "İletişim Telefonu zorunludur!")]
        public string ContactPhone { get; set; } = null!;

        [Display(Name = "İletişim Eposta", Prompt = "İletişim Eposta")]
        [Required(ErrorMessage = "İletişim Eposta zorunludur!")]
        [EmailAddress(ErrorMessage = "Hatalı eposta formatı!")]
        public string ContactEmail { get; set; } = null!;


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
        [Compare("Password", ErrorMessage = "Parola girişlerinin uyuşmuyor!")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
