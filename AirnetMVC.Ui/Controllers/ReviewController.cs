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
        public ReviewController()
        {
            ReviewRepo = new ReviewRepository();
        }
        // GET: Review
        [ChildActionOnly]
        public ActionResult ReviewsPartialView(Guid Id)
        {
            var reviews = ReviewRepo.GetReviews(Id);
            return PartialView("/Views/Shared/PartialViews/ReviewsPartialView.cshtml", reviews);
        }
    }
}