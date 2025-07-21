using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models.DTO
{
    public class ReviewDTO
    {
        [Display(Name = "Имя и фамилия")]
        [Required(ErrorMessage = "Укажите Ваше имя")]
        [MaxLength(64, ErrorMessage = "Имя автора слишком длинное")]
        public string? Author { get; set; }

        [Display(Name = "Текст отзыва")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Напишите текст отзыва")]
        [MaxLength(512, ErrorMessage = "Текст отзыва слишком длинный")]
        public string? Text { get; set; }
    }
}
