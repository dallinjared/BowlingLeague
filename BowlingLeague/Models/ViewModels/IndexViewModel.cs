using System;
using System.Collections.Generic;

namespace BowlingLeague.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string Team { get; set; }
    }
}
