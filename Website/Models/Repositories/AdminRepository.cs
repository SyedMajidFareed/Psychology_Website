using Microsoft.Data.SqlClient;
using Website.Models.Interfaces;

namespace Website.Models.Repositories
{
    public class AdminRepository : IAdmin
    {
        public Admin login(Admin admin)
        {
            var db = new WebsiteDBContext();
            var query = db.UserTables.Where(u => u.Username == admin.Name && u.Password == admin.Password);
            if (query.Count() > 0)
            {
                return admin;
            }
            else
            {
                return null;
            }

        }
    }
}
