using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace BlogApp.Areas.Admin.ViewComponents.Statistics
{
    public class BaseStatistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var apiKey = "0fcf7fb6e26915d6f9aeaaae7c79a7ec";
            var requestUrl = "https://api.openweathermap.org/data/2.5/weather?q=%C4%B0stanbul&mode=xml&lang=tr&units=metric&appid=" + apiKey;
            XDocument document = XDocument.Load(requestUrl);
            ViewBag.v1 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }

    }
}
