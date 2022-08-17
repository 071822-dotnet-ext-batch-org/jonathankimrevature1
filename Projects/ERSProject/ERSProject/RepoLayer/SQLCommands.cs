using System.Data.SqlClient;
using System;
using Models;

namespace RepoLayer
{
    public class SQLCommands
    {
        public bool GetEmployeeByUsername(string Username)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;" +
                                                  "Initial Catalog=jonathanProjectOne;Persist Security Info=False;" +
                                                  "User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;" +
                                                  "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            using (SqlCommand command = new SqlCommand("$SELECT * FROM Users WHERE Username = @username)", conn))
            {
                conn.Open();
                SqlDataReader? ret = command.ExecuteReader();
                if (ret.Read())
                {
                    Employee e = new Employee()
                    {
                        UserID = ret.GetGuid(0),
                        Username = ret.GetString(1),
                        Password = ret.GetString(2),
                        Role = ret.GetString(3),
                        FirstName = ret.GetString(4),
                        LastName = ret.GetString(5)
                    };
                    conn.Close();
                    return e;
                }
                else
                {
                    conn.Close();
                    return null;
                }
            }
        }

        public async Task<bool> ExistsPlayerByIdAsync(Guid playerId)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;" +
                                                  "Initial Catalog=jonathanProjectOne;Persist Security Info=False;" +
                                                  "User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;" +
                                                  "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            using (SqlCommand command = new SqlCommand($"SELECT Top 1 UserId FROM Users WHERE UserId = @x", conn))
            {
                command.Parameters.AddWithValue("@x", playerId);// add dynamic data like this to protect against SQL Injection.
                conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
        }


        public int RegisterUser(Employee e)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;" +
                                                  "Initial Catalog=jonathanProjectOne;Persist Security Info=False;" +
                                                  "User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;" +
                                                  "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            using (SqlCommand command = new SqlCommand("$INSERT INTO Users (UserID, Username, Password, Role, FirstName, LastName) VALUES (@UserID, @Username, @Password, @Role, @Firstname, @Lastname)", conn))
            {
                command.Parameters.AddWithValue("@UserID", e.UserID);
                command.Parameters.AddWithValue("@Username", e.Username);
                command.Parameters.AddWithValue("@Password", e.Password);
                command.Parameters.AddWithValue("@Role", e.Role);
                command.Parameters.AddWithValue("@FirstName", e.FirstName);
                command.Parameters.AddWithValue("@LastName", e.LastName);
                conn.Open();
                int ret = command.ExecuteNonQuery();

                if (ret == 1)
                {
                    conn.Close();
                    return ret;
                }
                else
                {
                    conn.Close();
                    return ret;
                }
            }
        }
        public int CreateTicket(Ticket t)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;" +
                                                  "Initial Catalog=jonathanProjectOne;Persist Security Info=False;" +
                                                  "User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;" +
                                                  "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            using (SqlCommand command = new SqlCommand("$INSERT INTO Tickets (TicketID, Amount, Description, Status) VALUES (@TicketID, @Amount, @Description, @Status)", conn))
            {
                command.Parameters.AddWithValue("@TicketID", t.TicketID);
                command.Parameters.AddWithValue("@Amount", t.Amount);
                command.Parameters.AddWithValue("@Description", t.Description);
                command.Parameters.AddWithValue("@Status", t.Status);
                conn.Open();
                int ret = command.ExecuteNonQuery();

                if (ret == 1)
                {
                    conn.Close();
                    return ret;
                }
                else
                {
                    conn.Close();
                    return ret;
                }
            }
        }

        public int UpdateTicket(Ticket t)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;" +
                                                  "Initial Catalog=jonathanProjectOne;Persist Security Info=False;" +
                                                  "User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;" +
                                                  "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
           
            using (SqlCommand command = new SqlCommand("$UPDATE Tickets SET Status @status WHERE TicketID = @TicketID", conn))
            {
                command.Parameters.AddWithValue("@TicketID", t.TicketID);
                command.Parameters.AddWithValue("@Status", t.Status);
                conn.Open();
                int ret = command.ExecuteNonQuery();

                if (ret > 0)
                {
                    conn.Close();
                    return ret;
                }
                else
                {
                    conn.Close();
                    return ret;
                }
            }

        }
    }
}
