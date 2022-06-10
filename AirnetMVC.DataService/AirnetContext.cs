using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirnetMVC.DataService
{
    public class AirnetContext : DbContext
    {
        static string con = @"Data Source = VINOTH\SQLEXPRESS;Initial Catalog = AirnetRecharge; Integrated Security = True";
        public AirnetContext() : base(con) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Recharge> Recharges { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
