using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableWpf
{
    public class Call
    {
        private string time;
        private string day;
        private bool isActivate;
        private Subject subject;

        public string Time { get { return time; } set { time = value; } }
        public string Day { get { return day; } set { day = value; } }
        public bool IsActivate { get { return isActivate; } set { isActivate = value; } }
        public Subject Subject { get { return subject; } set { subject = value; } }

        public Call() { }

        public Call(string time, string day, bool isActivate)
        {
            Time = time;
            Day = day;
            IsActivate = isActivate;
        }

        public Call(string time, string day, bool isActivate, Subject subject) : this (time, day, isActivate)
        {
            Subject = subject;
        }
    }
}
