﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Profile;

namespace WISLEY.BLL.User
{
    public class Badge
    {
        public int Id { get; set; }
        public int badgeId { get; set; }
        public string userId { get; set; }
        public string src { get; set; }
        public string alt { get; set; }
        public string requirement { get; set; }
        public int points { get; set; }
        public string dateachieved { get; set; }
        public string status { get; set; }

        public Badge()
        {

        }

        public Badge(int badgeId, string userId, string src, string alt, string requirement, int points, string dateachieved, string status)
        {
            this.badgeId = badgeId;
            this.userId = userId;
            this.src = src;
            this.alt = alt;
            this.requirement = requirement;
            this.points = points;
            this.dateachieved = dateachieved;
            this.status = status;
        }

        public int AddBadge()
        {
            BadgeDAO badgedao = new BadgeDAO();
            return badgedao.Insert(this);
        }

        public List<Badge> SelectByUserId(string userId, string status)
        {
            BadgeDAO badgedao = new BadgeDAO();
            return badgedao.SelectByUserId(userId, status);
        }

        public int UpdateBadge(string userId, int badgeId, string dateachieved, string status)
        {
            BadgeDAO badgedao = new BadgeDAO();
            return badgedao.UpdateBadge(userId, badgeId, dateachieved, status);
        }

        public int GetLastID()
        {
            BadgeDAO badgedao = new BadgeDAO();
            return badgedao.GetLastID();
        }

        public int GetBadgeCount(string userId, string status)
        {
            BadgeDAO badgedao = new BadgeDAO();
            return badgedao.GetBadgeCount(userId, status);
        }

        public Badge SelectByBadgeId(string userId, int badgeId)
        {
            BadgeDAO badgedao = new BadgeDAO();
            return badgedao.SelectByBadgeId(userId, badgeId);
        }
    }
}