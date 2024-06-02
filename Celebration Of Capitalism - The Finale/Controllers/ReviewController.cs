using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Celebration_Of_Capitalism___The_Finale.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IProductService productService;

        public ReviewController(ReviewService reviewService, ProductService productService)
        {
            this.reviewService = reviewService;
            this.productService = productService;
        }

        public IActionResult Index(int? id)
        {
            IEnumerable<Review> reviewsForProduct = reviewService.GetReviewsForProduct((int)id);
            Product product = productService.GetProduct((int)id);
            return View(new Tuple<Product, IEnumerable<Review>>(product, reviewsForProduct.ToList()));
        }

        public int AddReview(Review review)
        {
            return reviewService.AddReview(review);
        }

        public bool DeleteReview(int id)
        {
            return reviewService.DeleteReview(id);
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return reviewService.GetAllReviews();
        }

        public Review? GetReview(int id)
        {
            return reviewService.GetReview(id);
        }

        public IEnumerable<Review> GetReviewsForProduct(int productId)
        {
            return reviewService.GetReviewsForProduct(productId);
        }

        public IEnumerable<Review> GetReviewsFromUser(int userId)
        {
            return reviewService.GetReviewsFromUser(userId);
        }

        public bool UpdateReview(int id, Review review)
        {
            return reviewService.UpdateReview(id, review);
        }
    }
}
