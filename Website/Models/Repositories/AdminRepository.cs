using Microsoft.Data.SqlClient;
using Website.Models.Interfaces;

namespace Website.Models.Repositories
{
    public class AdminRepository : IAdmin
    {
        public Admin login(Admin admin)
        {

            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to fetxh data
            string query = $"select * from Admins where Name = @U AND Password = @P";
            SqlCommand cmd = new SqlCommand(query, connection);

            //defining parameters
            SqlParameter p1 = new SqlParameter("U", admin.Name);
            SqlParameter p2 = new SqlParameter("P", admin.Password);

            //adding parameter
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                connection.Close();
                return admin;
            }
            else
            {
                connection.Close();
                return null;
            }

        }
    }
}
