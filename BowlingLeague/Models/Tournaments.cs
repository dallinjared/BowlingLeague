using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BowlingLeague.Models
{
    public partial class Tournaments
    {
        public Tournaments()
        {
            TourneyMatches = new HashSet<TourneyMatches>();
        }

        public long TourneyId { get; set; }
        public byte[] TourneyDate { get; set; }
        public string TourneyLocation { get; set; }

        public virtual ICollection<TourneyMatches> TourneyMatches { get; set; }
    }
}
