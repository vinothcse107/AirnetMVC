using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirnetMVC.DataService
{
    public class Recharge
    {
        [Key]
        public Guid RechargeId { get; set; }
        [JsonIgnore]
        public Review Review { get; set; }
        // ----------------------------------------------
        [ForeignKey("User")]
        public string UserName { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        // ----------------------------------------------
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        // ----------------------------------------------
        [ForeignKey("Plans")]
        public Guid PlanId { get; set; }
        [JsonIgnore]
        public Plan Plans { get; set; }
        // ----------------------------------------------

    }
}
