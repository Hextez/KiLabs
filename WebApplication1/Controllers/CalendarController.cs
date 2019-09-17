using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {

        private CalendarBase _calendar;

        public CalendarController(CalendarBase calendar)
        {
            _calendar = calendar;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_calendar.GetCalendar());
        }

        // GET api/values/5
        [HttpPost("[action]")]
        public ActionResult GetFromMany([FromBody] QueryList query)
        {
            IDictionary<string, List<string>> cal = new Dictionary<string, List<string>>();
            var calendar = _calendar.GetCalendar();
            foreach (string week in calendar.Keys)
            {
                foreach (string hour in calendar[week].Keys)
                {
                    var cadidate = calendar[week][hour].Cadidates.Exists(d => d == query.Cadidate);
                    if (cadidate)
                    {
                        var existInterviewers = true;
                        foreach(string name in query.Interviewers)
                        {
                            var interviewer = calendar[week][hour].Interviewers.Exists(d => d == name);
                            if (!interviewer) {
                                existInterviewers = false;
                                break;
                            }

                        }
                        if (existInterviewers)
                        {
                            if (cal.ContainsKey(week))
                            {
                                cal[week].Add(hour);
                            }
                            else
                            {
                                cal.Add(week, new List<string>());
                                cal[week].Add(hour);
                            }
                        }

                    }

                }

            }
            return Ok(cal);
        }
        [HttpPost("[action]")]
        public ActionResult GetFromOne([FromBody] QuerySingle query)
        {
            IDictionary<string, List<string>> cal = new Dictionary<string, List<string>>();
            var calendar = _calendar.GetCalendar();
            foreach (string week in calendar.Keys)
            {
                foreach (string hour in calendar[week].Keys)
                {
                    var cadidate = calendar[week][hour].Cadidates.Exists(d => d == query.Cadidate);
                    var interviewer = calendar[week][hour].Interviewers.Exists(d => d == query.Interviewer);
                    if (cadidate && interviewer)
                    {
                        if (cal.ContainsKey(week))
                        {
                            cal[week].Add(hour);
                        }
                        else
                        {
                            cal.Add(week, new List<string>());
                            cal[week].Add(hour);
                        }
                    }

                }

            }
            return Ok(cal);
        }

    }
}
