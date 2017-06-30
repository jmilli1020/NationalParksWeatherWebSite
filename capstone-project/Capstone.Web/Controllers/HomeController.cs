using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        private IForecastDAL forcastDal;
        private IParkDAL parkDal;
        private ISurveyDAL surveyDal;

        public HomeController(IForecastDAL forcastDal, IParkDAL parkDal, ISurveyDAL surveyDal)
        {
            this.forcastDal = forcastDal;
            this.parkDal = parkDal;
            this.surveyDal = surveyDal;
        }

        // GET: Home
        public ActionResult ParkList()
        {
            List<ParkModel> parkList = parkDal.GetAllParks();
            return View("ParkList", parkList);
        }

        public ActionResult ParkDetail(string id)
        {
            List<ForecastModel> forecast = forcastDal.GetForecast(id);
            ParkModel park = parkDal.GetPark(id);
            WeatherViewModel weather = new WeatherViewModel()
            {
                Park = park,
                Forecast = forecast
            };
            return View("ParkDetail", weather);
        }

       public ActionResult ParkDetailC(string id, bool IsCelcius)
        {
            List<ForecastModel> forecast = forcastDal.GetForecast(id);
            ParkModel park = parkDal.GetPark(id);
            WeatherViewModel weather = new WeatherViewModel()
            {
                Park = park,
                Forecast = forecast,
                IsCelcius = IsCelcius
            };
            return View("ParkDetail", weather);
        }

        public ActionResult Survey(string id)
        {
            ParkModel park = parkDal.GetPark(id);
            SurveyViewModel surveyView = new SurveyViewModel()
            {
                Park = park,
            };
            return View("Survey", surveyView);
        }

        [HttpPost]
        public ActionResult Survey(SurveyViewModel completedSurvey)
        {
            surveyDal.SaveSurvey(completedSurvey);
            return RedirectToAction("FavoriteParks");
        }

        public ActionResult FavoriteParks()
        {
            List<ParkModel> parks = parkDal.GetAllParks();
            Dictionary<ParkModel, int> parksWithSurveys = new Dictionary<ParkModel, int>();

            foreach (ParkModel p in parks)
            {
                int count = surveyDal.SurveyCount(p.ParkCode);
                if (count > 0)
                {
                    parksWithSurveys[p] = count;
                }
            }
            return View("FavoriteParks", parksWithSurveys);
        }

      
    }
}