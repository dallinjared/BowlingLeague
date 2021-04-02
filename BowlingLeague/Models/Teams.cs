using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BowlingLeague.Models
{
    public partial class Teams
    {
        public Teams()
        {
            Bowlers = new HashSet<Bowlers>();
            TourneyMatchesEvenLaneTeam = new HashSet<TourneyMatches>();
            TourneyMatchesOddLaneTeam = new HashSet<TourneyMatches>();
        }

        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public long? CaptainId { get; set; }

        public virtual ICollection<Bowlers> Bowlers { get; set; }
        public virtual ICollection<TourneyMatches> TourneyMatchesEvenLaneTeam { get; set; }
        public virtual ICollection<TourneyMatches> TourneyMatchesOddLaneTeam { get; set; }
    }
}
