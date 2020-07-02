using IDTPDataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GovtBillingSystemUI.Helper
{
    public static class HttpClientAuthorization
    {
        public async static Task<string> GetAuthorizationToken(LoginDTO loginDTO)
        {
            HttpClient client = new HttpClient();
            string uri = Constants.IDTPApiUrl + "GetAuthorizationToken";
            string token = await client.PostAsJsonAsync<LoginDTO>(uri, loginDTO).Result.Content.ReadAsStringAsync();
            client.Dispose();
            return token;
        }
    }
}
