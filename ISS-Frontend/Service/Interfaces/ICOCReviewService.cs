using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services.Interfaces
{
    public interface ICOCReviewService
    {
        int AddReview(COCReview review);
        bool DeleteReview(int id);
        bool UpdateReview(int id, COCReview review);
        IEnumerable<COCReview> GetAllReviews();
        COCReview? GetReview(int id);
        IEnumerable<COCReview> GetReviewsFromUser(int userId);
        IEnumerable<COCReview> GetReviewsForProduct(int productId);
    }
}
