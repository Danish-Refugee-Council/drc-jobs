using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;

namespace drcjobs.Core.Recruiter
{
    public class RecruiterClient
    {
        public static async Task<T> Request<T>(string path) where T : class
        {
            var responseString = "";
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                    response = await client.GetAsync(ConfigurationManager.AppSettings["RecruiterApiUrl"] + path);

                    if (response.IsSuccessStatusCode)
                    {
                        responseString = await response.Content.ReadAsStringAsync();
                        Current.Logger.Info<RecruiterClient>($"CACHED:{path}-{DateTime.UtcNow}");
                    }
                }
                catch (Exception ex)
                {
                    Current.Logger.Error<RecruiterClient>(ex, $"URL:{path}-{DateTime.UtcNow}");
                }
            }
            try
            {
                return responseString == "" ? null : JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception e)
            {
                Current.Logger.Error<RecruiterClient>(e, $"DeserializeObject Error:{path}-{DateTime.UtcNow}");
                return null;
            }
        }
    }
}
