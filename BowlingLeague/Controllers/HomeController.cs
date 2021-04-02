using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingLeague.Models;
using Microsoft.EntityFrameworkCore;
using BowlingLeague.Models.ViewModels;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context { get; set; }
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(long? TeamId, string TeamName, int PageNum = 1)
        {
            int PageSize = 5;
            ViewBag.TeamName = TeamName;
            return View(new IndexViewModel
            {
                Bowlers = _context.Bowlers
                .Where(m => m.TeamId == TeamId || TeamId == null)
                .OrderBy(m => m.BowlerFirstName)
                .Skip((PageNum-1) * PageSize)
                .Take(PageSize)
                .ToList(),
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = PageSize,
                    CurrentPage = PageNum,
                    //If no meal select, get full count, otherwise count number of team selected
                    TotalNumItems = (TeamId == null ? _context.Bowlers.Count() :
                        _context.Bowlers.Where(x => x.TeamId == TeamId).Count())
                },
                Team = TeamName
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
