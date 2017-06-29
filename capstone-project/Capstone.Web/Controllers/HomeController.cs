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

        public HomeController (IForecastDAL forcastDal, IParkDAL parkDal, ISurveyDAL surveyDal)
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
            ParkModel park = parkDal.GetPark(id);
            return View("ParkDetail", park);
        }

        public ActionResult Weather(string id)
        {
            List<ForecastModel> forecast = forcastDal.GetForecast(id);
            ParkModel park = parkDal.GetPark(id);
            WeatherViewModel weather = new WeatherViewModel()
            {
                Park = park,
                Forecast = forecast
            };

            return View("Weather", weather);
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
        public ActionResult Survey (SurveyViewModel completedSurvey)
        {
            surveyDal.SaveSurvey(completedSurvey);
            return RedirectToAction("FavoriteParks");
        }

        public ActionResult FavoriteParks ()
        {
            List<ParkModel> parks = parkDal.GetAllParks();
            List<ParkModel> parksWithSurveys = new List<ParkModel>(); 

            foreach (ParkModel p in parks)
            {
                if(surveyDal.SurveyCount(p.ParkCode) > 0 )
                {
                    parksWithSurveys.Add(p);
                }
            }
            return View("FavoriteParks", parksWithSurveys);
        }
   
}