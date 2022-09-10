using Website.Models.VIewModels;

namespace Website.Models.Interfaces
{
    public interface IUserLogin
    {
        public void addUserEF(UserTable user);
        List<UserTable> getAllUsersEF();
        UserTable GetUserEF(UserTable user);
        UserViewModel GetUserLoginMapper(UserViewModel user);
        public UserLogin GetUserLoginEF(UserLogin user);
    }
}
