using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ERSProgram.Models;
using System.Data;

namespace ERSProgram.DataLayer
{
    public class UserDAL
    {
        public string cnn = "";

        public UserDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).
                AddJsonFile("appSettings.json").Build();

            cnn = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public List<Users> GetAllUsers()
        {
            List<Users> ListOfUsers = new List<Users>();
            using(SqlConnection cn=new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllUsers",cn))
                {
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    IDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        ListOfUsers.Add(new Users()
                        {
                            UserID = int.Parse(reader["UserID"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            FirstName =reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Role = reader["Role"].ToString(),

                        });
                    }
                }
            }
            return ListOfUsers;
        }




    }
}
