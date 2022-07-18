using BlogApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Xml.Linq;
using RestSharp;
using System.Text.Json;
using BusinessLayer.Concrete;
using DataAccessLayer.Repositories;

namespace BlogApp.Areas.Admin.ViewComponents.Statistics
{
    public class BaseStatistics : ViewComponent
    {
        string apiKey = "your_openweathermap_apikey";

        readonly AuthorManager authorManager = new AuthorManager(new AuthorRepository());
        readonly CommentManager commentManager = new CommentManager(new CommentRepository());
        readonly BlogManager blogManager = new BlogManager(new BlogRepository());
        readonly CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await getCurrentTempAsync();
            getAuthorCount();
            getBlogCount();
            getCommentCount();
            getCategoryCount();
            getCurrenctCurrency("USD");
            getCurrenctCurrency("EUR");
            return View();
        }

        private async Task getCurrentTempAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(newMediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("weather?q=Istanbul&lang=tr&units=metric&appid=" + apiKey);
                // TODO - Send HTTP requests

                if (response.IsSuccessStatusCode)
                {
                    WeatherResponse weatherResponse = await response.Content.ReadAsAsync<WeatherResponse>();
                    ViewBag.temp = weatherResponse.main.temp;
                }
            }
        }

        private void getCurrenctCurrency(string h)
        {
            var client = new RestClient("https://api.apilayer.com");

            var request = new RestRequest("/fixer/convert?to=TRY&from="+h+"&amount=1", Method.Get);
            request.AddHeader("apikey", "your_api_key");

            RestResponse response = client.Execute(request);
            CurrencyResponse currencyResponse = JsonSerializer.Deserialize<CurrencyResponse>(response.Content);
            if(h == "USD")
            {
                ViewBag.dollar = currencyResponse.result;
            }
            else if(h == "EUR")
            {
                ViewBag.Eur = currencyResponse.result; 
            }
        }

        private void getAuthorCount()
        {
            ViewBag.AuthorCount = authorManager.GetList().Count();
        }

        private void getBlogCount()
        {
            ViewBag.BlogCount = blogManager.GetList().Count();
        }

        private void getCommentCount()
        {
            ViewBag.CommentCount = commentManager.GetList().Count();
        }

        private void getCategoryCount()
        {
            ViewBag.CategoryCount = categoryManager.GetList().Count();
        }
    }
}