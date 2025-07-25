using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models.DTO
{
    public class NewUserDto
    {
        [Required(ErrorMessage = "Укажите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длинна имени - 2 символа")]
        [MaxLength(64, ErrorMessage = "Максимальная длинна имени - 64 символа")]
        public string? FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Минимальная длинна фамилии - 2 символа")]
        [MaxLength(64, ErrorMessage = "Максимальная длинна фамилии - 64 символа")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [MaxLength(320, ErrorMessage = "Адрес электронной почты слишком длинный")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage = "Минимальная длинна пароля - 8 символа")]
        [MaxLength(64, ErrorMessage = "Максимальная длинна пароля - 64 символа")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
