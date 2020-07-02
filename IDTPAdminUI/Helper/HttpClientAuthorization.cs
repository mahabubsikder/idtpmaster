using IDTPDataTransferObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IDTPAdminUI.Helper
{
    public static class HttpClientAuthorization
    {
        public static HttpClient AuthorizeClient(HttpClient client)
        {
            if(client!= null)
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "315b8a740b3d41c2b53111500771e369");
                client.DefaultRequestHeaders.Add("Authorization", "3eO84YBUWElWBZnWvvxNnkpyKB7BNkyK");
                return client;
            }
            else
            {
                return null;
            }

        }
        public static HttpWebRequest AuthorizeRequest(HttpWebRequest request)
        {
            if (request != null)
            {
                request.Headers.Add("Ocp-Apim-Subscription-Key", "315b8a740b3d41c2b53111500771e369");
                request.Headers.Add("Authorization", "3eO84YBUWElWBZnWvvxNnkpyKB7BNkyK");

                return request;
            }
            else
            {
                return null;
            }

        }

        public static HttpClient AddAuthorizationToken(HttpClient client, string token) {

            string bearerToken = token;
            bearerToken = $"Bearer {bearerToken}";

            if (client != null) {
                client.DefaultRequestHeaders.Add("Authorization", bearerToken);
                return client;
            }
            else {
                return null;
            }

        }

        public async static Task<string> GetAuthorizationToken(LoginDTO loginDTO) {

            var client = new HttpClient();
            string uri = Constants.apiGatewayurlSendMoney + "GetAuthorizationToken";
            string token = await client.PostAsJsonAsync<LoginDTO>(uri, loginDTO).Result.Content.ReadAsStringAsync();
            return token;
        }
    }
}
