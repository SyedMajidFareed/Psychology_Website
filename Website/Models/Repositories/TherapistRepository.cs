using Microsoft.Data.SqlClient;
using Website.Models.Interfaces;

namespace Website.Models.Repositories
{
    public class TherapistRepository : ITherapist
    {
        public void addTherapistEF(Therapist therapist)
        {
            var db = new WebsiteDBContext();
            db.Therapists.Add(therapist);
            db.SaveChanges();
        }
        public List<Therapist> getAllTherapistEF()
        {
            List<Therapist> list = new List<Therapist>();
            var db = new WebsiteDBContext();
            var TUser = from tuser in db.Therapists select tuser;

            foreach (var tuser in TUser)
            {

                list.Add(tuser);
            }
            return list;
        }

        public Therapist GetTherapistEF(Therapist therapist)
        {
            var db = new WebsiteDBContext();
            var query = db.Therapists.Where(u => u.TUsername == therapist.TUsername && u.TPassword == therapist.TPassword);
            if (query.Count() > 0)
            {
                return therapist;
            }
            else
            {
                return null;
            }
        }



        public TherapistLogin GetTherapistLogin(TherapistLogin therapist)
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebsiteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to fetxh data
            string query = $"select * from Therapists where TUsername = @U AND TPassword = @P";
            SqlCommand cmd = new SqlCommand(query, connection);

            //defining parameters
            SqlParameter p1 = new SqlParameter("U", therapist.TUsername);
            SqlParameter p2 = new SqlParameter("P", therapist.TPassword);

            //adding parameter
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                connection.Close();
                return therapist;
            }
            else
            {
                connection.Close();
                return null;
            }

        }
    }
}