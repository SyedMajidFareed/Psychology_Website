namespace Website.Models.Interfaces
{
    public interface ITherapist
    {
        public static int ID;
        public void addTherapistEF(Therapist therapist);
        List<Therapist> getAllTherapistEF();
        Therapist GetTherapistEF(Therapist therapist);
        TherapistLogin GetTherapistLogin(TherapistLogin therapist);
        public void FileUploads(List<IFormFile> postedFiles, string wwwPath);
        public void setTherapistID(TherapistLogin user);
        public int getTherapistID();

    }
}
