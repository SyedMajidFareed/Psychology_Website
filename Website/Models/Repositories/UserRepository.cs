using System.Linq;
using Microsoft.Data.SqlClient;
using Website.Models.Interfaces;
namespace Website.Models
{
    public class UserRepository : IUserLogin
    {


        public void addUserEF(UserTable user)
        {
            var db = new WebsiteDBContext();
            db.UserTables.Add(user);
            db.SaveChanges();
        }
        public List<UserTable> getAllUsersEF()
        {
            List<UserTable> list = new List<UserTable>();
            var db = new WebsiteDBContext();
            var User = from user in db.UserTables select user;

            foreach (var user in User)
            {

                list.Add(user);
            }
            return list;
        }

        public UserTable GetUserEF(UserTable user)
        {
            var db = new WebsiteDBContext();
            var query = db.UserTables.Where(u => u.Username == user.Username && u.Password == user.Password);
            if (query.Count() > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }



        public UserLogin GetUserLogin(UserLogin user)
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to fetxh data
            string query = $"select * from UserTable where Username = @U AND Password = @P";
            SqlCommand cmd = new SqlCommand(query, connection);

            //defining parameters
            SqlParameter p1 = new SqlParameter("U", user.Username);
            SqlParameter p2 = new SqlParameter("P", user.Password);

            //adding parameter
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                connection.Close();
                return user;
            }
            else
            {
                connection.Close();
                return null;
            }

        }

        //    public static void addUser(User user)
        //{


        //    //establishing connection with database
        //    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    //writing a query to insert data
        //    string query = $"insert into UserTable(Username, Password, Email) " +
        //                   $"values('{user.Username}','{user.Password}','{user.Email}')";
        //    SqlCommand cmd = new SqlCommand(query, connection);

        //    connection.Open();
        //    int alteredrows = cmd.ExecuteNonQuery();
        //    connection.Close();

        //}
        //public static void addUserLogin(UserLogin user)
        //{


        //    //establishing connection with database
        //    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    //writing a query to insert data
        //    string query = $"insert into UserTable(Username, Password) " +
        //                   $"values('{user.Username}','{user.Password}')";
        //    SqlCommand cmd = new SqlCommand(query, connection);

        //    connection.Open();
        //    int alteredrows = cmd.ExecuteNonQuery();
        //    connection.Close();

        //}
        //public static List<User> getAllUsers()
        //{
        //    List<User> users = new List<User>();
        //    //establishing connection with database
        //    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    //writing a query to fetxh data
        //    string query = $"select * from UserTable";
        //    SqlCommand cmd = new SqlCommand(query, connection);


        //    connection.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        User user = new User();
        //        user.Username = Convert.ToString(dr[1]);
        //        user.Password = Convert.ToString(dr[2]);
        //        user.Email = Convert.ToString(dr[3]);
        //        users.Add(user);
        //    }
        //    connection.Close();
        //    return users;
        //}
        //public static User GetUser(User user)
        //{
        //    //establishing connection with database
        //    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    //writing a query to fetxh data
        //    string query = $"select * from UserTable where Username = @U AND Password = @P";
        //    SqlCommand cmd = new SqlCommand(query, connection);

        //    //defining parameters
        //    SqlParameter p1 = new SqlParameter("U", user.Username);
        //    SqlParameter p2 = new SqlParameter("P", user.Password);

        //    //adding parameter
        //    cmd.Parameters.Add(p1);
        //    cmd.Parameters.Add(p2);
        //    connection.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        connection.Close();
        //        return user;
        //    }
        //    else
        //    {
        //        connection.Close();
        //        return null;
        //    }

        //}

    }
}