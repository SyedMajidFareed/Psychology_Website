using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Website.Models.Interfaces;
using Website.Models.VIewModels;

namespace Website.Models
{
    public class UserRepository : IUserLogin
    {
        public static int? ID = 0;
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

        public UserTable GetUserLoginEF(UserLogin user)
        {
            var db = new WebsiteDBContext();
            UserTable userLogin = new UserTable();
            db.UserTables.Where(u => u.Username == user.Username && u.Password == user.Password).ToList().ForEach(o => userLogin = o);
            if (userLogin != null)
            {
                return userLogin;
            }
            else
            {
                return null;
            }
        }


        public UserViewModel GetUserLoginMapper(UserViewModel user)
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


        public void FileUploads(List<IFormFile> postedFiles, string wwwPath)
        {
           
            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in postedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                //C:\Users\MajidFareed\source\repos\Website\Website\wwwroot\Uploads\IMG_20220219_182841-01-resize.jpeg
            }
        }

        public void setUserID(UserTable user)
        {

            if (user.Id != null)
            {
                ID = user.Id;
            }
            else
            {
                ID = 0;
            }
        }

        public int? getUserID()
        {
            return ID;
        }


    }
}