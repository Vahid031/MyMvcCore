using System.ComponentModel.DataAnnotations;

namespace ViewModels.General
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "نام کاربری")]
        public string UserName
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "کلمه عبور")]
        public string Password
        {
            get;
            set;
        }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
