﻿using Microsoft.VisualBasic;
using Website.Models.VIewModels;

namespace Website.Models.Interfaces
{
    public interface IUserLogin
    {
        public static int ID;
        public void addUserEF(UserTable user);
        List<UserTable> getAllUsersEF();
        UserTable GetUserEF(UserTable user);
        UserViewModel GetUserLoginMapper(UserViewModel user);
        public UserLogin GetUserLoginEF(UserLogin user);
        public void FileUploads(List<IFormFile> postedFiles, string wwwPath);
        public void setUserID(UserLogin user);
        public int getUserID();

    }
}
