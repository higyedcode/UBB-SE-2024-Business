using Backend.Models;

namespace Backend.Repositories
{
    internal interface INterfaceReview<T>
    {
        public List<ReviewClass> GetReviewList();

        public void AddReview(ReviewClass newR);
    }
}
