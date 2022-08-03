using System;
using System.Collections.Generic;
using System.Linq;

namespace ersProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare Variables
            string inputUsername = "";
            string inputPassword = "";
            string acUsername = "Jonathankim829";
            string acPassword = "Hakmin419";

            //Welcome
            Console.WriteLine("Welcome to the the expense reimbursement system!");
            
            //Enter username and save it
            Console.WriteLine("Please enter your username:");
            Console.WriteLine($"Username: {inputUsername = Console.ReadLine()}");
            
            //Enter password and save it
            Console.WriteLine("\nPlease enter your password:");
            Console.WriteLine($"Password: {inputPassword = Console.ReadLine()}");


            //if (inputUsername == acUsername && inputPassword == acPassword)
            //{}

            var user = new EmployeeProfile("Jonathankim829", "Hakmin419", "Jonathan", "Kim", true);
            Console.WriteLine($"Username:{user.userName} Password:{user.passWord} First Name:{user.fName} Last Name:{user.lName} Employee:{user.employee}");


        }
    }
}
