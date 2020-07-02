using IDTP.Utility;
using IDTPApiService.Helper;
using IDTPBusinessLayer;
using IDTPDomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Xml;

namespace IDTPApiService.Controllers
{
    /**
    * Description:         The service is triggered automatically when a FCM message is received in the device for a definite app instance.
    * Invocation:          No need of invocation. Auto triggered when FCM message is received.
    * Implementation Flow:
    *                      a. Creates a new user from the provided XML data.
    */

    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IBusinessLayer _businessLayer = new BusinessLayer();
        public UsersController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }


        /// <summary>
        /// Creates a new user from the provided XML data
        /// </summary>
        /// <returns>Returns the Virtual Id of the user in a defined XML format</returns>
        /// <returns>Returns 200 OK success </returns>
        /// <returns>Returns 404 Not Found error</returns>
        /// <returns>Returns a defined XML error message on Internal Server Error </returns>
        [HttpPost("/RegisterUser", Name = "RegisterUser")]
        [Authorize(Roles = IDTPRoleNames.IDTPAdmin)]
        public string RegisterUser([FromBody] string xmlData)
        {
            string response;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);

                #region data fetched from xml
                string identityTypeIdString, entityTypeIdString, institutionIdString, accountNoString,
                    virtualIdString, identifyingId, secret;
                identityTypeIdString = doc.GetElementsByTagName("Identity").Item(0).Attributes["type"].Value;
                identifyingId = doc.GetElementsByTagName("Identity").Item(0).Attributes["id"].Value;
                entityTypeIdString = doc.GetElementsByTagName("Entity").Item(0).Attributes["type"].Value;
                institutionIdString = doc.GetElementsByTagName("InsitutionID").Item(0).Attributes["value"].Value;
                accountNoString = doc.GetElementsByTagName("AccountNo").Item(0).Attributes["value"].Value;
                virtualIdString = doc.GetElementsByTagName("RequestedVirtualID").Item(0).Attributes["value"].Value;
                secret = doc.GetElementsByTagName("Data").Item(0).InnerText;
                #endregion

                int deviceLocationInfoId = ParseDeviceLocationInfo.SaveInfo(doc);

                int identityTypeId = 0, entityTypeId = 0;

                identityTypeId = _businessLayer.GetAllIdentityTypes().Where(x => x.Type == identityTypeIdString).FirstOrDefault().Id;
                entityTypeId = _businessLayer.GetAllEntityTypes().Where(x => x.Type == entityTypeIdString).FirstOrDefault().Id;

                Cryptography.Services.IDTPCryptography cryptography = new Cryptography.Services.IDTPCryptography();
                IDTPUserEntity newUser = new IDTPUserEntity();
                string passSalt = cryptography.GetSecretSalt();
                newUser.SecretSalt = passSalt;
                newUser.Secret = cryptography.EncryptSecret(passSalt, secret);

                newUser.IdentityTypeId = identityTypeId;
                newUser.EntityTypeId = entityTypeId;
                newUser.AccountNo = accountNoString;
                newUser.VirtualId = virtualIdString;
                newUser.InstitutionId = institutionIdString;
                newUser.NidTinBin = identifyingId;
                newUser.EntityState = EntityState.Added;
                newUser.DeviceLocationInfoId = deviceLocationInfoId;
                _businessLayer.AddIDTPUserEntity(newUser);


                response = IDTPXmlParser.PrepareSuccessResponse("RegisterUserResponse", "VirtualID", virtualIdString);
                return response;
            }

            catch (WebException)
            {

                response = IDTPXmlParser.PrepareFailResponse("RegisterUserResponse");
                return response;
            }
        }
    }
}
