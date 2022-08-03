using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inheritanceAndPolymorphism
{
    public class Corgi : Dogs
    {
        public Corgi()
        {
            this.Size = "Medium";
        }
        
        //Methods
        public override string dogBark()
        {
            return "A Corgi sounds like: woof woof";
        }

        public override string favoriteActivity()
        {
            return "A Corgi likes to eat all day";
        }

        public override string getCuteLevel()
        {
            return Convert.ToString(cuteLevel);
        }

        public string example()
        {
            return "exmaple";
        }

    }
}