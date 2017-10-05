using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace TimetableWpf
{
    public class Subject
    {
        private string name;

        private int hoursPerWeek;

        private int hoursPerDay;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int HoursPerWeek
        {
            get { return hoursPerWeek; }
            set { hoursPerWeek = value; }
        }

        public int HoursPerDay
        {
            get { return hoursPerDay; }
            set { hoursPerDay = value; }
        }

        public Subject() { }

        public Subject(string name, int hoursPerWeek, int hoursPerDay)
        {
            Name = name;
            HoursPerWeek = hoursPerDay;
            HoursPerDay = hoursPerWeek;
        }
    }
}