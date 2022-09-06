using System;
using System.Reflection;

namespace reflectionDemo
{
    class Program
    {
        public static string MyMood { get; set; } = "cheery";
        public static int MyPopsicleSticks { get; set; } = 4;
        public static int a =5, b=10, c=20;

        static void Main(string[] args)
        {
            Assembly assemblyType = typeof(Program).Assembly;
            Console.WriteLine($"{assemblyType.Location}");
            Console.WriteLine($"{assemblyType.EntryPoint}");
            Console.WriteLine($"{assemblyType.FullName}");
            Console.WriteLine($"{assemblyType.ToString()}");
            Console.WriteLine($"{assemblyType.GetHashCode()}");
            Console.WriteLine($"{assemblyType.GetName()}");
            Console.WriteLine($"{assemblyType.SecurityRuleSet}");
            //Console.WriteLine($"{assemblyType.LoadModule()}");
            Console.WriteLine($"{assemblyType.IsFullyTrusted}");

            Type[] assemblyMembers = assemblyType.GetTypes();

            foreach(Type i in assemblyMembers)
            {
                Console.WriteLine($"{i.Name} is a {i.GetType()}, \n\tIt's namespace is {i.Namespace}. \n\tIt's a '{i.MemberType}' type of member.");
                if(i.GetMembers() != null)
                {
                    MemberInfo[] members = i.GetMembers();
                    foreach (MethodInfo ii in members)
                    {
                        if(ii.Name == "GetMyAge" && ii.GetParameters().Length == 0)
                        {
                            var classInstance = Activator.CreateInstance(typeof(First));
                            object? age = ii.Invoke(classInstance, null);
                            Console.WriteLine($"The return from the GetMyAge() is {(int)age}");
                        }
                    }
                }

            }








            Type programType = typeof(Program);

            //MemberInfo[] only worked when we added "using.System.Reflection;"
            MemberInfo[] memberInfoArr = programType.GetMember("a");

            foreach(MemberInfo mi in memberInfoArr)
            {
                Console.WriteLine($"{mi.DeclaringType} declared {mi.Name} with a type of {mi.GetType()} ...");
            }

            //key code,  that "a" controlled which field
            FieldInfo? fi = programType.GetField("a", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            if (fi != null)
            {
                Console.WriteLine($"{fi?.Name} is a/an {fi?.GetType()} and it's value is {fi?.GetValue(null)}");
                fi?.SetValue(programType, 10);
                Console.WriteLine($"{fi?.Name} is a/an {fi?.GetType()} and it's new value is {fi?.GetValue(null)}");
            }
            else Console.WriteLine($"fi was null");

            MemberInfo[] gms = programType.GetMembers();
            foreach (var i in gms)
            {
                Console.WriteLine($"{i.Name} is a {i.GetType()} and it's value is unavailable?");
            }

            PropertyInfo[] gps = programType.GetProperties();
            foreach (var i in gms)
            {
                Console.WriteLine($"{i.Name} is a {i.GetType()} and it's value is {i?.GetValue(null)}");
            }
            

            var x = programType.GetProperty("MyMood");
            Console.WriteLine($"The value of {x.Name} is {x?.GetValue(programType)}");
        }
    }
}

