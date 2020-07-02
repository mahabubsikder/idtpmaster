using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cryptography.Services;
using IDTPBusinessLayer;
using IDTPDataTransferObjects;
using IDTPDomainModel.Models;
using IDTPKeyVaultManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace IDTPApiService.Controllers
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
        private readonly IBusinessLayer _businessLayer;

        public AccountController(
           SignInManager<ApplicationUser> signInManager,
           IConfiguration configuration, UserManager<ApplicationUser> userManager, IBusinessLayer businessLayer) {
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.userManager = userManager;
            this._businessLayer = businessLayer;
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
        public async Task<ActionResult> GetAuthorizationToken([FromBody] LoginDTO loginDTO) {
            try {
                ApplicationUser applicationUser = null; string masterToken; MasterToken tokenObj;

                if (loginDTO !=null) {
                    applicationUser = await userManager.FindByNameAsync(loginDTO.UserName).ConfigureAwait(false);

                    if (applicationUser != null) {
                        string secrectSalt = applicationUser.SecretSalt;
                        IDTPCryptography cryptography = new IDTPCryptography();
                        masterToken = cryptography.EncryptSecret(secrectSalt, loginDTO.MasterToken);
                        tokenObj = _businessLayer.GetMasterTokenByTokenNo(masterToken);

                        if (tokenObj != null) {
                            ApplicationUser userInTokenTable= await userManager.FindByIdAsync(tokenObj.UserId).ConfigureAwait(false);

                            if (userInTokenTable.Id == applicationUser.Id && tokenObj.TokenExpiryDate>=DateTime.Today) {
                                string role;
                                var roleList = await userManager.GetRolesAsync(applicationUser).ConfigureAwait(false);
                                role = roleList.FirstOrDefault();

                                if (applicationUser != null) {
                                    string tokenString = GetToken(applicationUser, role);
                                    return Ok(tokenString);
                                }
                            }                            
                        }
                    }
                }

                return BadRequest();
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

            //Keyvault get key
            string encryptionKey = KeyVaultManagement.GetKey("TokenEncryptionKey");
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encryptionKey));


            //For Custom test use this
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