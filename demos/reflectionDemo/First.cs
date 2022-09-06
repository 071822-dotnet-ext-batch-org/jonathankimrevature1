using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reflectionDemo
{
    public class First
    {
        public int Age {get; set; } = 43;
        public string Name { get; set; } = "blimey!";

        public First(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public int GetMyAge()
        {
            return this.Age;
        }

        public string GetMyName()
        {
            return this.Name;
        }

        private string GetMYNameAndAge()
        {
            return $"{this.Name}'s age is {this.Age}";
        }
    }
}