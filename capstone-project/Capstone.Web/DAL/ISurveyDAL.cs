using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {
        void SaveSurvey(SurveyViewModel survey);

        int SurveyCount(string parkCode);
    }
}
