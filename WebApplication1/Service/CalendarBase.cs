using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Class;

namespace WebApplication1.Service
{
    public class CalendarBase
    {

        private IDictionary<string, Dictionary<string, Interviews>> calendar = new Dictionary<string, Dictionary<string, Interviews>>();

        public CalendarBase()
        {
            DateTime dt1 = new DateTime(2018, 09, 13, 00, 00, 00);
            DateTime dt2 = new DateTime(2018, 09, 14, 00, 00, 00);
            TimeSpan ts = dt2 - dt1;

            List<int> hoursBetween = Enumerable.Range(0, (int)ts.TotalHours)
                .Select(i => dt1.AddHours(i).Hour).ToList();
            foreach (DayOfWeek weekname in (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek)))
            {
                if (weekname.ToString() != "Sunday" && weekname.ToString() != "Saturday") { 
                    calendar.Add(weekname.ToString().ToLower(), new Dictionary<string, Interviews>());
                    for(var i = 0; i < hoursBetween.Count()-1; i++)
                    {
                        calendar[weekname.ToString().ToLower()].Add(hoursBetween[i]+"-"+ hoursBetween[i+1], new Interviews());

                    }
                 }
            }
        }

        public IDictionary<string, Dictionary<string, Interviews>> GetCalendar()
        {
            return calendar;
        }

       
    }
}
