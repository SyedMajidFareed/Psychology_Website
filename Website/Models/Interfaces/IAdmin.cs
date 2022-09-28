namespace Website.Models.Interfaces
{
    public interface IAdmin
    {
        public static int ID;
        public Admin login(Admin admin);
        public int getAdminID();
        public void deleteUser(int id);
        public void deleteTherapist(int id);
        public void deleteContent(int id);

    }
}
