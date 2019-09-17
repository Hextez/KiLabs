using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Query
    {
        public string Cadidate { get; set; }


    }

    public class QueryList : Query
    {
        public List<string> Interviewers { get; set; }
    }

    public class QuerySingle : Query
    {
        public string Interviewer { get; set; }
    }
}