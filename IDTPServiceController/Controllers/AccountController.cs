using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IDTPDataTransferObjects;
using IDTPDomainModel.Models;
using IDTPKeyVaultManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace IDTPServiceController.Controllers
{
    /**
   * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
   * Invocation:          No need of invocation. Auto triggered when FCM message is received.
   * Implementation Flow:
   *                      a. Get an authorization Token.
   */
    public class AccountController : ControllerBase
    {
        readonly SignInManager<ApplicationUser> signInManager;
        readonly UserManager<ApplicationUser> userManager;
        readonly IConfiguration configuration;

        public AccountController(
           SignInManager<ApplicationUser> signInManager,
           IConfiguration configuration, UserManager<ApplicationUser> userManager) {
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.userManager = userManager;
        }

        /// <summary>
        /// Retrieving an Authorization Token
        /// </summary>
        /// <returns>Returns an Authorization Token</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns 500 Internal Server Error </returns>
        [HttpPost("/GetAuthorizationToken", Name = "GetAuthorizationToken")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAuthorizationToken([FromBody] LoginDTO user) {
            try {
                ApplicationUser applicationUser = null;
                applicationUser = await userManager.FindByNameAsync(user.UserName).ConfigureAwait(false);
                string role;
                var roleList = await userManager.GetRolesAsync(applicationUser).ConfigureAwait(false);
                role = roleList.FirstOrDefault();

                if (applicationUser!=null) {                    
                    string tokenString = GetToken(applicationUser, role);
                    return Ok(tokenString);
                }
                else {
                    return BadRequest();
                }
            }
            catch (Exception ex) {

                return BadRequest(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Generates JWT token for a valid user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>The token string</returns>
        private String GetToken(ApplicationUser user, string role) {

            var utcNow = FormattableString.Invariant($"{DateTime.UtcNow}");
            var claims = new Claim[]
            {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, role)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            string encryptionKey = KeyVaultManagement.GetKey("TokenEncryptionKey");
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encryptionKey));

            //For local pc use this
            //var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<String>("Tokens:Key")));

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(5),
                audience: this.configuration.GetValue<String>("Tokens:Audience"),
                issuer: this.configuration.GetValue<String>("Tokens:Issuer")
                );

            return tokenHandler.WriteToken(jwt);
        }

    }
}