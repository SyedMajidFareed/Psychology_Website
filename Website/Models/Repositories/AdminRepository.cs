using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Website.Models.Interfaces;

namespace Website.Models.Repositories
{
    public class AdminRepository : IAdmin
    {
        public static int ID = 0;
        public Admin login(Admin admin)
        {
            var db = new WebsiteDBContext();
            var query = db.UserTables.Where(u => u.Username == admin.Name && u.Password == admin.Password);
            if (query.Count() > 0)
            {
                ID = admin.Id;
                return admin;
            }
            else
            {
                return null;
            }

        }
        public int getAdminID()
        {
            return ID;
        }
        public void deleteUser(int id)
        {
            var db = new WebsiteDBContext();
            UserTable newUser = new UserTable();
            var User = from user in db.UserTables where user.Id==id select user;

            foreach (var item in User)
            {
                newUser = item;
               
            }
            db.UserTables.Remove(newUser);
            db.SaveChanges();
        }
        public void deleteTherapist(int id)
        {
            var db = new WebsiteDBContext();
            Therapist newUser = new Therapist();
            var User = from user in db.Therapists where user.Id==id select user;

            foreach (var item in User)
            {
                newUser = item;
               
            }
            db.Therapists.Remove(newUser);
            db.SaveChanges();
        }
        public void deleteContent(int id)
        {
            var db = new WebsiteDBContext();
            ContentData newUser = new ContentData();
            var User = from user in db.ContentItems where user.Id == id select user;

            foreach (var item in User)
            {
                newUser = item;

            }
            db.ContentItems.Remove(newUser);
            db.SaveChanges();
        }
    }
}
