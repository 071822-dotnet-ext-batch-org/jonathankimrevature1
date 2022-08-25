namespace ModelsLayer
{
    public class Employee
    {
        public Employee(Guid employeeID, string firstName, string lastName, bool isManager, string username, string password)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            IsManager = isManager;
            Username = username;
            Password = password;
        }

        public Guid EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsManager { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}