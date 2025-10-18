using System.Diagnostics;
using CMCS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMCS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                if (await _userManager.IsInRoleAsync(user!, "Admin"))
                {
                    return RedirectToAction("Index", "AdminDashboard");
                }
                else if (await _userManager.IsInRoleAsync(user!, "ProgramCoordinator"))
                {
                    return RedirectToAction("Index", "CoordinatorApp");
                }
                else if (await _userManager.IsInRoleAsync(user!, "Lecturer"))
                {
                    return RedirectToAction("Index", "LecturerApp");
                }
            }

            ViewData["IsHomePage"] = true;
            return View();
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