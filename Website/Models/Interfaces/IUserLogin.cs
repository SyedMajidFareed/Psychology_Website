﻿namespace Website.Models.Interfaces
{
    public interface IUserLogin
    {
        public void addUserEF(UserTable user);
        List<UserTable> getAllUsersEF();
        UserTable GetUserEF(UserTable user);
        UserLogin GetUserLogin(UserLogin user);
    }
}
