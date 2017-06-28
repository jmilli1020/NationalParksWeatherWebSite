using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class SurveyModel
    {
        public int SurveryId { get; set; }
        public string ParkCode { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string State { get; set; }

        public string Activity { get; set; }
    }
}