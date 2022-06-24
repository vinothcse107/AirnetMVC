using dotenv.net;
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
        /*
          private static IDictionary<string, string> envVars = DotEnv.Fluent()
              .WithExceptions()
              .WithEnvFiles()
              .WithTrimValues()
              .WithOverwriteExistingVars()
              .WithProbeForEnv(probeLevelsToSearch: 6)
              .Read();
          private static string con = envVars["CONNECTION_STRING"];*/
        static string con = @"Data Source =VIDHYAMINI\SQLEXPRESS ;Initial Catalog = AirnetRecharge; Integrated Security = True";
          public AirnetContext() : base(con) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Recharge> Recharges { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasKey(r => new { r.Username, r.PlanId });
        }
    }
}
