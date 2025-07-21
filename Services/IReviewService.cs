using WebApplication7.Data.Models;
using WebApplication7.Models.DTO;

namespace WebApplication7.Services
{
    public interface IReviewService
    {
        IList<Review> GetReviewsByProductId(int productId);
        void CreateReview(int productId, ReviewDTO reviewDTO);
    }
}
