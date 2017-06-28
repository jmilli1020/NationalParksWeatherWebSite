using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class ParkModel
    {
        public int ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int ElevationInFeet { get; set; }
        public double MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVistorCont { get; set; }
        public string InspirationQuote { get; set; }
        public string InspirationQuoteSource { get; set; }
        public string ParkDesctiption { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
    }
}