using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models.DTO
{
    public class UserCredentialsDto
    {
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [MaxLength(320, ErrorMessage = "Некорректный адрес электронной почты")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [MaxLength(64, ErrorMessage = "Некорректный пароль")]
        public string? Password { get; set; }
    }
}
