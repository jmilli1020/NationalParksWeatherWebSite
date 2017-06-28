using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class SurveyViewModel
    {
        public SurveyModel Survey { get; set; }
        public ParkModel Park { get; set; }
    }
}