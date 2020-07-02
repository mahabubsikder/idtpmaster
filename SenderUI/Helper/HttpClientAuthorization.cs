using IDTPDataTransferObjects;
using SenderUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
/**
 * Description:This helper class is for getting JWT auth token 
 * 
 */
namespace SenderUI.Helper
{
    public static class HttpClientAuthorization
    {
       
        public async static Task<string> GetAuthorizationToken(LoginDTO loginDTO)
        {
            var client = new HttpClient();
            string uri = Constants.IDTPApiUrl + "GetAuthorizationToken";
            string token = await client.PostAsJsonAsync<LoginDTO>(uri, loginDTO).Result.Content.ReadAsStringAsync();
            client.Dispose();
            return token;
        }
    }
}
