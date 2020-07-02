using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using IDTPBusinessLayer;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IDTPAdminUI.Controllers
{
    public class UsersController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<ApplicationUser> userManager;
        private readonly IBusinessLayer _businessLayer;
        /// 
        /// Injecting Role Manager
        /// 
        /// 
        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IBusinessLayer businessLayer)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _businessLayer = businessLayer;
        }
        [Authorize(Roles ="IDTPAdmin")]
        public IActionResult Index(string userType=null)
        {
            var identityUsers = userManager.Users.ToList();
            var idtpuseradminList = _businessLayer.GetAllUsers().ToList();
            var merchantList = _businessLayer.GetAllMerchants().ToList();
            var adminList =new List<IDTPUserAdmin>();
            var businessList = new List<Business>();
            foreach (var user in identityUsers)
            {
                foreach(var idtpUser in idtpuseradminList)
                {
                    if(idtpUser.LoginId == user.UserName)
                    {
                        adminList.Add(idtpUser);
                    }
                }
            }
            foreach (var user in identityUsers)
            {
                foreach (var idtpUser in merchantList)
                {
                    if (idtpUser.LoginId == user.UserName)
                    {
                        businessList.Add(idtpUser);
                    }
                }
            }
            var govtList = _businessLayer.GetAllGovtInstitutionInfos().ToList();
            
            var financialInstituteList = _businessLayer.GetAllFinInstitutionInfos().ToList();
            ViewBag.adminList = adminList;
            ViewBag.govtList = govtList;
            ViewBag.businessList = businessList;
            ViewBag.financialInstituteList = financialInstituteList;
            if(userType!= null)
            {
                TempData["form"] = userType;
            }
            return View();
        }

        [Authorize(Roles = "IDTPAdmin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id, string type)
        {
            switch (type)
            {
                //case "Admin":
                //    {
                //        var admin = _businessLayer.GetUserById(id);
                //        var aspAdmin = await userManager.FindByNameAsync(admin.LoginId);
                //        await userManager.DeleteAsync(aspAdmin);
                //        admin.EntityState = EntityState.Deleted;
                //        _businessLayer.RemoveUser(admin);
                //        break;
                //    }
                //case "Business":
                //    {
                //        var business = _businessLayer.GetMerchantById(id);
                //        var aspUser = await userManager.FindByNameAsync(business.LoginId);
                //        await userManager.DeleteAsync(aspUser);
                //        business.EntityState = EntityState.Deleted;
                //        _businessLayer.RemoveMerchant(business);
                //        break;
                //    }
                //case "GovtInstitute":
                //    {
                //        var govtInstiute = _businessLayer.GetGovtInstitutionInfoById(id);
                //        var aspUser = await userManager.FindByNameAsync(govtInstiute.LoginId);
                //        await userManager.DeleteAsync(aspUser);
                //        govtInstiute.EntityState = EntityState.Deleted;
                //        _businessLayer.RemoveGovtInstitutionInfo(govtInstiute);
                //        break;
                //    }
                //case "FinInstitute":
                //    {
                //        var finInstitute = _businessLayer.GetFinInstitutionInfoById(id);
                //        var aspAdmin = await userManager.FindByNameAsync(finInstitute.LoginId);
                //        await userManager.DeleteAsync(aspAdmin);
                //        finInstitute.EntityState = EntityState.Deleted;
                //        _businessLayer.RemoveFinInstitutionInfo(finInstitute);
                //        break;
                //    }

            }
            return RedirectToAction("Index", new { userType = type});
        }
    }
}