using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using IDTPKeyVaultManagement;


namespace IDTP.Utility
{
    public static class HttpClientHelper
    {
        public static string Post(System.Uri uri, string stringData,string token =null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    if(token!= null)
                    {
                        string bearerToken = token;
                        bearerToken = $"Bearer {bearerToken}";

                        //KeyVault
                        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", KeyVaultManagement.GetKey("ocpApimSubscriptionKey"));
                        client.DefaultRequestHeaders.Add("GatewayAuthorization", KeyVaultManagement.GetKey("gatewayAuthorization"));

                        //Local
                        //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constants.OcpApimSubscriptionKey);
                        //client.DefaultRequestHeaders.Add("GatewayAuthorization", Constants.GatewayAuthorization);

                        client.DefaultRequestHeaders.Add("Authorization", bearerToken);
                        
                    }
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    using (HttpResponseMessage response = client.PostAsJsonAsync(uri, stringData).Result)
                    {

                        response.EnsureSuccessStatusCode();
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                }
            }

            catch (WebException wex)
            {
                throw new WebException(wex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
