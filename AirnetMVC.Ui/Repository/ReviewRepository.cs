using AirnetMVC.DataService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirnetMVC.Ui.Repository
{
    public class ReviewRepository
    {
        public AirnetContext context;

        public ReviewRepository()
        {
            context = new AirnetContext();
        }

        public void AddReview(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
        }
        public void EditReview(Review review)
        {
            context.Entry(review).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteReview(Review review)
        {
            context.Reviews.Remove(review);
            context.SaveChanges();
        }

        public IEnumerable<Review> GetReviews(Guid PlanId)
        {
            var planReviews = context.Reviews.Where(review => review.PlanId == PlanId);
            return planReviews;
        }
        public Review GetReview(Guid ReviewId)
        {
            var planReviews = context.Reviews.Where(review => review.ReviewId == ReviewId).FirstOrDefault();
            return planReviews;
        }
        public double GetOverAllPlanRating(Guid PlanId)
        {
            var planReviews = context.Reviews.Where(review => review.PlanId == PlanId)
                        .Select(s => s.ReviewRating).Average();
            return planReviews;
        }

    }
}