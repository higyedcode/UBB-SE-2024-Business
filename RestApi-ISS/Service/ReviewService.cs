// <copyright file="ReviewService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Backend.Models;
using Backend.Repositories;
using Iss.Services;

namespace Backend.Services
{
    public class ReviewService : IServiceReview
    {
        private static readonly ReviewService TheInstance = new ();
        private readonly ReviewRepository reviewRepository;

        private ReviewService()
        {
            this.reviewRepository = new ReviewRepository();
        }

        public ReviewService(ReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public static ReviewService Instance
        {
            get { return TheInstance; }
        }

        public List<ReviewClass> GetAllReviews()
        {
            return this.reviewRepository.GetReviewList();
        }

        public void AddReview(string user, string review)
        {
            ReviewClass reviewToAdd = new (user, review);
            this.reviewRepository.AddReview(reviewToAdd);
        }

        List<ReviewClass> IServiceReview.GetAllReviews()
        {
            return this.reviewRepository.GetReviewList();
        }

        public void DeleteReview(string user, string review)
        {
            ReviewClass reviewToDelete = this.reviewRepository.GetReviewByUserAndReview(user, review);
            if (reviewToDelete != null)
            {
                this.reviewRepository.DeleteReview(reviewToDelete);
            }
        }
    }
}
