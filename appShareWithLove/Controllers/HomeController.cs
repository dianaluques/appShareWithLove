using appShareWithLove.Models;
using appShareWithLove.Models.Data;
using appShareWithLove.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace appShareWithLove.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ShareWithLoveDbContext _context;

        public HomeController(ILogger<HomeController> logger, ShareWithLoveDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            var user5 = _context.Users;
            var proyectContext = _context.Publications.Include(p => p.IdUserNavigation);
            return View(new PubliComment(await _context.Publications.ToListAsync(), await _context.Comments.ToListAsync()));
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