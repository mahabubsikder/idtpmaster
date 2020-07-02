using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using IDTPDomainModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using IDTPDomainModel;
using IDTPBusinessLayer;
using Cryptography.Services;

namespace IDTPAdminUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Display(Name = "User ID")]
            public string UserId { get; set; }
            #region Commondata

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }


            [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
            [Display(Name = "Contact Number")]
            public string ContactNo { get; set; }


            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 20)]
            [Display(Name = "NID")]
            public string NID { get; set; }


            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            #endregion

            [Required]
            public string UserType { get; set; }
            public string InstitutionType { get; set; }

            #region ContactPersonData
            [Display(Name = "Contact Person Name")]
            public string ContactPersonName { get; set; }

            [Display(Name = "Contact Person Designation")]
            public string ContactPersonDesignation { get; set; }

            [Display(Name = "Contact Person Office")]
            public string ContactPersonOffice { get; set; }

            [Display(Name = "Contact Person NID")]
            public string ContactPersonNID { get; set; }

            [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
            [Display(Name = "Contact Number")]
            public string ContactPersonMobile { get; set; }

            [Display(Name = "Contact Person Email")]
            [EmailAddress]
            public string ContactPersonEmail { get; set; }
            #endregion

            #region BusinessInfo
            [Display(Name = "Business ID")]
            public string BusinessId { get; set; }
            public string BusinessTIN { get; set; }
            public string BusinessBIN { get; set; }
            public string BusinessBankName { get; set; }
            public string BusinessBranchName { get; set; }
            public string BusinessAccountNumber { get; set; }

            public string BusinessName { get; set; }
            public string BusinessVatId { get; set; }


            [EmailAddress]
            [Display(Name = "Email")]
            public string BusinessEmail { get; set; }


            [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
            [Display(Name = "Contact Number")]
            public string BusinessContactNo { get; set; }


            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 20)]
            [Display(Name = "NID")]
            public string BusinessNID { get; set; }

            #endregion

            #region FinancialInstituteInfo

            [Display(Name = "Institution Name")]
            public string FinancialInstitutionName { get; set; }
            [Display(Name = "FinancialInstitute ID")]
            public string FinancialId { get; set; }
            public string FinancialTIN { get; set; }
            public string FinancialBIN { get; set; }
            public string FinancialBankName { get; set; }
            public string FinancialBranchName { get; set; }
            public string FinancialAccountNumber { get; set; }
            public string FinancialVatId { get; set; }
            public string FinancialSwiftCode { get; set; }
            public string InstitutionLicenseNumber { get; set; }
            public string FinancialVirtualID { get; set; }
            [EmailAddress]
            [Display(Name = "Email")]
            public string FinancialEmail { get; set; }

            [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
            [Display(Name = "Contact Number")]
            public string FinancialContactNo { get; set; }
            #endregion

            #region GovtInstituteInfo
            [Display(Name = "Institution Name")]
            public string GovtInstitutionName { get; set; }
            [Display(Name = "Address")]
            public string Address { get; set; }
            public string GovtId { get; set; }
            public string GovtTIN { get; set; }
            public string GovtBIN { get; set; }
            [EmailAddress]
            [Display(Name = "Email")]
            public string GovtEmail { get; set; }
            [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
            [Display(Name = "Contact Number")]
            public string GovtContactNo { get; set; }
            public string GovtBankName { get; set; }
            public string GovtBranchName { get; set; }
            public string GovtAccountNumber { get; set; }
            public string GovtVID { get; set; }

            #endregion
            #region Address
            public string AddressLine { get; set; }
            public string District { get; set; }
            public string PostalCode { get; set; }

            #endregion
        }

        public async Task<IActionResult> OnGetAsync(string userType, string returnUrl = null)
        {
            if (userType != null)
            {
                ReturnUrl = returnUrl;
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
                TempData["form"] = userType;
                return Page();
            }
            else
            {
                return Content("ERROR");
            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            BusinessLayer businessLayer = new BusinessLayer();
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {

                //returnUrl = returnUrl ?? Url.Content("~/");
                returnUrl = returnUrl ?? Url.Content("~/Users/Index?userType="+Input.UserType);


                IDTPCryptography cryptography = new IDTPCryptography();
                
                //Getting password salt to encrypt
                string passSalt = cryptography.GetSecretSalt();
                
                var user = new ApplicationUser();
                switch (Input.UserType)
                {
                    case "Admin":
                        {
                            user = new ApplicationUser { UserName = Input.UserId, Email = Input.Email, SecretSalt = passSalt };
                            var result = await _userManager.CreateAsync(user, Input.Password);
                            if (result.Succeeded)
                            {
                                IDTPUserAdmin newUser = new IDTPUserAdmin
                                {
                                    Id= user.Id,
                                    FirstName = Input.FirstName,
                                    LastName = Input.LastName,
                                    ContactNo = Input.ContactNo,
                                    Email = Input.Email,
                                    LoginId = Input.UserId,
                                    NID = Input.NID,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now,
                                    EntityState = EntityState.Added
                                };
                                businessLayer.AddUser(newUser);
                                await _userManager.AddToRoleAsync(user, "IDTPAdmin");
                            }
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            if (!ModelState.IsValid)
                            {
                                TempData["form"] = Input.UserType;
                                return Page();
                            }
                            else
                            {
                                //await _signInManager.SignInAsync(user, isPersistent: false);
                                return LocalRedirect(returnUrl);
                            }


                        }
                    case "Business":
                        {
                            user = new ApplicationUser { UserName = Input.BusinessId, Email = Input.BusinessEmail, SecretSalt = passSalt};
                            var result = await _userManager.CreateAsync(user, Input.Password);
                            if (result.Succeeded)
                            {
                                Business newUser = new Business
                                {
                                    Id = user.Id,
                                    FullName = Input.BusinessName,
                                    ContactNo = Input.BusinessContactNo,
                                    Email = Input.BusinessEmail,
                                    LoginId = Input.BusinessId,
                                    NID = Input.BusinessNID,
                                    TIN = Input.BusinessTIN,
                                    BIN = Input.BusinessBIN,
                                    BankName = Input.BusinessBankName,
                                    BranchName = Input.BusinessBranchName,
                                    AccountNumber = Input.BusinessAccountNumber,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now,
                                    EntityState = EntityState.Added
                                };
                                businessLayer.AddMerchant(newUser);
                                await _userManager.AddToRoleAsync(user, "Business");

                            }
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            if (!ModelState.IsValid)
                            {
                                TempData["form"] = Input.UserType;
                                return Page();
                            }
                            else
                            {
                                //await _signInManager.SignInAsync(user, isPersistent: false);
                                return LocalRedirect(returnUrl);
                            }

                        }
                    case "GovtInstitute":
                        {
                            user = new ApplicationUser { UserName = Input.GovtId, Email = Input.GovtEmail,SecretSalt = passSalt };
                            var result = await _userManager.CreateAsync(user, Input.Password);
                            if (result.Succeeded)
                            {
                                GovernmentInstitution newGovtInstitutionInfo = new GovernmentInstitution
                                {
                                    LoginId = Input.GovtId,
                                    Name = Input.GovtInstitutionName,
                                    BIN = Input.GovtBIN,
                                    Email = Input.GovtEmail,
                                    ContactNo = Input.GovtContactNo,
                                    Address = Input.Address,
                                    BankName = Input.GovtBankName,
                                    BranchName = Input.GovtBranchName,
                                    AccountNumber = Input.GovtAccountNumber,
                                    ContactPersonName = Input.ContactPersonName,
                                    ContactPersonDesignation = Input.ContactPersonDesignation,
                                    ContactPersonEmail = Input.ContactPersonEmail,
                                    ContactPersonMobile = Input.ContactPersonMobile,
                                    ContactPersonNID = Input.ContactPersonNID,
                                    ContactPersonOffice = Input.ContactPersonOffice,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now,
                                    EntityState = EntityState.Added
                                };
                                businessLayer.AddGovtInstitutionInfo(newGovtInstitutionInfo);
                                await _userManager.AddToRoleAsync(user, "GovernmentInstitute");
                            }
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            if (!ModelState.IsValid)
                            {
                                TempData["form"] = Input.UserType;
                                return Page();
                            }
                            else
                            {
                                //await _signInManager.SignInAsync(user, isPersistent: false);
                                return LocalRedirect(returnUrl);
                            }

                        }
                    case "FinInstitute":
                        {
                            user = new ApplicationUser { UserName = Input.FinancialId, Email = Input.FinancialEmail , SecretSalt = passSalt };
                            var result = await _userManager.CreateAsync(user, Input.Password);
                            if (result.Succeeded)
                            {
                                FinancialInstitution newFinInstitutionInfo = new FinancialInstitution
                                {
                                    Id = user.Id,
                                    LoginId = Input.FinancialId,
                                    InstitutionName = Input.FinancialInstitutionName,
                                    TIN = Input.FinancialTIN,
                                    BIN = Input.FinancialBIN,
                                    Email = Input.FinancialEmail,
                                    ContactNo = Input.FinancialContactNo,
                                    SwiftCode = Input.FinancialSwiftCode,
                                    VatId = Input.FinancialVatId,
                                    ContactPersonName = Input.ContactPersonName,
                                    ContactPersonDesignation = Input.ContactPersonDesignation,
                                    ContactPersonEmail = Input.ContactPersonEmail,
                                    ContactPersonMobile = Input.ContactPersonMobile,
                                    ContactPersonNID = Input.ContactPersonNID,
                                    ContactPersonOffice = Input.ContactPersonOffice,
                                    CreatedOn = DateTime.Now,
                                    ModifiedOn = DateTime.Now,
                                    EntityState = EntityState.Added
                                };
                                businessLayer.AddFinInstitutionInfo(newFinInstitutionInfo);
                                await _userManager.AddToRoleAsync(user, "FinancialInstitute");
                            }
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                            if (!ModelState.IsValid)
                            {
                                TempData["form"] = Input.UserType;
                                return Page();
                            }
                            else
                            {
                                //await _signInManager.SignInAsync(user, isPersistent: false);
                                return LocalRedirect(returnUrl);
                            }

                        }

                }

            }

            // If we got this far, something failed, redisplay form
            TempData["form"] = Input.UserType;
            return Page();

        }
        public async Task<IActionResult> AfterRegistration(ApplicationUser user, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            _logger.LogInformation("User created a new account with password.");
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
            }
            else
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }
        }
    }
}
