using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IDTPDescoDemoUI.Helper
{
    public class HttpClientHelper<T> where T : class
    {
        public List<T> GetAll(Uri uri)
        {
            List<T> result = null;
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                using HttpResponseMessage response = client.GetAsync(uri).Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsAsync<List<T>>().Result;
                return result;
            }

            catch (WebException)
            {
                return result;
            }
        }
    }
}
