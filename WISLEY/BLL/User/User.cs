﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Profile;

namespace WISLEY.BLL.Profile
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string contactNo { get; set; }
        public string userType { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public int points { get; set; }
        public string bio { get; set; }
        public string profilesrc { get; set; }

        public User()
        {

        }

        public User(string email, string password, string salt, string userType, string name, string dob, string contactNo, string gender, int points, string bio, string profilesrc = "", int id = -1)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.salt = salt;
            this.userType = userType;
            this.name = name;
            this.dob = dob;
            this.contactNo = contactNo;
            this.gender = gender;
            this.points = points;
            this.bio = bio;
            this.profilesrc = profilesrc;
        }

        public int AddUser()
        {
            UserDAO userdao = new UserDAO();
            return userdao.Insert(this);
        }

        public User SelectByEmail(string email)
        {
            UserDAO userdao = new UserDAO();
            return userdao.SelectByEmail(email);
        }

        public User SelectById(string uid)
        {
            UserDAO userdao = new UserDAO();
            return userdao.SelectById(uid);
        }

        public int UpdateUser(string email, string name, string dob, string contactNo)
        {
            UserDAO userdao = new UserDAO();
            return userdao.UpdateUser(email, name, dob, contactNo);
        }

        public int UpdatePassword(string email, string password)
        {
            UserDAO userdao = new UserDAO();
            return userdao.UpdatePassword(email, password);
        }

        public int UpdateBio(string email, string bio)
        {
            UserDAO userdao = new UserDAO();
            return userdao.UpdateBio(email, bio);
        }

        public int UpdateProfilePic(int id, string src)
        {
            UserDAO userdao = new UserDAO();
            return userdao.UpdateProfilePic(id, src);
        }

        public int UpdateWISPoints(int id, int points)
        {
            UserDAO userdao = new UserDAO();
            return userdao.UpdateWISPoints(id, points);
        }

        public int GetLastID()
        {
            UserDAO userdao = new UserDAO();
            return userdao.GetLastID();
        }
    }
}