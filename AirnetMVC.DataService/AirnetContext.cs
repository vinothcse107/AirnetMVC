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
      
        private static IDictionary<string, string> envVars = DotEnv.Fluent()
            .WithExceptions()
            .WithEnvFiles()
            .WithTrimValues()
            .WithOverwriteExistingVars()
            .WithProbeForEnv(probeLevelsToSearch: 6)
            .Read();
        private static string con = envVars["CONNECTION_STRING"];
        public AirnetContext() : base(con) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Recharge> Recharges { get; set; }
        public DbSet<Review> Reviews { get; set; }

        
        // * Change the connection string to the ones in your System.
        // * Change the Class library to Console Application. Set the DataService as startup file to create the tables.
       /*
        public static void Main(string[] args)
        {
            using (var context = new AirnetContext())
            {
                context.Plans.Create();
                context.Users.Create();
                context.Recharges.Create();
                context.Reviews.Create();
                context.SaveChanges();
            }
        }
       */
        
    }



}
