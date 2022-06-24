using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirnetMVC.DataService;
using AirnetMVC.Ui.Repository;

namespace AirnetMVC.Ui.Controllers
{
    //[Route("[controller")]
    public class RechargeController : Controller
    {
        public RechargeRepository rechargeRepository;
        public RechargeController()
        {
            rechargeRepository = new RechargeRepository();
        }
        // GET: Recharge
        [Route("GetAllRecharges")]
        public ActionResult ViewRecharges()
        {
            IEnumerable<Recharge> recharges = rechargeRepository.GetRecharges();
            return View(recharges);
        }
        public ActionResult AddRecharge()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRecharge(Recharge recharge)
        {
            rechargeRepository.AddRecharge(recharge);
            return RedirectToAction("ViewRecharges");
        }
        public ActionResult RechargeDetails(Guid id)
        {
            Recharge recharge = rechargeRepository.GetRechargeById(id);
            return View(recharge);
        }

        public ActionResult DeleteRecharge(Guid id)
        {
            Recharge recharge = rechargeRepository.GetRechargeById(id);
            rechargeRepository.DeleteRecharge(recharge);
            
            return RedirectToAction("ViewRecharges");
        }
        public ActionResult EditRecharge(Guid id)
        {
            Recharge recharge = rechargeRepository.GetRechargeById(id);
            return View(recharge);
        }
        [HttpPost]
        public ActionResult EditRecharge(Recharge recharge)
        {
            rechargeRepository.EditRecharge(recharge);
            return RedirectToAction("ViewRecharges");
        }
    }
}