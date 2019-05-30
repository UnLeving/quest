using System.ComponentModel.DataAnnotations;

namespace LenaQuest.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        //[Required]
        public string SecondName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int QuestExpirience { get; set; }
        [Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        //[DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
