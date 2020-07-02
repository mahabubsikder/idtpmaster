using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IDTPAdminUI.Helper
{
    public static class HttpClientHelper<T> where T : class
    {
        public static List<T> GetAll(Uri uri)
        {
            List<T> result = null;
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "315b8a740b3d41c2b53111500771e369");
                client.DefaultRequestHeaders.Add("Authorization", "3eO84YBUWElWBZnWvvxNnkpyKB7BNkyK");
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                using HttpResponseMessage response = client.GetAsync(uri).Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsAsync<List<T>>().Result;
                return result;
            }
            catch(WebException)
            {
                return result;
            }

            
        }
    }
}
