using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDTPAdminUI.Models;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
/**
 * Description:         This controller class is responsible for user-role management.
 * 
 */
namespace IDTPAdminUI.Controllers
{
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<ApplicationUser> userManager;
        /// 
        /// Injecting Role Manager
        /// 
        /// 
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        /// <summary>
        /// Returns the list of all roles
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult Index()
        {
            var roleList = roleManager.Roles.ToList();
            return View(roleList);
        }

        /// <summary>
        /// Method to create a new role
        /// </summary>
        [Authorize(Roles = "IDTPAdmin")]
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        /// <summary>
        /// Method to show the view to assign users to roles
        /// </summary>
        [HttpGet]
        [Authorize(Roles ="IDTPAdmin")]
        public IActionResult UserRole()
        {
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();
            ViewBag.listUser = users;
            ViewBag.listRole = roles;
            return View();
        }

        /// <summary>
        /// POST method to assign selected role to a user
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "IDTPAdmin")]
        public async Task<IActionResult> UserRole([FromForm] UserRoleModel userRole)
        {
            var user = await userManager.FindByNameAsync(userRole.UserName);
            await userManager.AddToRoleAsync(user, userRole.RoleName);
            return RedirectToAction("UserRole", "Role");
        }
    }
}