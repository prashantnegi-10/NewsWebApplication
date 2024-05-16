using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsWebTest.NewsModels;
using Newtonsoft.Json;

namespace NewsWebTest.Controllers
{
    public class NewsController : Controller
    {
        private readonly string ApiKey = "4239b8e1d3e64981b51352e9a6919263";
        private readonly HttpClient _client = new();

        public ActionResult Index()
        {
            return View();
        }

        /*[HttpGet]
        public ActionResult CallApi()
        {
            return View();
        }*/

        [HttpPost]
        public async Task<ActionResult> CallApi(string? keyword = "India")
        {

            string apiUrl = $"https://newsapi.org/v2/everything?q={Uri.EscapeDataString(keyword)}";


            _client.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/0.1");
          //  H.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("x-api-key", ApiKey);

            HttpResponseMessage response = await _client.GetAsync(apiUrl);
           
            if (response.IsSuccessStatusCode)
            {
                var jsonContent =  response.Content.ReadAsStringAsync().Result ;
                var newsApiResponse = JsonConvert.DeserializeObject<NewsApiResponse>(jsonContent);
                //newsApiResponse.Articles? = new List<Article>();
                ViewBag.Keyword = keyword;

                return View("ApiDataView", newsApiResponse);
            }
            else
                return View("ErrorView");
        }
    }
}