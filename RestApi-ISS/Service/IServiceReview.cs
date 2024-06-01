using System.Collections.Generic;
using Backend.Models;

namespace Iss.Services
{
    public interface IServiceReview
    {
        List<ReviewClass> GetAllReviews();

        void AddReview(string user, string review);
    }
}
