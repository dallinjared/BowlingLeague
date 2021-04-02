using System;
using System.Linq;
using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlingLeague.Components
{
    public class BowlingTeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext _context;

        public BowlingTeamViewComponent(BowlingLeagueContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
