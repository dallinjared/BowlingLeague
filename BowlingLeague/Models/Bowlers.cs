using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BowlingLeague.Models
{
    public partial class Bowlers
    {
        public Bowlers()
        {
            BowlerScores = new HashSet<BowlerScores>();
        }

        public long BowlerId { get; set; }
        public string BowlerLastName { get; set; }
        public string BowlerFirstName { get; set; }
        public string BowlerMiddleInit { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }
        public string BowlerState { get; set; }
        public string BowlerZip { get; set; }
        public string BowlerPhoneNumber { get; set; }
        public long? TeamId { get; set; }

        public virtual Teams Team { get; set; }
        public virtual ICollection<BowlerScores> BowlerScores { get; set; }
    }
}
