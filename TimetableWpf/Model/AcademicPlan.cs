using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableWpf
{
    public class AcademicPlan
    {
        private string name;
        private List<Level> levels;

        public string Name { get { return name; } set { name = value; } }
        public List<Level> Levels { get { return levels; } set { levels = value; } }

        public AcademicPlan() { }

        public AcademicPlan(string name, List<Level> levels)
        {
            Name = name;
            Levels = levels;
        }
    }
}
