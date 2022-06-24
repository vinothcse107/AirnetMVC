using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirnetMVC.DataService;

namespace AirnetMVC.Ui.Repository
{
    public class RechargeRepository
    {
        public AirnetContext context;
        public RechargeRepository()
        {
            context = new AirnetContext();
        }
        public void AddRecharge(Recharge recharge)
        {
            context.Recharges.Add(recharge);
            context.SaveChanges();
        }
        public void EditRecharge(Recharge recharge)
        {
            context.Entry(recharge).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteRecharge(Recharge rechargeId)
        {
            context.Recharges.Remove(rechargeId);
            context.SaveChanges();
        }

        public Recharge GetRechargeById(Guid rechargeId)
        {
            Recharge recharge = context.Recharges.Find(rechargeId);
            return recharge;
        }

        public List<Recharge> GetRecharges()
        {
            return context.Recharges.ToList();
        }
    }
}