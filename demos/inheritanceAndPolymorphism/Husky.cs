using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inheritanceAndPolymorphism
{
    public class Husky : Dogs
    {
        public Husky()
        {
            this.Size = "Large";
        }

        //Methods
        public override string dogBark()
        {
            return "A Husky sounds like: WAAAAHHH";
        }

        public override string favoriteActivity()
        {
            return "A Husky likes to make big messes";
        }
        
        public override string getCuteLevel()
        {
            return Convert.ToString(cuteLevel);
        }

    }
}