using Microsoft.Data.SqlClient;
using Website.Models.Interfaces;

namespace Website.Models.Repositories
{
    public class TherapistRepository : ITherapist
    {
        public static int ID = 0;
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



        public Therapist GetTherapistLogin(TherapistLogin therapist)
        {
            var db = new WebsiteDBContext();
            Therapist Temptherapist = new Therapist();
            db.Therapists.Where(u => u.TUsername == therapist.TUsername && u.TPassword == therapist.TPassword).ToList().ForEach(o => Temptherapist = o);
            if (Temptherapist != null)
            {
                return Temptherapist;
            }
            else
            {
                return null;
            }

        }

        public void setTherapistID(Therapist user)
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

        public int getTherapistID()
        {
            return ID;
        }

        public void FileUploads(List<IFormFile> postedFiles, string wwwPath)
        {
            string path = Path.Combine(wwwPath, "TherapistUploads");
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

    }
}