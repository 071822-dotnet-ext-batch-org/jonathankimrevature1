using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inheritanceAndPolymorphism
{
    public class Dogs
    {
        // All derived classes carry this data by default
        public static int cuteLevel = 10;
        public string Size { get; set; } = "Small to Large";
        
        public Dogs()
        {
            this.Size = "Small to Large";
        }

        // Methods
        public virtual string dogBark()
        {
            return "All dogs sounds like: bark bark";
        }

        public virtual string favoriteActivity()
        {
            return "All dogs likes to go for a walk";
        }

        public virtual string getCuteLevel()
        {
            return Convert.ToString(cuteLevel);
        }

    }
}