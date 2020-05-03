using System;

namespace GradeBook
{
    public class NamedObject : Object
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get; set;
        }
    }
}