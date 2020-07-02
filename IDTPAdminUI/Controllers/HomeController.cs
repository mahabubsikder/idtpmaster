using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IDTPAdminUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using IDTPDomainModel.Models;

namespace IDTPAdminUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(SignInManager<ApplicationUser> signInManager,
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        /// <summary>
        /// Shows the Index page according to the logged In User's role
        /// </summary>
        /// <returns></returns>
        [Authorize()]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Shows IDTP Dashboard only accessible from IDTPAdmin login.
        /// There are 8 charts in total including 4 bar charts and 4 pie charts.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult Dashboard()
        {
            return View();
        }
        /*
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
