using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsAndCollections.Classes
{
    class Person : FormatBase
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = "Unassigned";
            Age = 0;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("Name is {0}, age is {1}",Name, Age);
        }

    }
}
