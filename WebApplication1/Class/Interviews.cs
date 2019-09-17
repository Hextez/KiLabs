using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Class
{
    public class Interviews
    {

        public List<string> Interviewers = new List<string>();
        public List<string> Cadidates = new List<string>();
        
        public Interviews() { }

        public void AddInterview(string name)
        {
            if (this.Interviewers.Contains(name))
                return;

            this.Interviewers.Add(name);
        }


        public void AddCadidate(string name)
        {
            if (this.Cadidates.Contains(name))
                return;
            this.Cadidates.Add(name);
        }
        

    }
}
