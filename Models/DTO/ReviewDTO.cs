using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models.DTO
{
    public class ReviewDTO
    {
        [Display(Name = "Имя и фамилия")]
        public string? Author { get; set; }

        [Display(Name = "Текст отзыва")]
        [DataType(DataType.MultilineText)]
        public string? Text { get; set; }
    }
}
