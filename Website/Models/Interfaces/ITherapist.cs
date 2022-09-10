namespace Website.Models.Interfaces
{
    public interface ITherapist
    {
        public void addTherapistEF(Therapist therapist);
        List<Therapist> getAllTherapistEF();
        Therapist GetTherapistEF(Therapist therapist);
        TherapistLogin GetTherapistLogin(TherapistLogin therapist);
    }
}
