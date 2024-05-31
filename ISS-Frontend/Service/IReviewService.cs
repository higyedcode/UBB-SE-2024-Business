using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public interface IReviewService
    {
        List<ReviewClass> GetAllReviews();
        ReviewClass GetReviewById(int id);
        void AddReview(ReviewClass review);
        void UpdateReview(ReviewClass review);
        void DeleteReview(int id);
    }
}
