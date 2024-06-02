using Celebration_Of_Capitalism___The_Finale.Models;
using Celebration_Of_Capitalism___The_Finale.Services;
using Celebration_Of_Capitalism___The_Finale.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Celebration_Of_Capitalism___The_Finale.Controllers
{
    public class COCReviewController : Controller
    {
        private readonly ICOCReviewService reviewService;
        private readonly ICOCProductService productService;

        public COCReviewController(COCReviewService reviewService, COCProductService productService)
        {
            this.reviewService = reviewService;
            this.productService = productService;
        }

        public IActionResult Index(int? id)
        {
            IEnumerable<COCReview> reviewsForProduct = reviewService.GetReviewsForProduct((int)id);
            COCProduct product = productService.GetProduct((int)id);
            return View(new Tuple<COCProduct, IEnumerable<COCReview>>(product, reviewsForProduct.ToList()));
        }

        public int AddReview(COCReview review)
        {
            return reviewService.AddReview(review);
        }

        public bool DeleteReview(int id)
        {
            return reviewService.DeleteReview(id);
        }

        public IEnumerable<COCReview> GetAllReviews()
        {
            return reviewService.GetAllReviews();
        }

        public COCReview? GetReview(int id)
        {
            return reviewService.GetReview(id);
        }

        public IEnumerable<COCReview> GetReviewsForProduct(int productId)
        {
            return reviewService.GetReviewsForProduct(productId);
        }

        public IEnumerable<COCReview> GetReviewsFromUser(int userId)
        {
            return reviewService.GetReviewsFromUser(userId);
        }

        public bool UpdateReview(int id, COCReview review)
        {
            return reviewService.UpdateReview(id, review);
        }
    }
}
