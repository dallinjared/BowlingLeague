using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BowlingLeague.Models
{
    public partial class BowlerScores
    {
        public long MatchId { get; set; }
        public long GameNumber { get; set; }
        public long BowlerId { get; set; }
        public long? RawScore { get; set; }
        public long? HandiCapScore { get; set; }
        public byte[] WonGame { get; set; }

        public virtual Bowlers Bowler { get; set; }
    }
}
