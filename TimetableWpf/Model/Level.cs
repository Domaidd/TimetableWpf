using System.Collections.Generic;

namespace TimetableWpf
{
    public class Level
    {
        private bool selected;
        private string name;
        private List<Subject> subjects;
        private List<Classes> classes;

        public string Name { get { return name; } set { name = value; } }
        public List<Subject> Subjects { get { return subjects; } set { subjects = value; } }
        public List<Classes> Classes { get { return classes; } set { classes = value; } }
        public bool Selected { get { return selected; } set { selected = value; } }

        public Level() { }
        public Level(string name, List<Subject> subjects)
        {
            Name = name;
            Subjects = subjects;
        }
    }
}