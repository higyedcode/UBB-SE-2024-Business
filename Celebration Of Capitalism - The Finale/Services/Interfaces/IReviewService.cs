using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services.Interfaces
{
    public interface IReviewService
    {
        int AddReview(Review review);
        bool DeleteReview(int id);
        bool UpdateReview(int id, Review review);
        IEnumerable<Review> GetAllReviews();
        Review? GetReview(int id);
        IEnumerable<Review> GetReviewsFromUser(int userId);
        IEnumerable<Review> GetReviewsForProduct(int productId);
    }
}
