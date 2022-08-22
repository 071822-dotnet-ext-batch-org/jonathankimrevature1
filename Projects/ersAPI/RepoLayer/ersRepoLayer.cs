using ModelsLayer;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;

namespace RepoLayer
{
    public class ersRepoLayer
    {



        public async Task<bool> LoginAsync(string Username, string Password)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Username FROM Employees WHERE Username = @username AND Password = @password", conn1))
            {
                command.Parameters.AddWithValue("@username", Username);
                command.Parameters.AddWithValue("@password", Password);
                conn1.Open();
                
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    conn1.Close();
                    return true;
                }
                conn1.Close();
                return false;
            }
        }



        public async Task<bool> RegisterUserAsync(Guid EmployeeID, string FirstName, string LastName, string Username, string Password)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Employees (EmployeeID, FirstName, LastName, IsManager, Username, Password) VALUES (@employeeID, @firstname, @lastname, 0, @username,@password)", conn1))// The 0 means all new accounts are employees by default
            {
                command.Parameters.AddWithValue("@employeeID", EmployeeID);
                command.Parameters.AddWithValue("@firstname", FirstName);
                command.Parameters.AddWithValue("@lastname", LastName);
                command.Parameters.AddWithValue("@username", Username);
                command.Parameters.AddWithValue("@password", Password);
                conn1.Open();

                bool DoesUsernameExist = await this.DoesUsernameAlreadyExistAsync(Username); //Use a method in the repo layer to do a 'yes' or 'no' check if username already exists
                if (DoesUsernameExist == true) //If true, username already exists
                {
                    return false; //If that is the case DO NOT execute query
                }
                bool ret = (await command.ExecuteNonQueryAsync()) == 1; //Only execute query AFTER confirming no duplicate usernames
                conn1.Close();
                return ret;
            }
        }



        public async Task<bool> SubmitTicketAsync(Guid TicketID, Guid FK_Employee, string Description, decimal Amount)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"INSERT INTO Tickets (TicketID, FK_EmployeeID, Description, Amount, Status, Processed) VALUES (@ticketID, @fk_employeeID, @description, @amount, 0, 0)", conn1)) //The 2 zeros are for Status and Processed because new tickets should be "pending" and "not processed" by default
            {
                command.Parameters.AddWithValue("@ticketID", TicketID);
                command.Parameters.AddWithValue("@fk_employeeID", FK_Employee);
                command.Parameters.AddWithValue("@description", Description);
                command.Parameters.AddWithValue("@amount", Amount);
                conn1.Open();
                
                bool ret = (await command.ExecuteNonQueryAsync()) == 1;
                conn1.Close();
                return ret;
            }
        }



        public async Task<UpdatedTicketDTO> UpdateTicketAsync(Guid TicketID, int Status)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"UPDATE Tickets SET Status = @status, Processed = 1 WHERE TicketID = @id AND Status >= 0;", conn1))//Whenever Status changes from 'pending' then its now processed. Done automatically without human input.
            {                                                                                                                                           
                command.Parameters.AddWithValue("@status", Status);
                command.Parameters.AddWithValue("@id", TicketID);
                conn1.Open();
               
                bool IsItProcessed = await this.IsitAlreadyProcessedAsync(TicketID);//Similar to when we checked if previous usernames existed, 'yes' or 'no' if ticket was processed or not BEFORE the SQL query executes
                if (IsItProcessed == true)//If ticket has been processed (Processed = 1), then yes, this ticket has been processed...
                {
                    return null;//Since it has been processed, then DO NOT update this ticket. (Required: Tickets cannot change status after processing)
                }
                int ret = await command.ExecuteNonQueryAsync();//After sorting out whether or not we should update the ticket, execute SQL Command.
                {                                              //Also, its not 'SqlDataReader' because we are doing something to the database. SqlDataReader only reads. 
                    conn1.Close();
                    UpdatedTicketDTO urbi = await this.UpdatedTicketByIDAsync(TicketID);
                    return urbi;
                }
                conn1.Close();
                return null;
            }
        }



        public async Task<List<Ticket>> GetAllTicketsAsync(int Status)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT TicketID, FK_EmployeeID, Description, Amount, Status FROM Tickets WHERE Status = @status", conn1))
            {
                command.Parameters.AddWithValue("@status", Status);//Add dynamic data like this to protect against SQL Injection
                conn1.Open(); //Open connection
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<Ticket> tList = new List<Ticket>();//Output is a list so make a list and put stuff in it
                while (ret.Read())
                {
                    Ticket t = new Ticket((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetInt32(4));//Similar to SQL Inserting values after creating tables
                    tList.Add(t);
                }
                conn1.Close();
                return tList;
            }
        }



        public async Task<bool> DoesUsernameAlreadyExistAsync(string Username)//Made purely to get a 'yes' or 'no' value before the SQL query for program to know when to stop or continue in the IF statements
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Username FROM Employees WHERE Username = @username", conn1))
            {
                command.Parameters.AddWithValue("@username", Username);
                conn1.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    conn1.Close();
                    return true;
                }
                conn1.Close();
                return false;
            }
        }



        public async Task<bool> IsitAlreadyProcessedAsync(Guid TicketID)//Same as ^ above, all of this was made for a 'yes' or 'no', probably not the best way of doing it
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT Processed FROM Tickets WHERE TicketID = @ticketID AND Processed = 1", conn1))
            {
                command.Parameters.AddWithValue("@ticketID", TicketID);
                conn1.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    conn1.Close();
                    return true;
                }
                conn1.Close();
                return false;
            }
        }


       

        private async Task<UpdatedTicketDTO> UpdatedTicketByIDAsync(Guid TicketID)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT TicketID, FirstName, LastName, Status FROM [dbo].[Employees] LEFT JOIN Tickets ON EmployeeID = FK_EmployeeID WHERE TicketID = @TicketID ", conn1))
            {
                command.Parameters.AddWithValue("@TicketID", TicketID);
                conn1.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    UpdatedTicketDTO t = new UpdatedTicketDTO(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3));
                    conn1.Close();
                    return t;
                }
                conn1.Close();
                return null;
            }
        }



        public async Task<bool> IsManangerAsync(Guid employeeId)
        {
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT IsManager FROM Employees WHERE EmployeeID = @id", conn1))
            {
                command.Parameters.AddWithValue("@id", employeeId);
                conn1.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                //if anything was returned and if IsManager true. 0 because that is the first parameter from SQL command line. "IsManager" 
                if (ret.Read() && ret.GetBoolean(0))
                {
                    //then return true, Employee is a manager
                    conn1.Close();
                    return true;
                }
                conn1.Close();
                //else, return false. Employee is not a manager
                return false;
            }
        }
    }
}

