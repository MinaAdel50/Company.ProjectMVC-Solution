using System.ComponentModel.DataAnnotations;

namespace Company.ProjectMVC.PL.ViewModel.Auth
{
    public class SignUpViewmModel
    {
        [Required(ErrorMessage ="UserName is Required !!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FirstName is Required !!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required !!")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required !!")]
        [EmailAddress(ErrorMessage = "Invalid Email !!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required !!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required !!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Confirmed Password does not match Password!!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "IsAgree is Required !!")]

        public bool IsAgree { get; set; }





    }
}
