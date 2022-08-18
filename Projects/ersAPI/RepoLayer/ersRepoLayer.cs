using ModelsLayer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RepoLayer
{
    public class ersRepoLayer
    {
        public async Task<List<Ticket>> TicketsAsync(int type) //After the while loop this goes to the ersBusinessLayer
        {

            //SqlConnection and SqlCommand are built in
            //Get our connection string as a SQL connection
            SqlConnection conn1 = new SqlConnection("Server=tcp:jonathanrevature.database.windows.net,1433;Initial Catalog=jonathanProjectOne;Persist Security Info=False;User ID=Jonathankim829;Password=Hakmin419;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE Status = @type", conn1))//Create command using the query and the connection string
            {
                //AddWithValue and SqlDataReader are built in
                //ExecuteReaderAsync is what we made to use the sql program
                //Give parameters to newly created "command" from line 14 
                command.Parameters.AddWithValue("@type", type);//Give parameters with AddWithValue command. //Add dynamic data like this to protect against SQL Injection
                conn1.Open(); //Open connection
                SqlDataReader? ret = await command.ExecuteReaderAsync();//Make query execute. Its as reader so its readnig data from the database. It's not putting anything in
                List<Ticket> tList = new List<Ticket>();//Create empyu list

                //Keeps reading row by row until it runs out of rows, then .Read() is false
                while(ret.Read())//Iterate over returned object (ret.)
                {
                    // This is to pass through data like SQL (Guid TicketID, Guid FK_Employee, String Description, Double Amount, int Status)
                    Ticket t = new Ticket((Guid)ret[0], (Guid)ret[1], ret.GetString(2), ret.GetDecimal(3), ret.GetInt32(4));//Create request ojects 
                    tList.Add(t); //add them to list with each cycle
                }
                return tList;//return list
            }   //Then the code in line 9 returnes to the business layer
        }

    }
}