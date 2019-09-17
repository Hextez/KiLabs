using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Class;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private CalendarBase _calendar;

        public InterviewerController(CalendarBase calendar)
        {
            _calendar = calendar;
        }

        [HttpPost]
        public IActionResult AddInterviewer([FromBody] InterviewerData data)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try { 

                foreach (TimeOfInterview interview in data.TimeOfInterviews)
                {
                    if (_calendar.GetCalendar().ContainsKey(interview.WeekDay.ToLower()))
                    {
                        foreach (string hour in interview.Hours)
                        {
                            var ts = hour.Split("-");
                            if (ts.Length > 1 )
                            {
                                var start = Int32.Parse(ts[0]);
                                var end = Int32.Parse(ts[1]);
                                for (var i = start; i < end; i++)
                                {
                                    _calendar.GetCalendar()[interview.WeekDay.ToLower()][i + "-" + (i + 1)].AddInterview(data.Name);

                                }
                            }
                        }
                    }
                }

                return Ok(new { Result = "Added all hours you requested." });
            }catch (Exception ex)
            {
                return Ok(new { Result = ex.ToString() });
            }
        }
    }
}