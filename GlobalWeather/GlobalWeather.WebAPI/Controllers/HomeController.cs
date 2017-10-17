using GlobalWeather.Domain.Models.Weather;
using GlobalWeather.WebAPI.Models;
using System.Net.Http;
using System.Web.Mvc;

namespace GlobalWeather.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult UpdateCurrentWeatherView(string cityName, string countryName)
        {
            var client = new HttpClient();
            var response = client.GetAsync(string.Format("{0}://{1}/api/weather/getcurrentweather/{2}/{3}", HttpContext.Request.Url.Scheme, HttpContext.Request.Url.Authority, cityName.Replace(".",""), countryName.Replace(".", ""))).Result;

            if (response.IsSuccessStatusCode)
            {
                var currentWeather = response.Content.ReadAsAsync<CurrentWeatherResponse>().Result;
                var model = new CurrentWeatherViewModel();
                model.Weather = currentWeather;
                return PartialView("_CurrentWeather", model);
            }
            else
            {
                return null;
            }
        }
    }
}
