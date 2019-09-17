using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class InterviewerData
    {
        public string Name { get; set; }
        public List<TimeOfInterview> TimeOfInterviews { get; set; }
    }

    public class TimeOfInterview
    {
        public string WeekDay { get; set; }
        public List<string> Hours { get; set; }
    }
}
