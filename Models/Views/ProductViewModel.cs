using WebApplication7.Data.Models;
using WebApplication7.Models.DTO;

namespace WebApplication7.Models.Views
{
    public class ProductViewModel
    {
        public required Product Product { get; set; }
        public ReviewDTO? Review { get; set; }
    }
}
