using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TlsClientDocker
{
    public static class Test
    {
        [FunctionName("Test")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function 'Test' received a request.");

            var responseMessage = "";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://mtlsdemo.nielski.com:8443");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try {
                    var response = await client.GetAsync("/");
                    if (response.IsSuccessStatusCode)
                    {
                        responseMessage = await response.Content.ReadAsStringAsync();
                        log.LogInformation(responseMessage);
                    }
                    else
                    {
                        log.LogError("FAIL:" + response.ReasonPhrase);
                    }
                } catch (Exception ex) {
                    log.LogError(ex.Message);
                    log.LogError(ex.StackTrace);
                    log.LogError(ex.InnerException.Message);
                    log.LogError(ex.InnerException.StackTrace);
                    return new StatusCodeResult(500);
                }
            }

            return new OkObjectResult(responseMessage);

        }
    }
}
