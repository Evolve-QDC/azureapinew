using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureAPI.Models;

using System.Net.Http;
//using System.Net;
//using System.Text;
//using Newtonsoft.Json;

namespace AzureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AzurecallController : ControllerBase
    {
       
        private readonly ILogger<AzurecallController> _logger;
        
        public AzurecallController(ILogger<AzurecallController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<Azurecall> GetAzureCall( string Keyword)
        //{
        //    return null;
        //}


        //
        private const string key = "4AC5740B0EBB3D3E4D17AAED236C766F";
        [HttpGet]
        public async Task<HttpResponseMessage> GetAzureCall(string Keyword)
        {
            try
            {
                if (Keyword == null)
                    Keyword = "*";
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("api-key", key);
                    HttpResponseMessage response = await client.GetAsync("https://azureqscsearch.search.windows.net/indexes/evolveprivatesearch-index/docs?api-version=2021-04-30-Preview&searchMode=all&queryType=full&%24top=300&search=" + Keyword);

                    //if (response.IsSuccessStatusCode)
                    //{

                    //    //var ObjResponse = response.Content.ReadAsStringAsync().Result;
                    //    //StudentInfo = JsonConvert.DeserializeObject<List<Student>>(ObjResponse);
                    //}
                    //else
                    //{
                    //    //return "";
                    //}

                    return response;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //
    }
}
