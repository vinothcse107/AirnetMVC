using AirnetMVC.DataService;
using AirnetMVC.Ui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirnetMVC.Ui.Controllers
{
    public class ReviewController : Controller
    {
        public ReviewRepository ReviewRepo;
        public static Guid CreatePlanId;
        public ReviewController()
        {
            ReviewRepo = new ReviewRepository();
        }
        public PartialViewResult AddReview(Guid PlanId)
        {
            CreatePlanId = PlanId;
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            review.Username = Session["username"].ToString();
            review.PlanId = CreatePlanId;
            ReviewRepo.AddReview(review);
            return RedirectToAction("ViewPrepaidPlans", "Client");
        }

        // GET: Review
        [ChildActionOnly]
        public ActionResult ReviewsPartialView(Guid Id)
        {
            var reviews = ReviewRepo.GetReviews(Id);
            ViewBag.PlanId = Id;
            return PartialView("/Views/Shared/PartialViews/ReviewsPartialView.cshtml", reviews);
        }

        public PartialViewResult EditReviewPartialView(string User, Guid Plan)
        {
            var review = ReviewRepo.GetReview(User,Plan);
            return PartialView(review);
        }
        [HttpPost]
        public ActionResult EditReviewPartialView(Review review)
        {
            ReviewRepo.EditReview(review);
            return RedirectToAction("ViewPrepaidPlans", "Client");
        }
        public ActionResult DeleteReview(string User, Guid Plan)
        {
            ReviewRepo.DeleteReview(User, Plan);
            return RedirectToAction("ViewPrepaidPlans", "Client");
        }
    }
}