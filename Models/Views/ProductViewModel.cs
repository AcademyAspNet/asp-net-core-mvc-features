using WebApplication7.Models.DTO;
using WebApplication7.Models.Entities;

namespace WebApplication7.Models.Views
{
    public class ProductViewModel
    {
        public required Product Product { get; set; }
        public ReviewDTO? Review { get; set; }
    }
}
