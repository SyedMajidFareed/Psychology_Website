namespace Website.Models.Interfaces
{
    public interface ITherapist
    {
        public static int ID;
        public void addTherapistEF(Therapist therapist);
        List<Therapist> getAllTherapistEF();
        Therapist GetTherapistEF(Therapist therapist);
        Therapist GetTherapistLogin(TherapistLogin therapist);
        public void FileUploads(List<IFormFile> postedFiles, string wwwPath);
        public void setTherapistID(Therapist user);
        public int getTherapistID();

    }
}
