using AirnetMVC.DataService;
using AirnetMVC.Ui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirnetMVC.Ui.Controllers { 

    public class PlanController : Controller
    {
        // GET: Plans
        public PlansRepository plansRepository;
        public ReviewRepository reviewsRepository;
        public PlanController()
        {
            plansRepository = new PlansRepository();
            reviewsRepository = new ReviewRepository();
        }
        //[Route("GetAllPlans")]

        public ActionResult ViewPrepaidPlans()
        {
            IEnumerable<Plan> plans = plansRepository.GetPrepaidPlans();
            return View(plans);
        }
        public ActionResult ViewPostpaidPlans()
        {
            IEnumerable<Plan> plans = plansRepository.GetPostpaidPlans();
            return View(plans);
        }

        public ActionResult ViewAddonPlans()
        {
            IEnumerable<Plan> plans = plansRepository.GetAddonPlans();
            return View(plans);
        }


        public ActionResult CreatePlan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePlan(Plan plan)
        {
            plan.PlanId = Guid.NewGuid();
            plansRepository.AddPlan(plan);
            
            return RedirectToAction("View" + plan.PlanType + "Plans");
        }
        public ActionResult PlanDetails(Guid id)
        {
            Plan plan = plansRepository.GetPlanById(id);
            return View(plan);
        }
        public ActionResult DeletePlan(Guid id)
        {
            Plan plan = plansRepository.GetPlanById(id);
            plansRepository.DeletePlan(id);
            return RedirectToAction("View" + plan.PlanType + "Plans");
        }
        public ActionResult EditPlan(Guid id)
        {
            Plan plan = plansRepository.GetPlanById(id);
            return View(plan);
        }
        [HttpPost]
        public ActionResult EditPlan(Plan plan)
        {
            plansRepository.EditPlan(plan);
            return RedirectToAction("View"+plan.PlanType+"Plans");
        }

        

        
    }
}