namespace Website.Models.Interfaces
{
    public interface IAdmin
    {
        public static int ID;
        public Admin login(Admin admin);
        public int getAdminID();
    }
}
