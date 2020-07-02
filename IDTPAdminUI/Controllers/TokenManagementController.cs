using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cryptography.Services;
using IDTPBusinessLayer;
using IDTPDomainModel;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IDTPAdminUI.Controllers
{
    public class TokenManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBusinessLayer _businessLayer;
        public TokenManagementController(IBusinessLayer businessLayer, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _businessLayer = businessLayer;
        }
        public IActionResult Index()
        {
            var tokenlist = _businessLayer.GetAllMasterTokens();

            ViewBag.tokenList = tokenlist;
            return View();
        }

        [HttpGet]
        public IActionResult Edit(string appId = null)
        {
            
            return View();
        }

        private async Task<ApplicationUser> GetCurrentUser() {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        [HttpPost] 
        [Authorize]
        public async Task<string> GetMasterToken(string appName)
        {
            string token= Guid.NewGuid().ToString();
            var currentUser = await GetCurrentUser();
            IDTPCryptography cryptography = new IDTPCryptography();
            string encryptedToken = cryptography.EncryptSecret(currentUser.SecretSalt, token);
            try {
                MasterToken masterToken = new MasterToken() {
                    AppName = appName,
                    Token = encryptedToken,
                    TokenExpiryDate = DateTime.Today.AddDays(30),
                    UserId= currentUser.Id,
                    EntityState = EntityState.Added
                };
                _businessLayer.AddMasterToken(masterToken);
                return token;
            }
            catch (Exception) {

                return token;
            }
        }


        [HttpPost]
        public IActionResult Create(string ClientToken)
        {
            //generate token somehow
            string Token = Guid.NewGuid().ToString();
            TempData["token"] = Token;
            return RedirectToAction("Index");
        }
    }
}